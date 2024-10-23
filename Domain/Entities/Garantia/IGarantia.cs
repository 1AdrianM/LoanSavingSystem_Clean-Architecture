using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Garantia
{
    public interface IGarantia
    {
        void Add(Garantias garantia);
        void Delete(Garantias garantia);
        void Update(Garantias garantia);

       Task<Garantias> GetById(int id);
           Task<IEnumerable<Garantias>> GetAllGarantia();
    }
}
