/*#########################################################
 *#    Copyright 2019 Zegameus Company Network Records    #
 *#                     Licencia MIT                      #
 *#########################################################
 */

using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Zetaur
{
    class Transformador
    {
        private const string FrmExc = "Usted ha introducido un valor no númerico, por favor introduzca un número";//Declaro una constante para cuando el usuario cometa un excepción de tipo FormatException, más info abajo
        private const string Rp = "Otra temperatura que calcular? S/N: ";//Vamos a ahorrar espacio creando una constante para las repeticiones, en este caso para temperatura
        private const string reop = "Otra medida a convertir (S/N): ";//Y en este para las medidas de longitud
        private const string vlno = "¿A introducido usted el valor adecuado?";//y esta para el S/N de continuar los bucles en caso de valor no admitido
        #region Temperatura
        private const string frmcv = "La formula para convertir de";
        private static readonly string[] temps = { "Celsius", "Fahrenheit", "Kelvins" };//para poder usar el array tenemos que ponerlo como static y para evitar su modificación lo ponemos como readonly
        private static readonly string[] frms = { "ºC = (ºF - 32) * 5 / 9", "ºC = K -273.15", "K = ºC + 273.15", "K = (ºF - 32) * 5 / 9 + 273.15", "ºF = (ºC * 5 / 9) + 32", "ºF = (K - 273.15) * 9 / 5 + 32" };
        #region Celsius-Fahrenheits-Kelvins
        /// <summary>
        /// Método pre-creado de conversión de temperaturas. Celsius a Fahrenheits y a Kelvins.
        /// </summary>
        public static void TmpCel()
        {
            bool rep = true; //Declaramos un booleano en condicion true para poder ejecutar un while a continuación
            while (rep)
            {
                Console.WriteLine("Introduzca una temperatura en grados celsius a convertir:");
                Console.Write(">> ");
                try
                {
                    double cels = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));//Hacemos que el usuario introduzca una cantidad por la consola, y obligamos a convertirla a double.
                    //En caso de no poder por el motivo que sea, pasaremos al bloque catch.
                    Console.WriteLine("\n{0} {1} a {2} es: {3}", frmcv, temps[0], temps[1], frms[4]);//Para ahorrar espacio utilizamos variables para acortar el código
                    Console.WriteLine("{0} {1} a {2} es: {3}", frmcv, temps[0], temps[2], frms[2]);
                    Op_Temp.OpCelFahrKel(cels);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))//Aquí creamos un encapsulador que en caso de error va a comprobar que el tipo de excepción producida no sea FormatException.
                //Y en caso de que sea FormatException, el programa ejecutara el código del catch que contenga el argumento FormatException 
                {
                    Console.ForegroundColor = ConsoleColor.Red;//Cambiamos el color para que quede mejor.
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;//Ponemos el color inicial
                }
                catch (FormatException e)//Este es el bloque catch que se ejecutara en caso de que la excepción producida sea FormatException
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(FrmExc);//Llamamos a la constante declarada al principio del programa
                    Console.WriteLine($"\n{e.Message}\n");//e.Message nos permite mostrar una descripción corta del error, sin mostrar código del programa.
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine(Rp);
            /*Creamos una condicion if, con un else if y con un else final, ya que este último vendría siendo el while; para mostrar en pantalla la cadena "go"
             con la instrucción go.ToUpper() hacemos que el valor introducido se combierta a mayúsculas, y si no es igual a S (!= "S") hace que el bool rep
             sea false, finalizando el bucle while
             */
            go:
                string go = Console.ReadLine();
                if (go.ToUpper() == "S")//Esto comprueba si el texto introducido en mayúsculas es igual a S, y en caso de ser diferente ejecuta el siguiente fragmento de código
                {
                    rep = true;//mantenemos en true para poder ejecutar el bucle while de nuevo
                }
                else if (go.ToUpper() == "N")
                {
                    rep = false;//Cambiamos de true a false
                }
                else
                {
                    Console.WriteLine(vlno);
                    goto go;
                }
            }

        }
        #endregion
        #region Fahrenheits-Celsius-Kelvins
        /// <summary>
        /// Método pre-creado de conversión de temperaturas. Fahrenheits a Celsius y a Kelvins.
        /// </summary>
        public static void TmpFahr()
        {
            bool rep = true;
            while (rep)
            {
                Console.WriteLine("Introduzca una temperatura en {0} a convertir:\n>>", temps[1]);//Entrada en Farhenheit
                try
                {
                    double fahr = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Console.WriteLine("\n{0} {1} a {2} es: {3}", frmcv, temps[1], temps[0], frms[0]);
                    Console.WriteLine("{0} {1} a {2} es: {3}", frmcv, temps[0], temps[2], frms[3]);
                    Op_Temp.OpFahrCelKel(fahr);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine(Rp);
            go:
                string go = Console.ReadLine();
                if (go.ToUpper() == "S")
                {
                    rep = true;
                }
                else if (go.ToUpper() == "N")
                {
                    rep = false;
                }
                else
                {
                    Console.WriteLine(vlno);
                    goto go;
                }
            }

        }
        #endregion
        #region Kelvins-Fahrenheits-Celsius
        /// <summary>
        /// Método pre-creado de conversión de temperaturas. Kelvins a Celsius y a Fahrenheits.
        /// </summary>
        public static void TmpKel()
        {
            bool rep = true;
            while (rep)
            {
                Console.WriteLine("Introduzca una temperatura en {0} a convertir:\n>>", temps[2]);//Entrada en Kelvins
                try
                {
                    double kel = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Console.WriteLine("\n{0} {1} a {2} es: {3}", frmcv, temps[2], temps[0], frms[1]);
                    Console.WriteLine("{0} {1} a {2} es: {3}", frmcv, temps[2], temps[1], frms[5]);
                    Op_Temp.OpKelFahrCels(kel);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine(Rp);
            go:
                string go = Console.ReadLine();
                if (go.ToUpper() == "S")
                {
                    rep = true;
                }
                else if (go.ToUpper() == "N")
                {
                    rep = false;
                }
                else
                {
                    Console.WriteLine(vlno);
                    goto go;
                }
            }

        }
        #endregion
        #endregion
        #region Longitud
        /// <summary>
        /// Método de conversión de metros al resto de unidades disponibles (véase en el método Op_Long).
        /// </summary>
        public static void CmdM()
        {
            bool rep = true;
            while (rep)
            {
                Console.Write("Inserte una cantidad en metros a convertir: ");
                try
                {
                    double m = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Long.OpM(m);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.WriteLine($"\n{e.Message}\n");
                }
                catch (FormatException e)
                {
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                }
                Console.Write(reop);//llamamos a la constante reop declarada al inicio de la region Longitud, usamos solo Write para que se muestre a continuación el valor de S o N
            go:
                string go = Console.ReadLine();
                if (go.ToUpper() == "S")//Esto comprueba si el texto introducido en mayúsculas es igual a S, y en caso de ser diferente ejecuta el siguiente fragmento de código
                {
                    rep = true;//mantenemos en true para poder ejecutar el bucle while de nuevo
                }
                else if (go.ToUpper() == "N")
                {
                    rep = false;//Cambiamos de true a false
                }
                else
                {
                    Console.WriteLine(vlno);
                    goto go;
                }
            }
        }
        public static void Cmdkm()
        {
            bool rep = true;
            while (rep)
            {
                Console.Write("Inserte una cantidad en metros a convertir: ");
                try
                {
                    double km = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Long.OpKm(km);//Llamamos al método de kilometros
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.WriteLine($"\n{e.Message}\n");
                }
                catch (FormatException e)
                {
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                }
                Console.Write(reop);
            go:
                string go = Console.ReadLine();
                if (go.ToUpper() == "S")//Esto comprueba si el texto introducido en mayúsculas es igual a S, y en caso de ser diferente ejecuta el siguiente fragmento de código
                {
                    rep = true;//mantenemos en true para poder ejecutar el bucle while de nuevo
                }
                else if (go.ToUpper() == "N")
                {
                    rep = false;//Cambiamos de true a false
                }
                else
                {
                    Console.WriteLine(vlno);
                    goto go;
                }
            }
        }
        public static void CmdMi()
        {
            bool rep = true;
            while (rep)
            {
                Console.Write("Inserte una cantidad en Millas a convertir: ");
                try
                {
                    double Mi = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Long.OpMi(Mi);//Llamamos al método de Millas
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.WriteLine($"\n{e.Message}\n");
                }
                catch (FormatException e)
                {
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                }
                Console.Write(reop);
            go:
                string go = Console.ReadLine();
                if (go.ToUpper() == "S")//Esto comprueba si el texto introducido en mayúsculas es igual a S, y en caso de ser diferente ejecuta el siguiente fragmento de código
                {
                    rep = true;//mantenemos en true para poder ejecutar el bucle while de nuevo
                }
                else if (go.ToUpper() == "N")
                {
                    rep = false;//Cambiamos de true a false
                }
                else
                {
                    Console.WriteLine(vlno);
                    goto go;
                }
            }
        }
        public static void CmdNmi()
        {
            bool rep = true;
            while (rep)
            {
                Console.Write("Inserte una cantidad en Millas Náuticas a convertir: ");
                try
                {
                    double Nmi = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Long.OpNmi(Nmi);//Llamamos al método de Millas Náuticas
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.WriteLine($"\n{e.Message}\n");
                }
                catch (FormatException e)
                {
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                }
                Console.Write(reop);
            go:
                Console.Write(reop);
                string go = Console.ReadLine();
                if (go.ToUpper() == "S")//Esto comprueba si el texto introducido en mayúsculas es igual a S, y en caso de ser diferente ejecuta el siguiente fragmento de código
                {
                    rep = true;//mantenemos en true para poder ejecutar el bucle while de nuevo
                }
                else if (go.ToUpper() == "N")
                {
                    Console.Clear();
                    rep = false;//Cambiamos de true a false
                }
                else
                {
                    Console.WriteLine(vlno);
                    goto go;
                }
            }
        }
        public static void CmdInc()
        {
            bool rep = true;
            while (rep)
            {
                Console.Write("Inserte una cantidad en Pulgadas a convertir: ");
                try
                {
                    double Inc = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Long.OpInc(Inc);//Llamamos al método de Pulgadas
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.WriteLine($"\n{e.Message}\n");
                }
                catch (FormatException e)
                {
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                }
                Console.Write(reop);
            go:
                Console.Write(reop);
                string go = Console.ReadLine();
                if (go.ToUpper() == "S")//Esto comprueba si el texto introducido en mayúsculas es igual a S, y en caso de ser diferente ejecuta el siguiente fragmento de código
                {
                    rep = true;//mantenemos en true para poder ejecutar el bucle while de nuevo
                }
                else if (go.ToUpper() == "N")
                {
                    Console.Clear();
                    rep = false;//Cambiamos de true a false
                }
                else
                {
                    Console.WriteLine(vlno);
                    goto go;
                }
            }
        }
        public static void CmdYd()
        {
            bool rep = true;
            while (rep)
            {
                Console.Write("Inserte una cantidad en Yardas a convertir: ");
                try
                {
                    double Yd = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Long.OpYd(Yd);//Llamamos al método de Yardas
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.WriteLine($"\n{e.Message}\n");
                }
                catch (FormatException e)
                {
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                }
                Console.Write(reop);
            go:
                Console.Write(reop);
                string go = Console.ReadLine();
                if (go.ToUpper() == "S")//Esto comprueba si el texto introducido en mayúsculas es igual a S, y en caso de ser diferente ejecuta el siguiente fragmento de código
                {
                    rep = true;//mantenemos en true para poder ejecutar el bucle while de nuevo
                }
                else if (go.ToUpper() == "N")
                {
                    Console.Clear();
                    rep = false;//Cambiamos de true a false
                }
                else
                {
                    Console.WriteLine(vlno);
                    goto go;
                }
            }
        }
        public static void CmdPie()
        {
            bool rep = true;
            while (rep)
            {
                Console.Write("Inserte una cantidad en Pies a convertir: ");
                try
                {
                    double pie = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Long.OpPie(pie);//Llamamos al método de pie
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.WriteLine($"\n{e.Message}\n");
                }
                catch (FormatException e)
                {
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                }
            go:
                Console.Write(reop);
                string go = Console.ReadLine();
                if (go.ToUpper() == "S")//Esto comprueba si el texto introducido en mayúsculas es igual a S, y en caso de ser diferente ejecuta el siguiente fragmento de código
                {
                    rep = true;//mantenemos en true para poder ejecutar el bucle while de nuevo
                }
                else if (go.ToUpper() == "N")
                {
                    Console.Clear();
                    rep = false;//Cambiamos de true a false
                }
                else
                {
                    Console.WriteLine(vlno);
                    goto go;
                }
            }
        }
        #endregion
        #region Masa
        /// <summary>
        /// Método de conversión pre-configurado de Kilogramos(Kg).
        /// </summary>
        public static void CmdKg()
        {
            bool r = true;
            while (r)
            {
            Go:
                Console.Write("Inserte una cantidad en Kilogramos a convertir: ");
                try
                {
                    double Kg = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Masa.OpKg(Kg);//Llamamos al método de Kilogramos
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                bool r1 = true;
                while (r1)
                {
                    Console.WriteLine(reop);
                    string go = Console.ReadLine();
                    if (go.ToUpper() == "S")//Esto comprueba si el texto introducido en mayúsculas es igual a S, y en caso de ser diferente ejecuta el siguiente fragmento de código
                    {
                        goto Go;//Salimos a la fuerza del bucle 2 para volver al inicio de la operación.
                    }
                    else if (go.ToUpper() == "N")
                    {
                        Console.Clear();
                        break;//salimos del primer bucle while
                    }
                    else
                    {
                        Console.WriteLine(vlno);
                        r1 = true;
                    }
                }

                break;//salimos del segundo bucle while
            }
        }
        /// <summary>
        /// Método de conversión pre-configurado de Gramos (g)
        /// </summary>
        public static void CmdGr()
        {
            bool r = true;
            while (r)
            {
            Go:
                Console.Write("Inserte una cantidad en gramos a convertir: ");
                try
                {
                    double G = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Masa.OpG(G);//Llamamos al método de Gramos
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                bool r1 = true;
                while (r1)
                {
                    Console.WriteLine(reop);
                    string go = Console.ReadLine();
                    if (go.ToUpper() == "S")//Esto comprueba si el texto introducido en mayúsculas es igual a S, y en caso de ser diferente ejecuta el siguiente fragmento de código
                    {
                        goto Go;//Salimos a la fuerza del bucle 2 para volver al inicio de la operación.
                    }
                    else if (go.ToUpper() == "N")
                    {
                        Console.Clear();
                        break;//salimos del primer bucle while
                    }
                    else
                    {
                        Console.WriteLine(vlno);
                        r1 = true;
                    }
                }

                break;
            }

        }
        /// <summary>
        /// Método de conversión pre-configurado de Toneladas (métricas).
        /// </summary>
        public static void CmdT()
        {
            bool r = true;
            while (r)
            {
            Go:
                Console.Write("Inserte una cantidad en toneladas a convertir: ");
                try
                {
                    double T = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Masa.OpT(T);//Llamamos al método de Toneladas
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                bool r1 = true;
                while (r1)
                {
                    Console.WriteLine(reop);
                    string go = Console.ReadLine();
                    if (go.ToUpper() == "S")//Esto comprueba si el texto introducido en mayúsculas es igual a S, y en caso de ser diferente ejecuta el siguiente fragmento de código
                    {
                        goto Go;//Salimos a la fuerza del bucle 2 para volver al inicio de la operación.
                    }
                    else if (go.ToUpper() == "N")
                    {
                        Console.Clear();
                        break;//salimos del primer bucle while
                    }
                    else
                    {
                        Console.WriteLine(vlno);
                        r1 = true;
                    }
                }

                break;
            }
        }
        /// <summary>
        /// Método de conversión pre-configurado de Toneladas cortas (Us t).
        /// </summary>
        public static void CmdUsT()
        {
            bool r = true;
            while (r)
            {
            Go:
                Console.Write("Inserte una cantidad en toneladas cortas (Us t) a convertir: ");
                try
                {
                    double UsT = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Masa.OpUsT(UsT);//Llamamos al método de Toneladas cortas (Us t)
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                bool r1 = true;
                while (r1)
                {
                    Console.WriteLine(reop);
                    string go = Console.ReadLine();
                    if (go.ToUpper() == "S")//Esto comprueba si el texto introducido en mayúsculas es igual a S, y en caso de ser diferente ejecuta el siguiente fragmento de código
                    {
                        goto Go;//Salimos a la fuerza del bucle 2 para volver al inicio de la operación.
                    }
                    else if (go.ToUpper() == "N")
                    {
                        Console.Clear();
                        break;//salimos del primer bucle while
                    }
                    else
                    {
                        Console.WriteLine(vlno);
                        r1 = true;
                    }
                }

                break;
            }
        }
        /// <summary>
        /// Método de conversión pre-configurado de Toneladas largas (Uk t).
        /// </summary>
        public static void CmdUkT()
        {
            bool r = true;
            while (r)
            {
            Go:
                Console.Write("Inserte una cantidad en toneladas largas (Uk t) a convertir: ");
                try
                {
                    double UkT = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Masa.OpUkT(UkT);//Llamamos al método de Toneladas Largas
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                bool r1 = true;
                while (r1)
                {
                    Console.WriteLine(reop);
                    string go = Console.ReadLine();
                    if (go.ToUpper() == "S")//Esto comprueba si el texto introducido en mayúsculas es igual a S, y en caso de ser diferente ejecuta el siguiente fragmento de código
                    {
                        goto Go;//Salimos a la fuerza del bucle 2 para volver al inicio de la operación.
                    }
                    else if (go.ToUpper() == "N")
                    {
                        Console.Clear();
                        break;//salimos del primer bucle while
                    }
                    else
                    {
                        Console.WriteLine(vlno);
                        r1 = true;
                    }
                }

                break;
            }
        }
        /// <summary>
        /// Método de conversión pre-configurado de Libras (lb).
        /// </summary>
        public static void CmdLb()
        {
            bool r = true;
            while (r)
            {
            Go:
                Console.Write("Inserte una cantidad en libras a convertir: ");
                try
                {
                    double Lb = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Masa.OpLb(Lb);//Llamamos al método de libras
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                bool r1 = true;
                while (r1)
                {
                    Console.WriteLine(reop);
                    string go = Console.ReadLine();
                    if (go.ToUpper() == "S")//Esto comprueba si el texto introducido en mayúsculas es igual a S, y en caso de ser diferente ejecuta el siguiente fragmento de código
                    {
                        goto Go;//Salimos a la fuerza del bucle 2 para volver al inicio de la operación.
                    }
                    else if (go.ToUpper() == "N")
                    {
                        Console.Clear();
                        break;//salimos del primer bucle while
                    }
                    else
                    {
                        Console.WriteLine(vlno);
                        r1 = true;
                    }
                }

                break;
            }
        }
        /// <summary>
        /// Método de conversión pre-configurado de Onzas (Oz).
        /// </summary>
        public static void CmdOz()
        {
            bool r = true;
            while (r)
            {
            Go:
                Console.Write("Inserte una cantidad en onzas a convertir: ");
                try
                {
                    double Oz = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Masa.OpOz(Oz);//Llamamos al método de Onzas
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                bool r1 = true;
                while (r1)
                {
                    Console.WriteLine(reop);
                    string go = Console.ReadLine();
                    if (go.ToUpper() == "S")//Esto comprueba si el texto introducido en mayúsculas es igual a S, y en caso de ser diferente ejecuta el siguiente fragmento de código
                    {
                        goto Go;//Salimos a la fuerza del bucle 2 para volver al inicio de la operación.
                    }
                    else if (go.ToUpper() == "N")
                    {
                        Console.Clear();
                        break;//salimos del primer bucle while
                    }
                    else
                    {
                        Console.WriteLine(vlno);
                        r1 = true;
                    }
                }

                break;
            }
        }
        /// <summary>
        /// Método de conversión pre-configurado de Stones (St).
        /// </summary>
        public static void CmdSt()
        {
            bool r = true;
            while (r)
            {
            Go:
                Console.Write("Inserte una cantidad en stones a convertir: ");
                try
                {
                    double St = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Masa.OpSt(St);//Llamamos al método de Stones
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                bool r1 = true;
                while (r1)
                {
                    Console.WriteLine(reop);
                    string go = Console.ReadLine();
                    if (go.ToUpper() == "S")//Esto comprueba si el texto introducido en mayúsculas es igual a S, y en caso de ser diferente ejecuta el siguiente fragmento de código
                    {
                        goto Go;//Salimos a la fuerza del bucle 2 para volver al inicio de la operación.
                    }
                    else if (go.ToUpper() == "N")
                    {
                        Console.Clear();
                        break;//salimos del primer bucle while
                    }
                    else
                    {
                        Console.WriteLine(vlno);
                        r1 = true;
                    }
                }

                break;
            }
        }
        #endregion
        #region Presion
        public static void CmdAtm()
        {
            bool r = true;
            while (r)
            {
            Go:
                Console.Write("Inserte una cantidad en Atmósferas a convertir: ");
                try
                {
                    double Atm = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Presion.OpAtm(Atm);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                bool r1 = true;
                while (r1)
                {
                    Console.WriteLine(reop);
                    string go = Console.ReadLine();
                    if (go.ToUpper() == "S")
                    {
                        goto Go;
                    }
                    else if (go.ToUpper() == "N")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine(vlno);
                        r1 = true;
                    }
                }
                break;
            }
        }
        public static void CmdBar()
        {
            bool r = true;
            while (r)
            {
            Go:
                Console.Write("Inserte una cantidad en bares a convertir: ");
                try
                {
                    double Bar = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Presion.OpBar(Bar);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                bool r1 = true;
                while (r1)
                {
                    Console.WriteLine(reop);
                    string go = Console.ReadLine();
                    if (go.ToUpper() == "S")
                    {
                        goto Go;
                    }
                    else if (go.ToUpper() == "N")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine(vlno);
                        r1 = true;
                    }
                }
                break;
            }
        }
        public static void CmdmBar()
        {
            bool r = true;
            while (r)
            {
            Go:
                Console.Write("Inserte una cantidad en milibares a convertir: ");
                try
                {
                    double mBar = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Presion.OpmBar(mBar);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                bool r1 = true;
                while (r1)
                {
                    Console.WriteLine(reop);
                    string go = Console.ReadLine();
                    if (go.ToUpper() == "S")
                    {
                        goto Go;
                    }
                    else if (go.ToUpper() == "N")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine(vlno);
                        r1 = true;
                    }
                }
                break;
            }
        }
        public static void CmdPSI()
        {
            bool r = true;
            while (r)
            {
            Go:
                Console.Write("Inserte una cantidad en PSI a convertir: ");
                try
                {
                    double PSI = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Presion.OpPSI(PSI);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                bool r1 = true;
                while (r1)
                {
                    Console.WriteLine(reop);
                    string go = Console.ReadLine();
                    if (go.ToUpper() == "S")
                    {
                        goto Go;
                    }
                    else if (go.ToUpper() == "N")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine(vlno);
                        r1 = true;
                    }
                }
                break;
            }
        }
        public static void CmdPa()
        {
            bool r = true;
            while (r)
            {
            Go:
                Console.Write("Inserte una cantidad en Pascales a convertir: ");
                try
                {
                    double Pa = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Presion.OpPa(Pa);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                bool r1 = true;
                while (r1)
                {
                    Console.WriteLine(reop);
                    string go = Console.ReadLine();
                    if (go.ToUpper() == "S")
                    {
                        goto Go;
                    }
                    else if (go.ToUpper() == "N")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine(vlno);
                        r1 = true;
                    }
                }
                break;
            }
        }
        public static void CmdhPa()
        {
            bool r = true;
            while (r)
            {
            Go:
                Console.Write("Inserte una cantidad en Hectopascales a convertir: ");
                try
                {
                    double hPa = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Presion.OphPa(hPa);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                bool r1 = true;
                while (r1)
                {
                    Console.WriteLine(reop);
                    string go = Console.ReadLine();
                    if (go.ToUpper() == "S")
                    {
                        goto Go;
                    }
                    else if (go.ToUpper() == "N")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine(vlno);
                        r1 = true;
                    }
                }
                break;
            }
        }
        public static void CmdmmhgTorr()
        {
            bool r = true;
            while (r)
            {
            Go:
                Console.Write("Inserte una cantidad en Atmósferas a convertir: ");
                try
                {
                    double mmHg = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Presion.OpmmHgTorr(mmHg);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                bool r1 = true;
                while (r1)
                {
                    Console.WriteLine(reop);
                    string go = Console.ReadLine();
                    if (go.ToUpper() == "S")
                    {
                        goto Go;
                    }
                    else if (go.ToUpper() == "N")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine(vlno);
                        r1 = true;
                    }
                }
                break;
            }
        }
        public static void CmdKpcm2()
        {
            bool r = true;
            while (r)
            {
            Go:
                Console.Write("Inserte una cantidad en Kilopondios por centímetro cuadrado a convertir: ");
                try
                {
                    double kpcm2 = double.Parse(Regex.Replace(Console.ReadLine(), "[.,]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Op_Presion.Opkpcm2(kpcm2);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(FrmExc);
                    Console.WriteLine($"\n{e.Message}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                bool r1 = true;
                while (r1)
                {
                    Console.WriteLine(reop);
                    string go = Console.ReadLine();
                    if (go.ToUpper() == "S")
                    {
                        goto Go;
                    }
                    else if (go.ToUpper() == "N")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine(vlno);
                        r1 = true;
                    }
                }
                break;
            }
        }
        #endregion
    }
}
