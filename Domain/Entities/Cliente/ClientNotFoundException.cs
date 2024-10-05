
using   System;
namespace Domain.Entities.Cliente
{
    public sealed class ClientNotFoundException : Exception
    {
        public ClientNotFoundException()
        {

        }
        public ClientNotFoundException(ClientId id)
        : base($"The product with the ID = {id.id} was not found")
        {
        }

    }
}
    
    

