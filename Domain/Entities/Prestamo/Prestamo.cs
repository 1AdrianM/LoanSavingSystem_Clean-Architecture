using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities.Prestamo
{
    public class Prestamo
    {
        public Prestamo(int prestamoId,int prestatarioId, int? fiadorId, int? garantia, string codigo, DateTime fechaSolicitud,DateTime? fechaInicio, DateTime? fechaTermino, DateTime? fechaAprobacion, decimal? monto, decimal? interes)
        {
            PrestamoId = prestamoId;
            PrestatarioId = prestatarioId;
            FiadorId = fiadorId;
            Garantia = garantia;
            CodigoPrestamo = codigo;
            FechaSolicitud = fechaSolicitud;
            FechaAprobacion = fechaAprobacion;
            FechaInicio = fechaInicio; 
            FechaTermino = fechaTermino;
            Monto = monto;
            Interes = interes;
        }

        public int PrestamoId { get; private set; }

        public int PrestatarioId { get; private set; }

        public int? FiadorId { get; private set; }

        public int?  Garantia { get; private set; }

        public string CodigoPrestamo { get; private set; }
        public TimeSpan plazo { get; private set; }
        public DateTime FechaSolicitud { get; private set; }

        public DateTime? FechaAprobacion { get; private set; }

        public DateTime? FechaInicio { get; private set; }

        public DateTime? FechaTermino { get; private set; } 
        public decimal? Monto { get; private set; }

        public decimal? Interes { get; private set; }

        // public IReadOnlyCollection<CuotaPrestamo> CuotaPrestamos => _cuotaPrestamos.AsReadOnly();



        public static Prestamo CreateSolicitud(int prestamoId, int prestatarioId, int? fiadorId, int? garantia, string codigo, DateTime fechaSolicitud, decimal? Monto, decimal? interes)
        { 
            if( prestatarioId==null|| fiadorId ==null ||codigo==null|| fechaSolicitud == null)
            {
                throw new Exception("Invalid input data");
            }

           var interesListo = GenerarInteres(interes, garantia);
            var RightNow = DateTime.Now;
            return new Prestamo(prestamoId, prestatarioId, fiadorId,garantia,codigo,RightNow,RightNow, null,null,Monto,interesListo);
        }
    public void Update(int prestamoId, int prestatarioId, int? fiadorId, int? garantia, string codigo, DateTime fechaSolicitud, DateTime? fechaInicio, DateTime? fechaTermino, DateTime? fechaAprobacion, decimal? monto, decimal? interes)
        {

        }

        public void AprobarPrestamo()
        {
            DateTime Fecha = DateTime.Now;
            if (FechaAprobacion ==null)
            {
                 FechaAprobacion = DateTime.Now;
                FechaInicio = DateTime.Now;

                FechaTermino = Fecha.AddYears(3);
            }
            else
            {
                throw new Exception("su Prestamo todavia ya ha sido aprobado");
            }
            
        }

        public static decimal GenerarInteres(decimal? interes, int? garantia)
        {
            // Tasa de interés anual en formato decimal
           // decimal tasa1Ano = 5.5m / 100;  // 0.055
            decimal tasa3Anos = 6.0m / 100;  // 0.06
            decimal tasa5Anos = 7.5m / 100;  // 0.075

          
            if(garantia != 0)
            {
                return tasa3Anos;

            }
            return tasa5Anos;
         

        }
        public void AñadirDatosPostAprobacion(DateTime fechaInicio, DateTime? fechaTermino, DateTime? fechaAprobacion) {
 
            if (FechaAprobacion!=null)
            {
                FechaInicio = fechaInicio;
                FechaAprobacion = fechaAprobacion;
                FechaTermino = fechaTermino;





            }
            else
            {
                throw new Exception("No podemos hacer esta accion, su prestamo aun no ha sido aprobado");
            }

        }


        public void GenerarCronogramaDePagos() { 
            if (FechaAprobacion != null)
            {
                TimeSpan plazo = this.FechaTermino.Value.Subtract((DateTime)FechaInicio);
                if(plazo.Days < 0)
                {
                    Console.WriteLine("plazo es menor que 0");
                }
                this.plazo = plazo;

            }

        }

        

    }
}
