using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Prestamo
{
    public interface IPrestamo
    {
        Task<Prestamo> GetPrestamoByCodigoPrestamo(string Codigo);
         Task<Prestamo> GetPrestamoByIdPrestamo(int id);

        Task<IEnumerable<Prestamo>> GetAllPrestamos();
        void AprobarPrestamo(Prestamo prestamo);
        void UpdateDataPostApproval(Prestamo prestamo);
        void Update(Prestamo prestamo);
        void CreatePrestamoRequest(Prestamo prestamo);
        void Delete(Prestamo prestamo);
        List<Cronograma_Pagos> GenerarCronogramaPagos(Prestamo prestamo);
    }
}
