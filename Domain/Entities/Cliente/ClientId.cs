using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Cliente
{
    public record ClientId(Guid id)
    {
   public static ClientId GetId(ClientId id)
    {
        return new ClientId(id);
    } 
}
}
