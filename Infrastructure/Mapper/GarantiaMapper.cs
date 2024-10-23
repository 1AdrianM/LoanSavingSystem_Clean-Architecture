using Domain.Entities.Garantia;
using Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper
{
    public class GarantiaMapper
    {
        public static Garantium DomainGarantiaToEfGarantium(Garantias garantia)
        {
            return new Garantium
            {

                GarantiaId = garantia.GarantiaId,
                TipoGarantia = garantia.TipoGarantia,
                Valor = garantia.Valor,
                Ubicacion = garantia.Ubicacion
            };

        }

        
        public static Garantias EFGarantiumToDomainGarantium(Garantium garantia)
        {
            var garantiaObj = new Garantias();

            garantiaObj.GarantiaId = garantia.GarantiaId;
            garantiaObj.TipoGarantia = garantia.TipoGarantia;
            garantiaObj.Valor = garantia.Valor;
            garantiaObj.Ubicacion = garantia.Ubicacion;
            return garantiaObj;
        ;

        }
    }
}
