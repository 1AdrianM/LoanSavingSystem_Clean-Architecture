using Application.SeedOfWork;
using Domain.Entities.Garantia;
using Infrastructure.Mapper;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GarantiaRepository : IGarantia
    {
        private readonly AhorrosPrestamosDb2Context _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public GarantiaRepository(AhorrosPrestamosDb2Context dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentException(nameof(DbContext));

        }
        public void Add(Garantias garantia)
        {
            var newGarantia = GarantiaMapper.DomainGarantiaToEfGarantium(garantia);
            _dbContext.Garantia.Add(newGarantia);
        }

        public void Delete(Garantias garantia)
        {
            var newGarantia = GarantiaMapper.DomainGarantiaToEfGarantium(garantia);
            _dbContext.Garantia.Remove(newGarantia);
        }

        public async Task<IEnumerable<Garantias>> GetAllGarantia()
        {
           var GarantiaList = await _dbContext.Garantia
                .Include(g=> 
                g.Prestamos)
                .ToListAsync();
            return GarantiaList.Select(GarantiaMapper.EFGarantiumToDomainGarantium);
        }

        public async Task<Garantias> GetById(int id)
        {
            var garantia = await _dbContext.Garantia.AsNoTracking().Include(g=> g.Prestamos).FirstOrDefaultAsync(g => g.GarantiaId == id);
            if(garantia== null)
            {
                throw new Exception("Garantia not found");
            }
            return GarantiaMapper.EFGarantiumToDomainGarantium(garantia);
         }

        public void Update(Garantias garantia)
        {
            var newGarantia = GarantiaMapper.DomainGarantiaToEfGarantium(garantia);
            _dbContext.Garantia.Remove(newGarantia);

        }
    }
}
