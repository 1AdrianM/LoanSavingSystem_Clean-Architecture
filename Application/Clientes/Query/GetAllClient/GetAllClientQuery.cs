using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clientes.Query.GetAllClient
{
    public record GetAllClientQuery:IRequest<List<ClientListResponse>>;
   
    
    
    
}
