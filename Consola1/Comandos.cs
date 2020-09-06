/*#########################################################
 *#    Copyright 2019 Zegameus Company Network Records    #
 *#                     Licencia MIT                      #
 *#########################################################
 */
using System;

namespace Zetaur
{
    class Comandos
    {
        public string[] cmnd = new string[9] { "about", "clear", "conv", "exit", "salir", "help", "hora", "fact", "teclas" };
        /*Creamos un array con nuestros comandos personalizados, 
         * recomiendo el uso de números para hacer que sea más rápido el uso del programa*/
        public void Comand()
        {
            bool r = true;
            while (r)
            {
                string Ln_cmd = "\nIntroduce un comándo válido para continuar (teclé help para ayuda)\n>> ";
                Console.Write(Ln_cmd);
                string Cmd = Console.ReadLine();//Declaramos una variable de tipo string cuyo valor será asignado con la entrada de texto
                if (Cmd.ToLower() == cmnd[0])
                {
                    About_console(); //Llamamos a un método descrito más abajo para iniciar el constructor
                    r = true;
                }
                else if (Cmd.ToLower() == cmnd[1])
                {
                    Console.Clear();//Limpiamos la pantalla
                    r = true;
                }
                else if (Cmd.ToLower() == cmnd[2])
                {
                    Cmd_conversor.Cmd_prn();//Iniciamos el terminal de conversión
                    r = true;
                }
                else if (Cmd.ToLower() == cmnd[3] || Cmd.ToLower() == cmnd[4])//comara si el valor de entrada es igual a cmnd[3] o a cmnd[4]
                {
                    r = false;
                    System.Windows.Forms.Application.Exit(); // Cierra la Consola
                }
                else if (Cmd.ToLower() == cmnd[5])
                {
                    Help_console();//Llamamos al método de Help_console, programado más abajo
                    r = true;
                }
                else if (Cmd.ToLower() == cmnd[6])
                {
                    Console.WriteLine($"Hora y Fecha: {DateTime.Now}\n");// Esto nos imprime la hora y la fecha en consola
                    Console.WriteLine($"Hora y Fecha personalizado: {DateTime.Now:hh:mm:ss.fff dd-MM-yy}"); //Aquí podemos establecer como se va ha mostrar la hora
                    Console.WriteLine($"Hora y Fecha - UTC: {DateTime.UtcNow:hh:mm:ss.fff dd/MM/yyyy}");//Las 3 f son para los milisegundos
                    Console.WriteLine($"Solo la hora: {DateTime.Now:hh:mm:ss}"); //Esto nos imprime solo la hora
                    Console.Write($"Solo la Fecha: {DateTime.Now:dd / MM / yyyy}"); //Esto nos imprime solo la fecha
                    r = true;
                }
                else if (Cmd.ToLower() == cmnd[7])
                {
                    Permcombrep perm = new Permcombrep();
                    perm.Factorial();
                    r = true;

                }
                else if (Cmd.ToLower() == cmnd[8])
                {
                    Teclas teclas = new Teclas(); //llamamos a la clase Teclas
                    teclas.Wkeytouch();
                    r = true;
                }
                else //En caso de que el comando introducido no sea identificado imprimimos un texto en pantalla
                {
                    Console.WriteLine("Comando no encontrado");
                    r = true;
                }
            }
        }
        /// <summary>
        /// Método de información sobre la aplicación.
        /// </summary>
        public static void About_console()
        {
            const string msg_about = "Esta aplicación de consola le permitira ver la hora y fecha actual en diferentes formatos,\nsaber que combinaciones de teclas pulsas, convertir unidades de longitud, temperatura, masa, presión; etc.";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Programa creado y desarroyado por Zegameus Co. (ZCNR)");
            Console.WriteLine("(c)Zegameus Company Network Records\nConsola de Prueba.");
            Console.WriteLine(msg_about);
            Console.WriteLine("Pulsa Cualquier tecla para continuar");
            Console.ReadKey();//espera hasta que se pulse una tecla
        }
        /// <summary>
        /// Método que devuelve un listado de comandos disponibles y su función.
        /// </summary>
        public void Help_console()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Los comandos disponibles para esta app son:\n");
            Console.WriteLine($"{cmnd[0]}: Muestra información sobre la app.");
            Console.WriteLine($"{cmnd[1]}: limpia la pantalla.");
            Console.WriteLine($"{cmnd[2]}: Le cambia a la consola de conversores");
            Console.WriteLine($"{cmnd[3]} o {cmnd[4]}: Sale del programa.");
            Console.WriteLine($"{cmnd[5]}: Muestra la ayuda.");
            Console.WriteLine($"{cmnd[6]}: Muestra la hora");
            Console.WriteLine($"{cmnd[7]}: inicia una calculadora de factoriales");
            Console.WriteLine($"{cmnd[8]}: Muestra una interfaz que permite saber que teclas pulsas");
            //Aquí añadirías tus propios comandos
        }
    }
}
