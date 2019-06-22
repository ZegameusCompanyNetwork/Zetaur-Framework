using System;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup init = new Startup();
            init.Sec_init();
            Console.WriteLine("."); //Código de salida; Exit
        }
    }
}
