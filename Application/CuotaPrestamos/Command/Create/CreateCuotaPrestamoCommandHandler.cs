using Application.SeedOfWork;
using Domain.Entities.CuotaPrestamo;

using Domain.Entities.Prestamo;
using MediatR;
using Serilog;


namespace Application.CuotaPrestamos.Command.Create
{
public class CreateCuotaPrestamoCommandHandler : IRequestHandler<CreateCuotaPrestamoCommand>
    {
        private readonly ICuotaPrestamo _cuota;
        private readonly IPrestamo _prestamo;

        private readonly IUnitOfWork _unitOfWork;
        public CreateCuotaPrestamoCommandHandler(ICuotaPrestamo cuota, IUnitOfWork unitOfWork, IPrestamo prestamo)
        {
                _cuota = cuota;
            _unitOfWork = unitOfWork;
            _prestamo = prestamo;
        }
        public async Task Handle(CreateCuotaPrestamoCommand request, CancellationToken cancellationToken)
        {
            var prestamo = await _prestamo.GetPrestamoByIdPrestamo(request.PrestamoId);
           var lista = _prestamo.GenerarCronogramaPagos(prestamo);

            var fecha_p = lista.First().Fecha_Plazo;
            var monto = lista.First().Monto;
            Console.WriteLine($"fecha : {fecha_p}, monto : {monto}");
            
                var cuota = CuotaPrestamo.CreateCuotaDraft(
                    request.CuotaId, request.PrestamoId, fecha_p, monto, ""
                    );
            if(cuota == null)
            {
                throw new Exception("cuota null error");
            }
            Log.Information("CREATING CUOTA");
            _cuota.Create(cuota);
            await _unitOfWork.CompletedAsync(cancellationToken);
         }
    }
}

