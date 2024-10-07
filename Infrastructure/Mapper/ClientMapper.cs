using Domain.Entities.Cliente;
using Infrastructure.Persistence.Models;
using Microsoft.IdentityModel.Tokens;

public static class ClienteMapper
{
    public static Infrastructure.Persistence.Models.Cliente ToEfModel(Domain.Entities.Cliente.Cliente domainCliente)
    {
        Console.WriteLine("INICIO DE MAPEO EFMODEL");
        Console.WriteLine(domainCliente.TipoCliente);
        var clientEF = new Infrastructure.Persistence.Models.Cliente
        {
            ClientId = domainCliente.ClientId,
            Cedula = domainCliente.Cedula,
            Nombre = domainCliente.Nombre,
            Email = domainCliente.Email,
            Apellido = domainCliente.Apellidos,
            Direccion = domainCliente.Direccion?.ToString(),
            Telefono = domainCliente.Telefono
        };

        var (prestatario, inversionista, fiador) = ClientTypeSelector(domainCliente, clientEF);

        // Asignar según el tipo de cliente
        if (prestatario != null)
            clientEF.Prestatarios.Add(prestatario);

        if (inversionista != null)
            clientEF.Inversionista.Add(inversionista);

        if (fiador != null)
            clientEF.Fiador = fiador;
        Console.WriteLine("Retorna objecto EF");

        return clientEF;
    }



public static Domain.Entities.Cliente.Cliente ToDomainModel(Infrastructure.Persistence.Models.Cliente efCliente)
    {
        Console.WriteLine("INICIO DE MAPPING DOMAIN MODEL");

        Direccion ObjDir =EfDireccionToDomainDireccion(direccion: efCliente.Direccion);
        var tipoCliente = InferTipoCliente(efCliente);
        Console.WriteLine("Mapping Domain model");

        return Domain.Entities.Cliente.Cliente.Create(
            efCliente.ClientId,
            efCliente.Cedula,
            efCliente.Nombre,
            efCliente.Apellido,
            efCliente.Email ?? "",
            efCliente.Telefono,
            tipoCliente.ToString(), // Replace with actual logic to get TipoCliente
            ObjDir // Adjust as necessary
        );
    }

    public static Direccion EfDireccionToDomainDireccion(string direccion)
    {
        if (string.IsNullOrWhiteSpace(direccion)) return new Direccion("", "", "", "");

        string[] newDireccion = direccion.Split(',');
        return newDireccion.Length == 4
            ? new Direccion(newDireccion[0], newDireccion[1], newDireccion[2], newDireccion[3])
            : new Direccion("", "", "", "");
    }
    private static TipoCliente InferTipoCliente(Infrastructure.Persistence.Models.Cliente efCliente)
    {


        if (efCliente.Prestatarios.Any())
            return TipoCliente.Prestatario;
        else if (efCliente.Inversionista.Any())
            return TipoCliente.Inversionista;
        else if (efCliente.Fiador != null)
        {   return TipoCliente.Fiador;
        }else
            throw new ArgumentException("No se pudo inferir el tipo de cliente a partir del modelo EF.");
    }
    public static (Prestatario? prestatario, Inversionistum? inversionista, Fiador? fiador) ClientTypeSelector(Domain.Entities.Cliente.Cliente domainCliente, Infrastructure.Persistence.Models.Cliente clientEF)
    {
        return domainCliente.TipoCliente.ToString().ToLower() switch
        {
            "prestatario" => (
                new Prestatario
                {
                    PrestatarioId = 0,
                    Client = clientEF,
                    CantidadPrestamos = null
                },
                null, // No se asigna inversionista
                null  // No se asigna fiador
            ),
            "inversionista" => (
                null, // No se asigna prestatario
                new Inversionistum
                {
                    InversionistaId = 0,
                    Client = clientEF
                },
                null  // No se asigna fiador
            ),
            "fiador" => (
                null, // No se asigna prestatario
                null, // No se asigna inversionista
                new Fiador
                {
                    FiadorId = 0,
                    Client = clientEF,
                    Estado = null
                }
            ),
            _ => throw new ArgumentException($"Tipo de cliente no soportado: {domainCliente.TipoCliente}")
        };
    }

}
