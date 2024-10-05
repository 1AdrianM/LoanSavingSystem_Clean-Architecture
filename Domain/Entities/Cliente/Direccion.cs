using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Entities.Cliente
{
    public record Direccion(string Street, string City, string State, string Country)

    {
    public static Direccion? Create(string street, string city, string state, string country)
        {
            if(string.IsNullOrEmpty(street)|| string.IsNullOrEmpty(city)|| string.IsNullOrEmpty(state)|| string.IsNullOrEmpty(country)) {

                return null;
             }
            return new Direccion(street, city,state,country);

        }
    public override string ToString()
    {
        return $"{Street}, {City}, {State}, {Country}";
    }
}
}
