using Domain.Entities.Cliente;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clientes.Query.Get
{
    public record ClientReponse(
      [Required(ErrorMessage = "El campo ClientId es obligatorio.")]
    int ClientId,

    [Required(ErrorMessage = "El campo Cédula es obligatorio.")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "La cédula debe tener 11 caracteres.")]
    string Cedula,

    [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
    [StringLength(40, ErrorMessage = "El nombre no debe superar los 40 caracteres.")]
    string Nombre,

    [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
    [StringLength(40, ErrorMessage = "El apellido no debe superar los 40 caracteres.")]
    string Apellido,

    [EmailAddress(ErrorMessage = "Debe ser un email válido.")]
    string Email,

       [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener 10 dígitos.")]
    string Telefono,

    [Required(ErrorMessage = "Debe ser un tipo de cliente válido.")]
    TipoCliente TipoCliente,

    [Required(ErrorMessage = "El campo Dirección es obligatorio.")]
    Direccion Direccion

 
        ) : IRequest
    {
       

       

      
    }
}
