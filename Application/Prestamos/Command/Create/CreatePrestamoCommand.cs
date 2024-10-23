using Domain.Entities.Prestamo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Prestamos.Command.Create
{
    public record CreatePrestamoCommand(
    
    int PrestatarioId,
    int Fiador,
    int GarantiaId,
    DateTime FechaSolicitud,
    decimal Monto


        ):IRequest;
}
