using Domain.Entities.Cliente;
using Domain.Entities.Prestatario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper
{
   public class PrestatarioMapper
    {
        public static Prestatario EfPrestamoToDomainModel(Infrastructure.Persistence.Models.Prestatario prestatario)
        {
            Console.WriteLine($"ID MAPPEADO S:  {prestatario.PrestatarioId} , Client id {prestatario.ClientId}");
            return new Prestatario(
                prestatario.PrestatarioId,
                prestatario.ClientId,
                prestatario.EstadoPrestatario,
                prestatario.CantidadPrestamos);

        }
    }
}
