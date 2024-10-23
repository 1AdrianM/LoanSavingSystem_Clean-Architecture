using Domain.Entities.CuotaPrestamo;
using Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper
{
    public class CuotaPrestamoMapper
    {
        public static Domain.Entities.CuotaPrestamo.CuotaPrestamo ToEfModel(Infrastructure.Persistence.Models.CuotaPrestamo model)
        {
            return new Domain.Entities.CuotaPrestamo.CuotaPrestamo(
            
                model.CuotaId,
                model.PrestamoId,
                 model.FechaPlanificada,
                 model.MontoPlanificado,
                 model.FechaEfectiva,
                 model.TipoModalidad,
                  model.ComprobantePago,
                 model.Estado
                
                 
                
            );

        }
        public static Persistence.Models.CuotaPrestamo  ToDomainModel(Domain.Entities.CuotaPrestamo.CuotaPrestamo model)
        {
            DateTime date = model.FechaPlanificada;
            decimal monto = model.MontoPlanificado;



            return new Persistence.Models.CuotaPrestamo {
                
                CuotaId = model.CuotaId,
                PrestamoId = model.PrestamoId,
                FechaPlanificada = date,
                MontoPlanificado = monto,
                FechaEfectiva = model.FechaEfectiva,
                TipoModalidad = model.TipoModalidad,
                ComprobantePago = model.ComprobantePago,
                Estado = model.Estado
            };

        }
    }
}
