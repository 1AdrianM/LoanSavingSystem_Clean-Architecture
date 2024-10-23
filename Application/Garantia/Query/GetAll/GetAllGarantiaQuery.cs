using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Garantia.Query.GetAll
{
    public record GetAllGarantiaQuery:IRequest<List<GarantiaResponse>>;
    
    
}
