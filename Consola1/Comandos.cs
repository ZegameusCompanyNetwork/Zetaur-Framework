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
        public string[] cmnd = new string[8] { "about", "clear", "conversor", "exit", "help", "hora", "fact", "teclas" };
        /*Creamos un array con nuestros comandos personalizados, 
         * recomiendo el uso de números para hacer que sea más rápido el uso del programa*/
        public void Comand () {
        init:
            string Ln_cmd = "\nIntroduce un comándo válido para continuar (teclé help para ayuda)\n";
            Console.WriteLine(Ln_cmd);
            string Cmd = Console.ReadLine();//Declaramos una variable de tipo string cuyo valor será asignado con la entrada de texto
            if(Cmd.ToLower() == cmnd[0])
            {
                About_console(); //Llamamos a un método descrito más abajo para iniciar el constructor
                goto init;
            }
            else if (Cmd.ToLower() == cmnd[1]) 
            {
                Console.Clear();//Limpiamos la pantalla            
                goto init;
            }
            else if(Cmd.ToLower()==cmnd[2])
            {
                Cmd_conversor.Cmd_prn();//Iniciamos el terminal de conversión
                goto init;
            }
            else if(Cmd.ToLower()==cmnd[3])
            {
                Application.Exit(); // Cierra la Consola
            }
            else if(Cmd.ToLower()==cmnd[4]) 
            {
                Help_console();//Llamamos al método de Help_console, programado más abajo
                goto init;
            }
            else if(Cmd.ToLower()==cmnd[5])
            {
                Console.WriteLine("Hora y Fecha: {0}\n", DateTime.Now);// Esto nos imprime la hora y la fecha en consola
                Console.WriteLine("Hora y Fecha personalizado: {0}\n", DateTime.Now.ToString("hh:mm:ss.fff dd-MM-yy")); //Aquí podemos establecer como se va ha mostrar la hora
                Console.WriteLine("Hora y Fecha - UTC: {0}\n", DateTime.UtcNow.ToString("hh:mm:ss.fff dd/MM/yyyy"));//Las 3 f son para los milisegundos
                Console.WriteLine("Solo la hora: {0}\n", DateTime.Now.ToString("hh:mm:ss")); //Esto nos imprime solo la hora
                Console.Write("Solo la Fecha: {0}\n", DateTime.Now.ToString("dd/MM/yyyy")); //Esto nos imprime solo la fecha
                goto init;
            }
            else if(Cmd.ToLower()==cmnd[6])
            {
                
                Permcombrep perm = new Permcombrep();
                perm.Factorial();
                goto init;

            }
            else if (Cmd.ToLower()==cmnd[7])
            {
                Teclas teclas = new Teclas(); //llamamos a la clase Teclas
                teclas.Wkeytouch();
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
        public void Help_console()
        {
            Console.ForegroundColor = ConsoleColor.Green; //cambia el color de letra a verde claro
            Console.WriteLine("Los comandos disponibles para esta app son:\n");
            Console.WriteLine("{0}: Muestra información sobre la app.", cmnd[0]);//Donde pone {0}, será remplazado por el contenido de cmnd[0]
            Console.WriteLine("{0}: limpia la pantalla.", cmnd[1]);
            Console.WriteLine("{0}: Le cambia a la consola de conversores", cmnd[2]);
            Console.WriteLine("{0}: Sale del programa.", cmnd[3]);
            Console.WriteLine("{0}: Muestra la ayuda.", cmnd[4]);
            Console.WriteLine("{0}: Muestra la hora", cmnd[5]);
            Console.WriteLine("{0}: inicia una calculadora de factoriales", cmnd[6]);
            Console.WriteLine("{0}: Muestra una interfaz que permite saber que teclas pulsas", cmnd[7]);
            //Aquí añades tus propios comandos
        }
    }
}
