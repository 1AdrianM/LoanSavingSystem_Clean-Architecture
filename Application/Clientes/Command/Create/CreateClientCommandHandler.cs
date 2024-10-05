using Domain.Entities.Cliente;
using MediatR;
using Application.SeedOfWork;


namespace Application.Clientes.Command.Create
{
    internal class CreateClientCommandHandler : IRequestHandler<CreateClientCommand>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateClientCommandHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork) {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
        
        }
       public async Task Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            
            Console.WriteLine("Llmando command handler");

            try
            { var direccion = Direccion.Create(request.Street, request.City, request.State, request.Country);

                var client = Cliente.Create(
                 request.ClientId,
                    request.Cedula,
                    request.Nombre,
                    request.Apellidos,
                      request.Email,
                    request.Telefono,
                    request.TipoCliente,
                    direccion: direccion
                    );
                Console.WriteLine(client);
                Console.WriteLine("Adding command handler");

                _clienteRepository.Add(client);
                Console.WriteLine("Unit of work command handler");

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
