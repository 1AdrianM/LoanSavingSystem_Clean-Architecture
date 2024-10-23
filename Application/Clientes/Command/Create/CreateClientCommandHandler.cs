using Domain.Entities.Cliente;
using MediatR;
using Application.SeedOfWork;


namespace Application.Clientes.Command.Create
{
    internal class CreateClientCommandHandler : IRequestHandler<CreateClientCommand>
    {
        private readonly ICliente _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateClientCommandHandler(ICliente clienteRepository, IUnitOfWork unitOfWork) {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
        
        }
       public async Task Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            try
            { var direccion = Direccion.Create(request.Street, request.City, request.State, request.Country);

                var client = Cliente.Create(
                        0,
                    request.Cedula,
                    request.Nombre,
                    request.Apellidos,
                      request.Email,
                    request.Telefono,
                    request.TipoCliente,
                    direccion: direccion
                    );
            

                _clienteRepository.Add(client);
 
                await _unitOfWork.CompletedAsync(cancellationToken);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"ArgumentNullException: {ex.Message}");
                throw; // Opcionalmente relanza la excepción si quieres ver el stack completo
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"InvalidOperationException: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Captura cualquier otra excepción no esperada
                Console.WriteLine($"Exception: {ex.Message} - StackTrace: {ex.StackTrace}");
                throw;
            }
            
         
        }

    

       
    }
}
