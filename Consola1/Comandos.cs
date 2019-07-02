using System; //Declaramos que usamos la libreria System

namespace Consola
{
    class Comandos
    {
        public void Comand () {
        init: //Declraramos un label para poder crear un bucle con goto
            string Ln_cmd = "Introduce un comándo válido para continuar (teclé help para ayuda)\n";
            Console.WriteLine(Ln_cmd);
            string Cmd = Console.ReadLine();//Declaramos una variable de tipo string cuyo valor será asignado con la entrada de texto
            if(Cmd == "help"){
                Help_console(); //Llamamos al método de Help_console, programado más abajo
                goto init;
            }
            else if(Cmd == "about") 
            {
                About_console(); //Llamamos al método descrito más abajo para inciar el constructor
                goto init;
            }
            else if(Cmd == "exit")
            {
                Console.Write("."); //Imprime un punto y se cierra la consola al no haber ninguna otra acción después
            }
            else
            {
                Console.WriteLine("Comando no encontrado");
                goto init;
            }
        }
        public static void Help_console(){
            Console.ForegroundColor = ConsoleColor.Green; //cambia el color de letra a verde claro
            Console.WriteLine("Los comandos disponibles para esta app son:\n");
            Console.WriteLine("help: Muestra esta ayuda.");
            Console.WriteLine("about: Muestra información sobre la app.");
            Console.WriteLine("exit: Sale del programa");
            //Aquí añades tus propios comandos
        }
        public static void About_console()
        {
            Console.Clear(); //Limpiamos el texto de la consola
            Console.ForegroundColor = ConsoleColor.Green; //Cambiamos el color de texto a verde
            Console.WriteLine("Programa creado y desarroyado por Zegameus Co. (ZCNR)");
            Console.WriteLine("(c)Zegameus Company Network Records\nConsola de Prueba.");
            Console.WriteLine("Pulsa Cualquier tecla para continuar");
            Console.ReadKey();//espera hasta que se pulse una tecla
        }
    }
}
