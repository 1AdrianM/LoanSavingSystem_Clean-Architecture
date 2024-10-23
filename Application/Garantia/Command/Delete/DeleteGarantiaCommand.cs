using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Garantia.Command.Delete
{
  public record DeleteGarantiaCommand(int Id):IRequest;
    
    
}
