using System;

namespace Consola
{
    class Comandos
    {
        public void Comand () {
        init:
            string Ln_cmd = "Introduce un comándo válido para continuar (teclé help para ayuda)\n";
            Console.WriteLine(Ln_cmd);
            string Cmd = Console.ReadLine();//Declaramos una variable de tipo string cuyo valor será asignado con la entrada de texto
            if(Cmd == "help"){
                Console.ForegroundColor = ConsoleColor.Green; //cambia el color de letra a verde claro
                Console.WriteLine("Los comandos disponibles para esta app son:\n");
                Console.WriteLine("help: Muestra esta ayuda.");
                Console.WriteLine("about: Muestra información sobre la app.");
                Console.WriteLine("exit: Sale del programa");
                //Aquí añades tus propios comandos
                goto init;
            }
            else if(Cmd == "about") 
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Programa creado y desarroyado por Zegameus Co. (ZCNR)\n");
                Console.WriteLine("(c)Zegameus Company Network Records\nConsola de Prueba.");
                Console.WriteLine("Pulsa Cualquier tecla para continuar");
                Console.ReadKey();//espera hasta que se pulse una tecla
                goto init;
            }
            else if(Cmd == "exit")
            {
                Console.Write(".");
            }
            else
            {
                Console.WriteLine("Comando no encontrado");
            }
        }
    }
}
