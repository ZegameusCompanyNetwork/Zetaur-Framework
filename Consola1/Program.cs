using System;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Consola de Prueba"; //Establecemos un título a nuestra consola
            Startup init = new Startup();
            init.Sec_init(); //Iniciamos la clase Startup en el método "Sec_init"
        }
    }
}
