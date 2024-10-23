using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Prestatario
{
    public interface IPrestatario
    {
        Task<IEnumerable<Prestatario>>GetAllPrestatarios();
    }
}
