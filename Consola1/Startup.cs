using System;
using System.Collections.Generic;
using System.Text;

namespace Consola
{
    class Startup
    {
        public void Sec_init()
        {
            const string line = "(c) Zegameus Company Network Records\nConsola de Prueba.";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(line);
            Comandos cmd = new Comandos();
            cmd.Comand();
        }
    }
}
