using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Prestamos.Command.Approved
{
   public record ApprovedPrestamoCommand(string id):IRequest;

}
