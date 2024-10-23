using Domain.Entities.Garantia;
using Domain.Entities.Prestamo;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper
{
    public class PrestamoMapper
    {
        public static Infrastructure.Persistence.Models.Prestamo PrestamoDomainToEF(Prestamo DomainPrestamo)
        {
            var fiador = DomainPrestamo.FiadorId;
            var garantia = DomainPrestamo.Garantia;
           var prestatario = DomainPrestamo.PrestatarioId;

            var prestamoEF = new Persistence.Models.Prestamo()
            {
                PrestamoId = DomainPrestamo.PrestamoId,
              PrestatarioId = prestatario,
                FiadorId = fiador,
                GarantiaId = garantia,
                CodigoPrestamo = DomainPrestamo.CodigoPrestamo,
                FechaSolicitud = DomainPrestamo.FechaSolicitud,
                FechaAprobacion = DomainPrestamo.FechaAprobacion,
                FechaInicio = DomainPrestamo.FechaInicio,
                FechaTermino = DomainPrestamo.FechaTermino,
                Monto = DomainPrestamo.Monto,
                Interes = DomainPrestamo.Interes,

            };

            return prestamoEF;

        }

        public static Domain.Entities.Prestamo.Prestamo PrestamoEFtoDomain(Persistence.Models.Prestamo PrestamoEF)
        {
                int? garantia = PrestamoEF.GarantiaId;
          
       
            return new Domain.Entities.Prestamo.Prestamo(

             PrestamoEF.PrestamoId,
             PrestamoEF.PrestatarioId,
             PrestamoEF.FiadorId,
             garantia,
              PrestamoEF.CodigoPrestamo,
             PrestamoEF.FechaSolicitud,
             PrestamoEF.FechaInicio,
             PrestamoEF.FechaTermino,
             PrestamoEF.FechaAprobacion,
             PrestamoEF.Monto,
             PrestamoEF.Interes
            );
            


        }
    }
}
