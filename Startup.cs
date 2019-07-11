using System;
using System.Threading.Tasks;

namespace Consola
{
    class Startup
    {
        public void Sec_init()
        {
            const string line = "(c) Zegameus Company Network Records\nConsola de Prueba.";
            Console.ForegroundColor = ConsoleColor.Green; //Cambiamos el color de letra a verde
            Console.WriteLine(line);
            Console.WriteLine("\nCargando");
            Task.Delay(3000);
            Console.WriteLine("\nCargado con éxito");
            //Ahora declaramos un nombre directo a una clase de otro archivo
            Comandos cmd = new Comandos();
            cmd.Comand();
        }
    }
}
