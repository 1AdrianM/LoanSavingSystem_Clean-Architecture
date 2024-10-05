using Domain.Entities.Cliente;
using Infrastructure.Persistence;
using Application.SeedOfWork;
using Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    class ClienteRepositoryImplementation : IClienteRepository
    {
        private readonly Loan_DbContext _DbContext;
        public IUnitOfWork UnitOfWork => _DbContext;

        public ClienteRepositoryImplementation(Loan_DbContext DbContext)
        {
             _DbContext = DbContext?? throw new ArgumentException(nameof(DbContext)) ;
        }

        public void Add(Domain.Entities.Cliente.Cliente cliente)
        {
              var Client =ClienteMapper.ToEfModel(cliente);
            _DbContext.Clientes.Add(Client);

        }

        public void Delete(Domain.Entities.Cliente.Cliente cliente)
        {
            var Client = ClienteMapper.ToEfModel(cliente);

            _DbContext.Clientes.Remove(Client);
      
            
        }

        public async Task <IEnumerable<Domain.Entities.Cliente.Cliente>> GetAll()
        {
            var ClientList =  await _DbContext.Clientes.ToListAsync();
           return ClientList.Select(ClienteMapper.ToDomainModel);
         
        }

        public async Task<Domain.Entities.Cliente.Cliente> GetClientById(int id)
        {
            var Client = await _DbContext.Clientes.AsNoTracking().FirstOrDefaultAsync(c=>c.ClientId==id);
 

            return ClienteMapper.ToDomainModel(Client);


        }

        public  void Update(Domain.Entities.Cliente.Cliente cliente)
        {
            var Client = ClienteMapper.ToEfModel(cliente);

            _DbContext.Clientes.Update(Client); 
        }

            
        }

    }

