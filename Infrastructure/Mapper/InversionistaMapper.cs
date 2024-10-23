using Domain.Entities.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper
{
    public class InversionistaMapper
    {
        public static Inversionista EfInversionistaToDomainModel(Infrastructure.Persistence.Models.Inversionistum invs)
        {
            Console.WriteLine($"ID MAPPEADO S:  {invs.InversionistaId}");
            return new Inversionista(invs.InversionistaId, invs.ClientId,invs.EstadoInversionista);

        }
    }
}