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
        #region Menú-Principal
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
        #endregion
        #region Submenú temperatura
        public static void Tmp_cmd()
        {
        init:
            int[] tmp = new int[4] { 1, 2, 3, 4 };
            Console.WriteLine("\nSección de conversión de temperatura");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nComandos disponibles:\n{0}: Para convertir de Celsius a Fahrenheit y a Kelvins.\n{1}: Para convertir de Fahrenheit a Celsius y a Kelvins.", tmp[0], tmp[1]);
            Console.WriteLine("{0}: Para convertir de Kelvins a Celsius y a Fahrenheit.", tmp[2]);
            Console.Write("{0} para volver atras.\n>>", tmp[3]);
            Console.ForegroundColor = ConsoleColor.Green;
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
                Console.WriteLine("El valor introducizo no es numérico, se iniciara el conversor ºC a ºF y a K(Es el predeterminado)");
                Console.WriteLine(e.Message);
            }

            if (input == tmp[0])//Celsius a Fahrenheits y a Kelvins
            {
                Transformador.CelFahrKel();
                goto init;
            }
            else if (input == tmp[1]) //Fahrenheits a Celsius y Kelvins
            {
                Transformador.FahrKelCel();
                goto init;
            }
            else if (input == tmp[2])//Kelvins a Celsius y a Fahrenheits
            {
                Transformador.KelCelFahr();
                goto init;
            }
            else if (input == tmp[3])
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
            #region Comandos
            sbyte[] c = new sbyte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };//Utilizamos sbyte en vez de int porque utilizamos valores pequeños y no es necesario reservar mucho espacio en la memoria RAM, estos valores van de -128 a 127, por lo que aún nos sobra.
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nComandos disponibles:\n{0}: Para convertir Metros.", c[0]);
            Console.WriteLine("{0}: Para convertir kilometros.\n{1}: Para convertir Millas.", c[1], c[2]);
            Console.WriteLine("{0}: Para convertir Millas náuticas.\n{1}: Para convertir Pulgadas.", c[3], c[4]);
            Console.WriteLine("{0}: Para convertir Yardas.\n{1}: Para convertir Pies", c[5], c[6]);
            Console.WriteLine("{0}: Para volver al menú principal del conversor", c[7]);
            #endregion
            #region if-else
            string i = Console.ReadLine();
            if (i == Convert.ToString(c[0]))//Utilizamos Convert.ToString para poder compararlo con i, ya que la entrada de volver es solo texto
            {
                Transformador.CmdM();//Metros al resto
                goto init;
            }
            else if (i == Convert.ToString(c[1]))
            {
                Transformador.Cmdkm();//Kilometros al resto
                goto init;
            }
            else if (i == Convert.ToString(c[2]))
            {
                Transformador.CmdMi();//Millas
                goto init;
            }
            else if (i == Convert.ToString(c[3]))
            {
                Transformador.CmdNmi();//Millas-Millas Náuticas
                goto init;
            }
            else if (i == Convert.ToString(c[4]))
            {
                Transformador.CmdInc();//Pulgadas
                goto init;
            }
            else if (i == Convert.ToString(c[5]))
            {
                Transformador.CmdYd();//Yardas
                goto init;
            }
            else if (i == Convert.ToString(c[6]))
            {
                Transformador.CmdPie();//Pies
                goto init;
            }
            else if (i == Convert.ToString(c[7]))//Vamos a ordenar que el texto de entrada sea transformado en minusculas
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
            bool r = true;
            while (r)
            {
                sbyte[] a = new sbyte[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                Console.WriteLine("Comandos disponibles:\n{0}: Conversor Kilogramos.\n{1}: Conversor Gramos.", a[0], a[1]);
                Console.WriteLine("{0}: Toneladas.\n{1}: Conversor Toneladas Cortas.\n{2}: Conversor Toneladas Largas", a[2], a[3], a[4]);
                Console.WriteLine("{0}: Conversor Libras.\n{1}: Conversor Onzas.\n{2}: Conversor \"Stones\".", a[5], a[6], a[7]);
                Console.WriteLine("{0}: Volver al menú.", a[8]);

                sbyte i = 1;
                try
                {
                    i = Convert.ToSByte(Console.ReadLine());
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("El valor introducizo no es numérico.");
                    Console.WriteLine(e.Message);
                }
                if (i == a[0])
                {
                    Transformador.CmdKg();
                    r = true;
                }
                else if (i == a[1])
                {
                    Transformador.CmdGr();
                    r = true;
                }
                else if (i == a[8])
                {
                    r = false;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Comando no encontrado.");
                    r = true;
                }
            }
        }
        #endregion
    }
}

