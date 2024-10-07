
using   System;
namespace Domain.Entities.Cliente
{
    public sealed class ClientNotFoundException : Exception
    {
        public ClientNotFoundException()
        {

        }
        public ClientNotFoundException(int id)
        : base($"The product with the ID = {id} was not found")
        {
        }

    }
}
    
    

