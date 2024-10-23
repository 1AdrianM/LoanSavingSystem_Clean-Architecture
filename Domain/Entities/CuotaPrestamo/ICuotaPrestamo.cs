using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CuotaPrestamo
{
    public interface ICuotaPrestamo
    {
        void PagarCuota(CuotaPrestamo cuota);
        void Create(CuotaPrestamo cuota);
        void Delete(CuotaPrestamo cuota);
        Task<CuotaPrestamo>GetByIdCuotasPrestamo(int cuotaId);
         Task<IEnumerable<CuotaPrestamo>> GetAllCuotasPrestamo(CuotaPrestamo cuota);
     }
}
