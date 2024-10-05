using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Cliente
{
    public interface IClienteRepository
    {
         Task<Cliente>GetClientById(int id);
        Task<IEnumerable<Cliente>> GetAll();
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(Cliente cliente);

    }
}
