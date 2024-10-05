using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Entities.Cliente
{
    public class Cliente
    {
        public int ClientId { get; private set; }
        public string Cedula { get; private set; }
        public string Nombre { get; private set; }
        public  string Apellidos { get; private set; }

        public string  Email { get; private set; }

        public Direccion Direccion {get; private set;}
        public string Telefono { get; private set; }

        public TipoCliente TipoCliente { get; private set; }


        public Cliente(int clientId,string cedula, string nombre, string apellidos, string email, string telefono, TipoCliente tipoCliente, Direccion direccion) {
            ClientId = clientId;
            Cedula = cedula;
            Nombre= nombre;
            Apellidos = apellidos;
            Email = email;

            Telefono = telefono;
            TipoCliente = tipoCliente;
            Direccion= direccion;

        }

      

        // Método estático de registro (fábrica) para crear una instancia de Cliente

        public static  Cliente Create(int clientId, string cedula, string nombre, string apellidos, string email, string telefono, string tipoCliente, Direccion direccion)
        {
             ValidarDatos(nombre, apellidos, email, telefono);
          
            if ( direccion == null  || string.IsNullOrEmpty(tipoCliente) || string.IsNullOrEmpty(cedula)  || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellidos) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(telefono))
            {
                throw new ArgumentException("son obligatorios para registrar un cliente.");
            }
            TipoCliente newTipoCliente = ParseTipoCliente(tipoCliente);

            return new Cliente(clientId,
                               cedula,
                               nombre,
                               apellidos,
                               email,
                               telefono,
                               newTipoCliente,
                               direccion);
        }

        public void Update(string cedula, string nombre, string apellidos, string email, string telefono, TipoCliente tipoCliente, Direccion direccion)
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellidos = apellidos;
            Email = email;
            Telefono = telefono;
            TipoCliente = tipoCliente;
            Direccion = direccion;
        }
            // Método de validación de datos
            private static void ValidarDatos(string nombre, string apellidos, string email, string telefono)
        {
            // Verificar que el nombre y apellidos no estén vacíos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellidos))
                throw new ArgumentException("El nombre y los apellidos son obligatorios.");
            // Verificar que el formato del email sea válido
            if (!EsEmailValido(email))
                throw new ArgumentException("El formato del email no es válido.");
            // Verificar que el teléfono contenga solo números y una longitud adecuada (ejemplo: 8-15 dígitos)
            if (!Regex.IsMatch(telefono, @"^\d{8,15}$"))
                throw new ArgumentException("El número de teléfono debe contener entre 8 y 15 dígitos.");
        }
        // Validación de email utilizando Regex
        private static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            // Patrón Regex básico para validar la estructura de un email
            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, patronEmail);
        }

        private static TipoCliente ParseTipoCliente(string tipo)
        {
            return tipo.ToLower() switch
            {
                "prestatario" => TipoCliente.Prestatario,
                "fiador" => TipoCliente.Fiador,
                "inversionista" => TipoCliente.Inversionista,
                _ => throw new ArgumentException($"Tipo de cliente '{tipo}' no es válido.")
            };
        }
    }
}
