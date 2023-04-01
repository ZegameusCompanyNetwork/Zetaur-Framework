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
        /// <summary>
        /// Método principal del programa.
        /// Recibe un conjunto de argumentos, el cual puede ser nulo.
        /// Posibles argumentos:
        /// <list type="bullet">
        /// <item>conf_en [true/false]: representa si hay un archivo de configuración y este está cargado.</item>
        /// <item>sh_help [true/false]: activa o desactiva la opción de mostrar siempre los comandos cada vez que se accede al metodo Comand</item>
        /// </list>
        /// </summary>
        /// <param name="args"></param>
        public void Comand(params string[] args)
        {
            bool sh_help=false;
            //Añadir un bucle para comprobar si en el archivo de config esta puesto sh_help como true
            if (args.Length != 0 && args.Length >=2)
            {
                if(args[0] == "true")
                {
                    if (args[1] == "true")
                    {
                        sh_help=true;
                    }
                    else
                    {
                        sh_help=false;
                    }
                }
                else
                {
                    return;
                }
            }
            else//No se ha pasado ningun argumento
            {
                sh_help=false;
            }


            //Lectura del comando del usuario

            bool r = true;
            while (r)
            {
                
                if (sh_help == true)
                {
                    Help_console();
                    Console.Write("\nIntroduce un comándo válido para continuar\n>>");
                }
                else {
                    string Ln_cmd = "\nIntroduce un comándo válido para continuar (teclé help para ayuda)\n>> ";
                    Console.Write(Ln_cmd);
                }
                
                string Cmd = Console.ReadLine();//Declaramos una variable de tipo string cuyo valor será asignado con la entrada de texto
                Cmd = Cmd.ToLower();
                if (Cmd == cmnd[0])
                {
                    About_console(args[6]); //Llamamos a un método descrito más abajo para iniciar el constructor
                    r = true;
                }
                else if (Cmd == cmnd[1])
                {
                    Console.Clear();//Limpiamos la pantalla
                    r = true;
                }
                else if (Cmd == cmnd[2])
                {
                    Cmd_conversor.Cmd_prn();//Iniciamos el terminal de conversión
                    r = true;
                }
                else if (Cmd == cmnd[3] || Cmd == cmnd[4])//comara si el valor de entrada es igual a cmnd[3] o a cmnd[4]
                {
                    r = false;
                    Environment.Exit(0); // Cierra la Consola
                }
                else if (Cmd == cmnd[5])
                {
                    Help_console();//Llamamos al método de Help_console, programado más abajo
                    r = true;
                }
                else if (Cmd == cmnd[6])
                {
                    Console.WriteLine($"Hora y Fecha: {DateTime.Now}\n");// Esto nos imprime la hora y la fecha en consola
                    Console.WriteLine($"Hora y Fecha personalizado: {DateTime.Now:hh:mm:ss.fff dd-MM-yy}"); //Aquí podemos establecer como se va ha mostrar la hora
                    Console.WriteLine($"Hora y Fecha - UTC: {DateTime.UtcNow:hh:mm:ss.fff dd/MM/yyyy}");//Las 3 f son para los milisegundos
                    Console.WriteLine($"Solo la hora: {DateTime.Now:hh:mm:ss}"); //Esto nos imprime solo la hora
                    Console.Write($"Solo la Fecha: {DateTime.Now:dd / MM / yyyy}"); //Esto nos imprime solo la fecha
                    r = true;
                }
                else if (Cmd == cmnd[7])
                {
                    Permcombrep perm = new Permcombrep();
                    perm.Factorial();
                    r = true;

                }
                else if (Cmd == cmnd[8])
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
        public static void About_console(string version)
        {
            const string msg_about = "Esta aplicación de consola le permitira ver la hora y fecha actual en diferentes formatos,\nsaber que combinaciones de teclas pulsas, convertir unidades de longitud, temperatura, masa, presión; etc.";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Programa creado y desarroyado por Zegameus Co. (ZCNR)");
            Console.WriteLine("(c)Zegameus Company Network Records\nZetaur.");
            Console.WriteLine(msg_about);
            Console.WriteLine($"Version: {version}");
            Console.WriteLine("Pulsa Cualquier tecla para continuar");
            Console.ReadKey();//espera hasta que se pulse una tecla
        }
        /// <summary>
        /// Método que devuelve un listado de comandos disponibles y su función.
        /// </summary>
        public void Help_console()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nLos comandos disponibles para esta app son:\n");
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
