using Application.SeedOfWork;
using Domain.Entities.CuotaPrestamo;
using Domain.Entities.Prestamo;
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
    internal class CuotaPrestamoRepository : ICuotaPrestamo
    {
        private readonly AhorrosPrestamosDb2Context _dbContext;
        private readonly IPrestamo _prestamo;
        public IUnitOfWork UnitOfWork => _dbContext;
        public CuotaPrestamoRepository(IPrestamo prestamo, AhorrosPrestamosDb2Context dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(DbContext));
            _prestamo = prestamo;
        }
        public void PagarCuota(CuotaPrestamo cuota)
        {
            var cuotaMapped = CuotaPrestamoMapper.ToDomainModel(cuota);

            _dbContext.CuotaPrestamos.Update(cuotaMapped);
        }

        public void Create(CuotaPrestamo cuota)
        {
            var cuotaMapped = CuotaPrestamoMapper.ToDomainModel(cuota);
            if (cuotaMapped != null)
            {

                _dbContext.CuotaPrestamos.Add(cuotaMapped);
            }
            else {
                Console.WriteLine("somehow returning null");
                throw new Exception("returning null");

            }
        }

        public void Delete(CuotaPrestamo cuota)
        {
            var cuotaMapped = CuotaPrestamoMapper.ToDomainModel(cuota);
            _dbContext.CuotaPrestamos.Remove(cuotaMapped);
        }

        public async Task<IEnumerable<CuotaPrestamo>> GetAllCuotasPrestamo(CuotaPrestamo cuota)
        {
           var ct = await _dbContext.CuotaPrestamos.AsNoTracking().ToListAsync();
        return ct.Select(CuotaPrestamoMapper.ToEfModel);
        }

        public async Task<CuotaPrestamo> GetByIdCuotasPrestamo(int cuotaId)
        {
            var cuota =  await _dbContext.CuotaPrestamos.AsNoTracking().FirstOrDefaultAsync(cu=> cu.CuotaId == cuotaId);
            if(cuota == null)
            {
                throw new Exception("cuota not found");
            }
            return CuotaPrestamoMapper.ToEfModel(cuota);
        }
    }
}
