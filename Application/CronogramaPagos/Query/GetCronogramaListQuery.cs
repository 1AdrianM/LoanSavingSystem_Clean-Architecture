using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CronogramaPagos.Query
{
    public record GetCronogramaListQuery(Guid id):IRequest<List<CronogramaResponse>>;
    
    
}
