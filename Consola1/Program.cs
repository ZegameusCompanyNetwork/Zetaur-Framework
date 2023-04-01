using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace Zetaur
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Zetaur"; //Establecemos un título a nuestra consola
            const string line = "(c) Zegameus Company Network Records\nZetaur.";
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
