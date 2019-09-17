﻿/*#########################################################
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
            Console.WriteLine("\nSección de conversiones\nComandos disponibles:\n");
            string[] comandos = new string[5] { "temperatura", "longitud", "masa", "presion", "inicio" };//Creamos un arreglo que contenga 5 valores (recordad que se empieza a contar desde el 0, por lo tanto es 0,1,2,3,4...).
            /* Establecemos el primer valor como temperatura
             * El segundo como longitud 
             * El tercero como masa (No confundir peso con masa, ya que el peso se mide en Newtons y la masa en Gramos)
             * El cuarto como presion (aquí evitaremos las tildes)
             * Y el último como inicio para volvel al menú principal
             */

            //Vamos a mostrar los comandos en pantalla
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0}: Para ir al menú de temperatura.\n{1}: Para ir al menú de longitud.", comandos[0], comandos[1]);
            Console.WriteLine("{0}: Para ir al menú de masa.\n{1}: Para ir al menú de presion.\n{2}: Para ir al inicio.", comandos[2], comandos[3], comandos[4]);
            string cmd = Convert.ToString(Console.ReadLine());
            //Creamos una sección de if-else para los distintos apartados de esta sección
            if (cmd == comandos[0])
            {
                Tmp_cmd();//Llamamos al metodo del submenu de temperatura
                goto init;
            }
            else if (cmd == comandos[1])
            {
                Long_cmd();//llamamos al metodo del submenu de longitud
                goto init;
            }
            else if (cmd == comandos[2])
            {
                SbmMasa();
                goto init;
            }
            else if (cmd == comandos[3])
            {
                Console.WriteLine("No configurado todavía");
            }
            else if (cmd == comandos[4])
            {
                Console.Clear();//Vamos a limpiar la pantalla
                Console.ForegroundColor = ConsoleColor.Green;//y a cambiarle el color de letra
            }
            else
            {
                Console.WriteLine("\nComando no encontrado, compruebe su otrografía");
                goto init;
            }

        }
        #region Submenú temperatura
        public static void Tmp_cmd()
        {
        init:
            int[] tmp = new int[7] { 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine("\nSección de conversión de temperatura");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nComandos disponibles:\n{0}: Para convertir de Celsius a Fahrenheit.\n{1}: Para convertir de Fahrenheit a Celsius.", tmp[0], tmp[1]);
            Console.WriteLine("{0}: Para convertir de Celsius a Kelvins.\n{1}: Para convertir de Kelvins a Celsius.", tmp[2], tmp[3]);
            Console.WriteLine("{0}: Para convertir de Fahrenheit a Kelvins.\n{1}: Para convertir de Kelvin a Fahrenheit.", tmp[4], tmp[5]);
            Console.Write("{0} para volver atras.\n>>", tmp[6]);
            int input = 0;
            try
            {
                input = int.Parse(Console.ReadLine());
            }
            catch (Exception e) when (e.GetType() != typeof(FormatException))
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("El valor introducizo no es numérico, se iniciara el conversor ºC a ºF(Es el predeterminado)");
                Console.WriteLine(e.Message);
            }

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
            }
            else if (input == tmp[5])
            {
                Transformador.KelFahr();
                goto init;
            }
            else if (input == tmp[6])
            {
                Console.ForegroundColor = ConsoleColor.Green;//Cambiamos el color para volver atras y restablecerlo
            }
            else
            {
                Console.WriteLine("\nComando no encontrado, revise la ortografía");
                goto init;
            }
        }
        #endregion
        #region Submenú longitud
        public static void Long_cmd()
        {
        init:
            int[] c = new int[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nComandos disponibles:\n{0}: Para convertir de Kilómetros a millas/millas náuticas.", c[0]);
            Console.WriteLine("{0}: Para convertir de millas a km.\n{1}: Para convertir de Millas náuticas a Km.", c[1], c[2]);
            Console.WriteLine("{0}: Para convertir de millas a millas náuticas.\n{1}: Para convertir de millas náuticas a millas.", c[3], c[4]);
            Console.WriteLine("{0}: Para convertir de Km a Yardas.\n{1}: Para convertir de Yardas a Km.\n{2}: Para convertir Metros a Pies.", c[5], c[6], c[7]);
            Console.WriteLine("{0}: Para convertir de Pies a Metros.\nvolver: Para volver al menú principal del conversor", c[8]);
            
            #region if-else
            string i = Console.ReadLine();
            if (i == Convert.ToString(c[0]))//Utilizamos Convert.ToString para poder compararlo con i, ya que la entrada de volver es solo texto
            {
                Transformador.KmMll();//Kilómetros - Millas
                goto init;
            }
            else if (i == Convert.ToString(c[1]))
            {
                Transformador.MKm();//Millas-Kilómetros
                goto init;
            }
            else if (i == Convert.ToString(c[2]))
            {
                Transformador.MNKm();//Millas Náuticas-Kilómetros
                goto init;
            }
            else if (i == Convert.ToString(c[3]))
            {
                Transformador.M_MN();//Millas-Millas Náuticas
                goto init;
            }
            else if (i == Convert.ToString(c[4]))
            {
                Transformador.MN_M();//Millas Náuticas-Millas
                goto init;
            }
            else if (i == Convert.ToString(c[5]))//Km - Yardas
            {
                Transformador.KM_Yd();
                goto init;
            }
            else if (i == Convert.ToString(c[6]))//Yardas - Km
            {
                Transformador.Yd_Km();
                goto init;
            }
            else if(i == Convert.ToString(c[7]))
            {
                Transformador.M_Pie();//Metros - Pie
            }
            else if (i == Convert.ToString(c[8]))
            {
                Transformador.Pie_M();//Pie - Metros
                goto init;
            }
            else if (i.ToLower() == "volver")//Vamos a ordenar que el texto de entrada sea transformado en minusculas
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                //Importante no poner el goto init, ya que nunca saldriamos de este bucle
            }
            else
            {
                Console.WriteLine("\nComando no encontrado, compruebe su ortografía.");
                goto init;
            }
            #endregion
        }
        #endregion
        #region Submenú masa
        public static void SbmMasa()
        {
            int[] a = new int[15] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            Console.WriteLine("Comandos disponibles:\n{0}: Conversor Kilogramos - Tonelada, T. Larga y T. Corta.", a[0]);
            Console.WriteLine("{0}: Conversor Kg - Libras.\n{1}: Conversor Kg - Onzas.\n{2}: Conversor Kg - \"Stone\"", a[1], a[2], a[3]);
            Console.WriteLine("{0}: Conversor Toneladas - Kg.\n{1}: Conversor Toneladas - Libras.\n{2}: Conversor Toneladas - Onzas.", a[4], a[5], a[6]);
            Console.WriteLine("{0}: Conversor Tonelas - \"Stone\".\n{1}: Conversor Libras - Kg.\n{1}: Conversor Onzas - Kg.\n{2}: \"Stones\" - Kg.", a[7], a[8], a[9], a[10]);
            Console.WriteLine("{0}: Conversor Libas - Kg.\n{1}: Conversor Libras - Toneladas.\n{2}: Conversor Libras - Onzas.\n{3}: Conversor Libras -\"Stone\".", a[11], a[12], a[13], a[14]);
            Console.WriteLine("Aún faltan unidades, disculpen las molestias. Esto solo le mostrará las unidades que podran ser convertidas.");
        }
        #endregion
    }
}

