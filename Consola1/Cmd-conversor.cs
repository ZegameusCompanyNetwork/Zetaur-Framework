/*#########################################################
 *#    Copyright 2019 Zegameus Company Network Records    #
 *#                     Licencia MIT                      #
 *#########################################################
 */
using System;

namespace Consola
{
    class Cmd_conversor
    {
        public static void Cmd_prn()
        {
            init:
            Console.WriteLine("Sección de conversiones");
            string[] comandos = new string[5] { "temperatura", "longitud", "masa", "presion","inicio"};//Creamos un arreglo que contenga 5 valores (recordad que se empieza a contar desde el 0, por lo tanto es 0,1,2,3,4...).
            /* Establecemos el primer valor como temperatura
             * El segundo como longitud 
             * El tercero como masa (No confundir peso con masa, ya que el peso se mide en Newtons y la masa en Gramos)
             * El cuarto como presion (aquí evitaremos las tildes)
             * Y el último como inicio para volvel al menú principal
             */

            //Vamos a mostrar los comandos en pantalla
            Console.WriteLine("{0}: Para ir al menú de temperatura.\n{1}: Para ir al menú de longitud.",comandos[0],comandos[1]);
            Console.WriteLine("{0}: Para ir al menú de masa.\n{1}: Para ir al menú de presion.\n{2}: Para ir al inicio.", comandos[2], comandos[3],comandos[4]);
            string cmd = Convert.ToString(Console.ReadLine());
            //Creamos una sección de if-else para los distintos apartados de esta sección
            if (cmd == comandos[0])
            {
                Tmp_cmd();
                goto init;
            }
            else if (cmd == comandos[1])
            {
                Long_cmd();
            }
            else if (cmd == comandos[2])
            {
                Console.WriteLine("No configurado todavía");
            }
            else if (cmd == comandos[3])
            {
                Console.WriteLine("No configurado todavía");
            }
            else if (cmd == comandos[4])
            {
                Console.Clear();//Vamos a limpiar la pantalla
            }
            else
            {
                Console.WriteLine("Comando no encontrado, compruebe su otrografía");
                goto init;
            }

        }
        #region Submenú temperatura
        public static void Tmp_cmd()
        {
            init:
            string[] tmp = new string[7] {"celfahr", "fahrcel", "celkel", "kelcel", "fahrkel", "kelfahr","volver"};
            Console.WriteLine("Sección de conversión de temperatura");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Comandos disponibles:\n{0}: Para convertir de Celsius a Fahrenheit.\n{1}: Para convertir de Fahrenheit a Celsius.", tmp[0], tmp[1]);
            Console.WriteLine("{0}: Para convertir de Celsius a Kelvins.\n{1}: Para convertir de Kelvins a Celsius.", tmp[2], tmp[3]);
            Console.WriteLine("{0}: Para convertir de Fahrenheit a Kelvins.\n{1}: Para convertir de Kelvin a Fahrenheit.", tmp[4], tmp[5]);
            Console.Write("{0} para volver atras.\n>>", tmp[6]);
            string input = Convert.ToString(Console.ReadLine());
            if (input == tmp[0])
            {
                Transformador.CelFahr();
                goto init;
            }
            else if (input == tmp[1])
            {
                Transformador.FahrCel();
                goto init;
            }
            else if (input == tmp[2])
            {
                Transformador.CelKel();
                goto init;
            }
            else if (input == tmp[3])
            {
                Transformador.KelCel();
                goto init;
            }
            else if (input == tmp[4])
            {
                Transformador.FahrKel();
                goto init;
            }else if(input == tmp[5])
            {
                Transformador.KelFahr();
                goto init;
            }else if (input == tmp[6])
            {
                Console.ForegroundColor=ConsoleColor.Green;//Cambiamos el color para volver atras y restablecerlo
            }
            else
            {
                Console.WriteLine("Comando no encontrado, revise la ortografía");
                goto init;
            }
        }
        #endregion
        #region Submenú longitud
        public static void Long_cmd()
        {
            init:
            int[] c = new int[5] {1,2,3,4,5};
            Console.WriteLine("Comandos disponibles:\n{0}: Para convertir de Kilómetros a millas/millas náuticas.", c[0]);
            Console.WriteLine("{0}: Para convertir de millas a kilómetros.\n{1}: Para convertir de Millas náuticas a kilómetros.", c[1], c[2]);
            Console.WriteLine("{0}: Para convertir de millas a millas náuticas.\n{1}: Para convertir de millas náuticas a millas.", c[3], c[4]);
            string i = Console.ReadLine();
            if(i == Convert.ToString(c[0]))//Utilizamos Convert.ToString para poder compararlo con i, ya que la entrada de volver es solo texto
            {
                Transformador.KmMll();//Kilómetros - Millas
                goto init;
            }else if(i == Convert.ToString(c[1]))
            {
                Transformador.MKm();//Millas-Kilómetros
                goto init;
            }else if(i == Convert.ToString(c[2]))
            {
                Transformador.MNKm();//Millas Náuticas-Kilómetros
                goto init;
            }else if (i == Convert.ToString(c[3]))
            {
                Transformador.M_MN();//Millas-Millas Náuticas
                goto init;
            }else if(i == Convert.ToString(c[4]))
            {
                Transformador.MN_M();//Millas Náuticas-Millas
                goto init;
            }else if (i == "volver")
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Comando no encontrado, compruebe su ortografía.");
                goto init;
            }
        }
        #endregion
    }
}
