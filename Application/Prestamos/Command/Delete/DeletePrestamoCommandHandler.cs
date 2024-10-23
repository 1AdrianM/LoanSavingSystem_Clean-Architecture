using Application.SeedOfWork;
using Domain.Entities.Prestamo;
using MediatR;
 

namespace Application.Prestamos.Command.Delete
{
  public class DeletePrestamoCommandHandler : IRequestHandler<DeletePrestamoCommand>
    {
        private readonly IPrestamo _prestamo;

        private readonly IUnitOfWork _unitOfWork;

         public DeletePrestamoCommandHandler(IUnitOfWork unitOfWork, IPrestamo prestamo)
        {
            _unitOfWork = unitOfWork;
            _prestamo = prestamo;
        }

        public async Task Handle(DeletePrestamoCommand request, CancellationToken cancellationToken)
        {
            var prestamo = await _prestamo.GetPrestamoByCodigoPrestamo(request.Codigo);
            _prestamo.Delete(prestamo);
           await _unitOfWork.CompletedAsync(cancellationToken);
        }
    }
}
