using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Garantia
{
    public class Garantias {
        public int GarantiaId { get; set; }
        public string TipoGarantia { get; set; }
        public decimal? Valor { get; set; }
        public string Ubicacion { get; set; } 
        public Garantias(int garantiaId,  string tipoGarantia, decimal? valor, string ubicacion)
    {
            GarantiaId = garantiaId;
            TipoGarantia = tipoGarantia;
            Valor =  valor;
            Ubicacion = ubicacion;
    }
        public Garantias()
        {

        }
    }
    } 
   
