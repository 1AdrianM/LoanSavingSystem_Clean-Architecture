using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CuotaPrestamo
{
    public class CuotaPrestamo
    {
        public int CuotaId { get; set; }

        public int PrestamoId { get; set; }

        public DateTime FechaPlanificada { get; set; }

        public decimal MontoPlanificado { get; set; }

        public DateTime? FechaEfectiva { get; set; }

        public string? TipoModalidad { get; set; }

        public string? ComprobantePago { get; set; }

        public string? Estado { get; set; }
        public CuotaPrestamo(int cuotaId, int prestamoId, DateTime fechaPlanificada, decimal montoPlanificado, DateTime? fechaEfectiva, string? tipoModalidad, string? comprobantePago, string? estado)
        {
            CuotaId = cuotaId;
            PrestamoId = prestamoId;
            FechaPlanificada = fechaPlanificada;
            MontoPlanificado = montoPlanificado;
            FechaEfectiva = fechaEfectiva;
            TipoModalidad = tipoModalidad;
            ComprobantePago = comprobantePago;
            Estado = estado;

        }
        public static CuotaPrestamo CreateCuotaDraft(int _CuotaId, int _PrestamoId, DateTime _FechaPlanificada, decimal  _MontoPlanificado, string? _Estado)
        {


            return new CuotaPrestamo(_CuotaId, _PrestamoId, _FechaPlanificada, _MontoPlanificado, null, null, null, "Por pagar");

        }
        public void PagoCuota(DateTime? fechaEfectiva, string? _TipoModalidad, string? _ComprobantePago, string? _Estado)
        {
            FechaEfectiva = DateTime.Now;
            TipoModalidad = _TipoModalidad;
            ComprobantePago = _ComprobantePago;
            Estado = "Pagado";
        }
    }

}
