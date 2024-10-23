using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Garantia.Query.GetById
{
   public record GetGarantiaByQuery(int Id): IRequest<GarantiaIdResponse>;
    
    
}
