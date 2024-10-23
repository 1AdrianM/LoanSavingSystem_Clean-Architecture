using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Prestamos.Command.Delete
{
public record DeletePrestamoCommand(string Codigo):IRequest;
    
    
}
