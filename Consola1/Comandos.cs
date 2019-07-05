using System; //Declaramos que usamos la libreria System
using System.Windows.Forms;

namespace Consola
{
    class Comandos
    {
        public void Comand () {
        init: //Declraramos un label para poder crear un bucle con goto
            string Ln_cmd = "\nIntroduce un comándo válido para continuar (teclé help para ayuda)\n";
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
                Application.Exit(); // Cierra la Consola
            }
            else if(Cmd == "hora")
            {
                Console.WriteLine("Hora y Fecha: {0}\n", DateTime.Now);// Esto nos imprime la hora y la fecha en consola
                Console.WriteLine("Solo la hora: {0}\n", DateTime.Now.ToString("h:mm:ss")); //Esto nos imprime solo la hora
                Console.WriteLine("Solo la Fecha: {0}\n", DateTime.Now.ToString("dd/MM/yyyy")); //Esto nos imprime solo la fecha
                Console.ReadKey();
                goto init;
            }
            else if(Cmd == "teclas"){
                Teclas teclas = new Teclas(); //llamamos a la clase Teclas
                teclas.Wkeytouch();
                goto init;
            }
            else
            {
                Console.WriteLine("Comando no encontrado");
                goto init;
            }
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
