/*#########################################################
 *#    Copyright 2019 Zegameus Company Network Records    #
 *#                     Licencia MIT                      #
 *#########################################################
 */
using System;
using System.Windows.Forms;

namespace Consola
{
    class Comandos
    {
        public void Comand () {
        init:
            string Ln_cmd = "\nIntroduce un comándo válido para continuar (teclé help para ayuda)\n";
            Console.WriteLine(Ln_cmd);
            string Cmd = Console.ReadLine();//Declaramos una variable de tipo string cuyo valor será asignado con la entrada de texto
            if(Cmd == "help"){
                Help_console();//Llamamos al método de Help_console, programado más abajo
                goto init;
            }
            else if(Cmd == "about") 
            {
                About_console(); //Llamamos a un método descrito más abajo para iniciar el constructor
                goto init;
            }
            else if(Cmd == "exit")
            {
                Application.Exit(); // Cierra la Consola
            }
            else if(Cmd == "hora")
            {
                Console.WriteLine("Hora y Fecha: {0}\n", DateTime.Now);// Esto nos imprime la hora y la fecha en consola
                Console.WriteLine("Solo la hora: {0}\n", DateTime.Now.ToString("hh:mm:ss")); //Esto nos imprime solo la hora
                Console.WriteLine("Solo la Fecha: {0}\n", DateTime.Now.ToString("dd/MM/yyyy")); //Esto nos imprime solo la fecha
                Console.ReadKey();
                goto init;
            }
            else if(Cmd == "teclas"){
                Teclas teclas = new Teclas(); //llamamos a la clase Teclas
                teclas.Wkeytouch();
                goto init;
            }
            else if (Cmd == "permutaciones")
            {
                Permcombrep perm = new Permcombrep();
                perm.Factorial();
                goto init;
            }
            else if (Cmd == "clear") 
            {
                Console.Clear();                
                goto init;
            }
            else if(Cmd == "conversor")
            {
                Cmd_conversor.Cmd_prn();
                goto init;
            }
            else //En caso de que el comando introducido no sea identificado imprimimos un texto en pantalla
            {
                Console.WriteLine("Comando no encontrado");
                goto init;
            }
        }
        public static void About_console()
        {
            const string msg_about = "Esta aplicación de consola le permitira ver la hora y fecha actual, saber que combinaciones de teclas pulsas, etc.";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Programa creado y desarroyado por Zegameus Co. (ZCNR)");
            Console.WriteLine("(c)Zegameus Company Network Records\nConsola de Prueba.");
            Console.WriteLine(msg_about);
            Console.WriteLine("Pulsa Cualquier tecla para continuar");
            Console.ReadKey();//espera hasta que se pulse una tecla
        }
        public static void Help_console()
        {
            Console.ForegroundColor = ConsoleColor.Green; //cambia el color de letra a verde claro
            Console.WriteLine("Los comandos disponibles para esta app son:\n");
            Console.WriteLine("help: Muestra esta ayuda.");
            Console.WriteLine("clear: limpia la pantalla.");
            Console.WriteLine("conversor: Le cambia a la consola de conversores");
            Console.WriteLine("about: Muestra información sobre la app.");
            Console.WriteLine("hora: Muestra la hora.");
            Console.WriteLine("permutaciones: inicia una calculadora de factoriales");
            Console.WriteLine("teclas: Muestra una interfaz que permite saber que teclas pulsas");
            Console.WriteLine("exit: Sale del programa.");
            //Aquí añades tus propios comandos
        }
    }
}
