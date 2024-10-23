using Domain.Entities.Prestatario;
using Infrastructure.Mapper;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PrestatarioRepository : IPrestatario
    {
        private readonly AhorrosPrestamosDb2Context _dbContext;
        public PrestatarioRepository(AhorrosPrestamosDb2Context dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Prestatario>> GetAllPrestatarios()
        {
            var prestatario = await _dbContext.Prestatarios.Include(p=> p.Client).ToListAsync();
            if(prestatario.IsNullOrEmpty())
            { throw new Exception("Empty List prestatario"); }
         return prestatario.Select(PrestatarioMapper.EfPrestamoToDomainModel);

        }
    }
}
