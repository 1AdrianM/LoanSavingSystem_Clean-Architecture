using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Prestamo
{
    public class PrestamoNotFoundException:Exception
    {
        public PrestamoNotFoundException(string Id):base($"The prestamo with the ID = {Id} was not found") { 
        
        }
    }
}
