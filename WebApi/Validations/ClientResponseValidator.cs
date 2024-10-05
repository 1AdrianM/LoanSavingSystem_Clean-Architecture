using Application.Clientes.Query.Get;
using FluentValidation;

public class ClientResponseValidator : AbstractValidator<ClientReponse>
{
    public ClientResponseValidator()
    {
        RuleFor(x => x.Cedula)
            .NotEmpty().WithMessage("La cédula es obligatoria.")
            .Length(11).WithMessage("La cédula debe tener 11 caracteres.");

        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .MaximumLength(40).WithMessage("El nombre no debe superar los 40 caracteres.");

        RuleFor(x => x.Apellido)
            .NotEmpty().WithMessage("El apellido es obligatorio.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("El email es obligatorio.")
            .EmailAddress().WithMessage("Debe ser un email válido.");

        RuleFor(x => x.Direccion)
            .NotEmpty().WithMessage("La dirección es obligatoria.");

        RuleFor(x => x.Telefono)
            .Matches(@"^\d{10}$").WithMessage("El teléfono debe tener 10 dígitos.");
    }
}
