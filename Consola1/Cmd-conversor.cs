/*#########################################################
 *#    Copyright 2019 Zegameus Company Network Records    #
 *#                     Licencia MIT                      #
 *#########################################################
 */
using System;

namespace Zetaur
{
    class Cmd_conversor
    {
        #region Menú-Principal
        public static void Cmd_prn()
        {
            bool r = true;
            while (r)
            {
                Console.WriteLine("\nSección de conversiones\nComandos disponibles:\n");
                sbyte[] a = new sbyte[5] { 1, 2, 3, 4, 5 };//Creamos un arreglo que contenga 5 valores (recordad que se empieza a contar desde el 0, por lo tanto es 0,1,2,3,4...).
                //Usamos Sbyte para ocupar el menor espacio en RAM posible.
                //Vamos a mostrar los comandos en pantalla
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{a[0]}: Para ir al menú de temperatura.\n{a[1]}: Para ir al menú de longitud.");
                Console.WriteLine($"{a[2]}: Para ir al menú de masa.\n{a[3]}: Para ir al menú de presión.\n{a[4]}: Para ir al inicio.");
                sbyte cmd = 1;
                try
                {
                    Console.Write(">> ");
                    cmd = Convert.ToSByte(Console.ReadLine());
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
                finally
                {
                    //Creamos una sección de if-else para los distintos apartados de esta sección
                    if (cmd == a[0])
                    {
                        Tmp_cmd();//Llamamos al método del submenú de temperatura
                        r = true;
                    }
                    else if (cmd == a[1])
                    {
                        Long_cmd();//Llamamos al método del submenú de longitud

                    }
                    else if (cmd == a[2])
                    {
                        SbmMasa();//Llamamos al método del submenú de masa
                        r = true;
                    }
                    else if (cmd == a[3])
                    {
                        SbmPresion();//Llamamos al método del sumbenú de presión
                        r = true;
                    }
                    else if (cmd == a[4])
                    {
                        Console.Clear();//Vamos a limpiar la pantalla
                        Console.ForegroundColor = ConsoleColor.Green;//y a cambiarle el color de letra
                        r=false;
                    }
                    else
                    {
                        Console.WriteLine("\nComando no encontrado, compruebe su otrografía");
                        r = true;
                    }
                }
            }
        }
        #endregion
        #region Submenú temperatura
        public static void Tmp_cmd()
        {
            bool r = true;
            while (r)
            {
                sbyte[] a = new sbyte[4] { 1, 2, 3, 4 };
                Console.WriteLine("\nSección de conversión de temperatura");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nComandos disponibles:\n{0}: Para convertir de Celsius a Fahrenheit y a Kelvins.\n{1}: Para convertir de Fahrenheit a Celsius y a Kelvins.", a[0], a[1]);
                Console.WriteLine("{0}: Para convertir de Kelvins a Celsius y a Fahrenheit.", a[2]);
                Console.Write($"{a[3]} para volver atras.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n>> ");
                sbyte input = 1;//Establecemos este valor por sí el usuario introduce mal el número, poder iniciar el conversor de ºC
                try
                {
                    input = Convert.ToSByte(Console.ReadLine());
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

                if (input == a[0])//Celsius a Fahrenheits y a Kelvins
                {
                    Transformador.TmpCel();
                    r = true;
                }
                else if (input == a[1]) //Fahrenheits a Celsius y Kelvins
                {
                    Transformador.TmpFahr();
                    r = true;
                }
                else if (input == a[2])//Kelvins a Celsius y a Fahrenheits
                {
                    Transformador.TmpKel();
                    r = true;
                }
                else if (input == a[3])
                {
                    Console.ForegroundColor = ConsoleColor.Green;//Cambiamos el color para volver atras y restablecerlo
                    r = false;
                }
                else
                {
                    Console.WriteLine("\nComando no encontrado, revise la ortografía");
                    r = true;
                }
            }
        }
        #endregion
        #region Submenú longitud
        public static void Long_cmd()
        {
            bool r = true;
            while (r)
            {
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
                sbyte i = 1;
                try
                {
                    Console.Write(">> ");
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
                finally
                {
                    if (i == (c[0]))
                    {
                        Transformador.CmdM();//Metros al resto
                        r = true;
                    }
                    else if (i == (c[1]))
                    {
                        Transformador.Cmdkm();//Kilometros al resto
                        r = true;
                    }
                    else if (i == (c[2]))
                    {
                        Transformador.CmdMi();//Millas
                        r = true;
                    }
                    else if (i == (c[3]))
                    {
                        Transformador.CmdNmi();//Millas-Millas Náuticas
                        r = true;
                    }
                    else if (i == (c[4]))
                    {
                        Transformador.CmdInc();//Pulgadas
                        r = true;
                    }
                    else if (i == (c[5]))
                    {
                        Transformador.CmdYd();//Yardas
                        r = true;
                    }
                    else if (i == (c[6]))
                    {
                        Transformador.CmdPie();//Pies
                        r = true;
                    }
                    else if (i == (c[7]))//Vamos a ordenar que el texto de entrada sea transformado en minusculas
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        r = false; //Importante no poner el r como true, ya que entonces no saldríamos del bucle
                    }
                    else
                    {
                        Console.WriteLine("\nComando no encontrado, compruebe su ortografía.");
                        r = true;
                    }
                }
                #endregion
            }
        }
        #endregion
        #region Submenú masa
        public static void SbmMasa()
        {
            bool r = true;
            while (r)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                sbyte[] a = new sbyte[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                Console.WriteLine("Comandos disponibles:\n{0}: Conversor Kilogramos.\n{1}: Conversor Gramos.", a[0], a[1]);
                Console.WriteLine("{0}: Conversor Toneladas (métricas).\n{1}: Conversor Toneladas Cortas.\n{2}: Conversor Toneladas Largas", a[2], a[3], a[4]);
                Console.WriteLine("{0}: Conversor Libras.\n{1}: Conversor Onzas.\n{2}: Conversor \"Stones\".", a[5], a[6], a[7]);
                Console.WriteLine("{0}: Volver al menú.", a[8]);

                sbyte i = 1;
                try
                {
                    Console.Write(">> ");
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
                finally
                {
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
                    else if (i == a[2])
                    {
                        Transformador.CmdT();
                        r = true;
                    }
                    else if (i == a[3])
                    {
                        Transformador.CmdUsT();
                        r = true;
                    }
                    else if (i == a[4])
                    {
                        Transformador.CmdUkT();
                        r = true;
                    }
                    else if (i == a[5])
                    {
                        Transformador.CmdLb();
                        r = true;
                    }
                    else if (i == a[6])
                    {
                        Transformador.CmdOz();
                        r = true;
                    }
                    else if (i == a[7])
                    {
                        Transformador.CmdSt();
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
        }
        #endregion
        #region Submenú Presión
        public static void SbmPresion()
        {
            bool r = true;
            while (r)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                sbyte[] a = new sbyte[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };//Le asignamos un valor de cantidades máximas
                Console.WriteLine($"Comandos disponibles:\n{a[0]}: Conversor Atmósferas.\n{a[1]}: Conversor Bares.\n{a[2]}: Conversor Milibares.");
                Console.WriteLine($"{a[3]}: Conversor Pascales.\n{a[4]}: Conversor HectoPascales.\n{a[5]}: Conversor PSI.\n{a[6]}: Conversor mmHg y Torr.");
                Console.WriteLine($"{a[7]}: Conversor Kiloponidos por cm2.\n{a[8]}: Volver al menú.");
                sbyte i = 1;
                try
                {
                    Console.Write(">> ");
                    i = Convert.ToSByte(Console.ReadLine());
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("El valor introducido no es númerico");
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if (i == a[0])
                    {
                        Transformador.CmdAtm();//Atmosferas técnicas
                        r = true;
                    }
                    else if (i == a[1])
                    {
                        Transformador.CmdBar();//Bares
                        r = true;
                    }
                    else if (i == a[2])
                    {
                        Transformador.CmdmBar();//Milibares
                        r = true;
                    }
                    else if (i == a[3])
                    {
                        Transformador.CmdPa();//Pascales
                        r = true;
                    }
                    else if (i == a[4])
                    {
                        Transformador.CmdhPa();//Hectopascales
                        r = true;
                    }
                    else if (i == a[5])
                    {
                        Transformador.CmdPSI();//PSI
                        r = true;
                    }

                    else if (i == a[6])
                    {
                        Transformador.CmdmmhgTorr();//Milimetros de mercurio y Torrs
                        r = true;
                    }
                    else if (i == a[7])
                    {
                        Transformador.CmdKpcm2();//Kilopondios por centrimetro cuadrado
                        r = true;
                    }
                    else if (i == a[8])//Salir
                    {
                        r = false;
                        Console.Clear();
                    }
                    else//Excepción
                    {
                        Console.WriteLine("Comando no encontrado.");
                        r = true;
                    }
                }
            }
        }
        #endregion
    }
}

