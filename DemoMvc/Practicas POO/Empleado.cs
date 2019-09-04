using System;
using System.Collections.Generic;
using System.Text;

namespace Practicas_POO
{
    public class Empleado
    {
        public Empleado(string Id, string Nombre, decimal Sueldo)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Sueldo = Sueldo;
        }
        public string Id { get; set; }
        public string Nombre { get; set; }
        public decimal Sueldo { get; private set; }

        public void IncrementaSueldo(decimal porcentaje)
        {
            if (porcentaje <= 0 || porcentaje > 100)
                throw new ArgumentException("El porcentaje no es válido");
            Sueldo = Sueldo * (1 + porcentaje / 100);
        }
    }
}
