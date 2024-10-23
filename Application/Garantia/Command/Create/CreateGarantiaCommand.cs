using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Garantia.Command.Create
{
    public record CreateGarantiaCommand(
           int GarantiaId ,
     string TipoGarantia ,
     decimal? Valor ,
    string Ubicacion  ):IRequest;
     
}
