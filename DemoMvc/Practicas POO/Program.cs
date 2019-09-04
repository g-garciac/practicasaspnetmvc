using System;

namespace Practicas_POO
{

    class Program
    {
        static void Main(string[] args)
        {
            var empleadoX = new Empleado("1234", "Luis", 10_000);

            empleadoX.IncrementaSueldo(100_000);

            Console.WriteLine(empleadoX.Sueldo);


            //Dominio: modelar empleados mediante un identificador único, un nombre y un sueldo mensual;

            //Ubiquitous Languaje

        }
    }
}
