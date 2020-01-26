/*#########################################################
 *#    Copyright 2019 Zegameus Company Network Records    #
 *#                     Licencia MIT                      #
 *#########################################################
 */

using System;

namespace Consola
{
    class Transformador
    {
        private const string FrmExc = "Usted ha introducido un valor no númerico, por favor introduzca un número";//Declaro una constante para cuando el usuario cometa un excepción de tipo FormatException, más info abajo
        private const string Rp = "Otra temperatura que calcular? S/N: ";//Vamos a ahorrar espacio creando una constante para las repeticiones, en este caso para temperatura
        private const string reop = "Otra medida a convertir (S/N): ";//Y en este para las medidas de longitud
        private const string vlno = "¿A introducido usted el valor adecuado?";//y esta para el S/N de continuar los bucles en caso de valor no admitido
        private const string frmcv = "La formula para convertir de";
        private static readonly string[] temps = { "Celsius", "Fahrenheit", "Kelvins" };//para poder usar el array tenemos que ponerlo como static y para evitar su modificación lo ponemos como readonly
        private static readonly string[] frms = { "ºC = (ºF - 32) * 5 / 9", "ºC = K -273.15", "K = ºC + 273.15", "K = (ºF - 32) * 5 / 9 + 273.15", "ºF = (ºC * 5 / 9) + 32", "ºF = (K - 273.15) * 9 / 5 + 32" };
        #region Temperatura
        #region Celsius-Fahrenheits-Kelvins
        public static void CelFahrKel()
        {
            bool rep = true; //Declaramos un booleano en condicion true para poder ejecutar un while a continuación
            while (rep)
            {
                Console.WriteLine("Introduzca una temperatura en grados celsius a convertir:\n>>");
                try
                {
                    double cels = Convert.ToDouble(Console.ReadLine());//Hacemos que el usuario introduzca una cantidad por la consola, y obligamos a convertirla a double.
                    //En caso de no poder por el motivo que sea, pasaremos al bloque catch.
                    Console.WriteLine("\n{0} {1} a {2} es: {3}", frmcv, temps[0], temps[1], frms[4]);//Para ahorrar espacio utilizamos variables para acortar el código
                    Console.WriteLine("{0} {1} a {2} es: {3}", frmcv, temps[0], temps[2], frms[2]);
                    Op_Temp.OpCelFahrKel(cels);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))//Aquí creamos un encapsulador que en caso de error va a comprobar que el tipo de excepción producida no sea FormatException.
                //Y en caso de que sea FormatException, el programa ejecutara el código del catch que contenga el argumento FormatException 
                {
                    Console.WriteLine(e.Message + "\n");
                }
                catch (FormatException e)//Este es el bloque catch que se ejecutara en caso de que la excepción producida sea FormatException
                {
                    Console.WriteLine(FrmExc);//Llamamos a la constante declarada al principio del programa
                    Console.WriteLine(e.Message + "\n");//e.Message nos permite mostrar una descripción corta del error, sin mostrar código del programa.
                }
                Console.WriteLine(Rp);
            /*Creamos una condicion if, sin else, ya que este último vendría siendo el while; para mostrar en pantalla la cadena "go"
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
        public static void FahrKelCel()
        {
            bool rep = true; 
            while (rep)
            {
                Console.WriteLine("Introduzca una temperatura en {0} a convertir:\n>>", temps[1]);//Entrada en Farhenheit
                try
                {
                    double fahr = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("\n{0} {1} a {2} es: {3}", frmcv, temps[1], temps[0], frms[0]);
                    Console.WriteLine("{0} {1} a {2} es: {3}", frmcv, temps[0], temps[2], frms[3]);
                    Op_Temp.OpFahrCelKel(fahr);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.WriteLine(e.Message + "\n");
                }
                catch (FormatException e)
                {
                    Console.WriteLine(FrmExc);
                    Console.WriteLine(e.Message + "\n");
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
        public static void KelCelFahr()
        {
            bool rep = true; 
            while (rep)
            {
                Console.WriteLine("Introduzca una temperatura en {0} a convertir:\n>>", temps[2]);//Entrada en Kelvins
                try
                {
                    double kel = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("\n{0} {1} a {2} es: {3}", frmcv, temps[2], temps[0], frms[1]);
                    Console.WriteLine("{0} {1} a {2} es: {3}", frmcv, temps[2], temps[1], frms[5]);
                    Op_Temp.OpKelFahrCels(kel);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.WriteLine(e.Message + "\n");
                }
                catch (FormatException e)
                {
                    Console.WriteLine(FrmExc);
                    Console.WriteLine(e.Message + "\n");
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

        #region Kilometro-Milla-M.Náutica
        public static void KmMll()
        {
            bool rep = true;
            while (rep)
            {
                Console.Write("Inserte una cantidad para convertir a Millas y Millas Náuticas: ");
                try
                {
                    double km = Convert.ToDouble(Console.ReadLine());
                    Op_Long.OpKmMMN(km);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.WriteLine(e.Message + "\n");
                }
                catch (FormatException e)
                {
                    Console.WriteLine(FrmExc);
                    Console.WriteLine(e.Message + "\n");
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
        public static void MKm()
        {
            bool rep = true;
            while (rep)
            {
                Console.Write("Inserte una cantidad para convertir a Kilómetros: ");
                try
                {
                    double Millas = Convert.ToDouble(Console.ReadLine());
                    Op_Long.OpMKm(Millas);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.WriteLine(e.Message + "\n");
                }
                catch (FormatException e)
                {
                    Console.WriteLine(FrmExc);
                    Console.WriteLine(e.Message + "\n");
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
        public static void MNKm()
        {
            bool rep = true;
            while (rep)
            {
                Console.Write("Inserte una cantidad para convertir a Kilómetros: ");
                try
                {
                    double MNau = Convert.ToDouble(Console.ReadLine());
                    Op_Long.OpMnKm(MNau);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.WriteLine(e.Message + "\n");
                }
                catch (FormatException e)
                {
                    Console.WriteLine(FrmExc);
                    Console.WriteLine(e.Message + "\n");
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
        #endregion
        #region Millas-Millas Náuticas
        public static void M_MN()
        {
            bool rep = true;
            while (rep)
            {
                Console.Write("Inserte una cantidad para convertir a Millas náuticas: ");
                try
                {
                    double Millas = Convert.ToDouble(Console.ReadLine());
                    Op_Long.OpM_MN(Millas);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.WriteLine(e.Message + "\n");
                }
                catch (FormatException e)
                {
                    Console.WriteLine(FrmExc);
                    Console.WriteLine(e.Message + "\n");
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
        public static void MN_M()
        {
            bool rep = true;
            while (rep)
            {
                Console.Write("Inserte una cantidad para convertir a Millas: ");
                try
                {
                    double Millas_Nau = Convert.ToDouble(Console.ReadLine());
                    Op_Long.OpMN_M(Millas_Nau);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.WriteLine(e.Message + "\n");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("El valor introducido no es númerico");
                    Console.WriteLine(e.Message + "\n");
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
        #endregion
        #region Km-Yd
        public static void KM_Yd()
        {
            bool rep = true;
            while (rep)
            {
                Console.Write("Inserte una cantidad para convertir a Yardas: ");
                try
                {
                    double KM = Convert.ToDouble(Console.ReadLine());
                    Op_Long.OpKmYd(KM);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.WriteLine(e.Message + "\n");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("El valor introducido no es númerico");
                    Console.WriteLine(e.Message + "\n");
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
        public static void Yd_Km()
        {
            bool rep = true;
            while (rep)
            {
                Console.Write("Inserte una cantidad para convertir a kilometros: ");
                try
                {
                    double Yardas = Convert.ToDouble(Console.ReadLine());
                    Op_Long.OpYdKm(Yardas);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.WriteLine(e.Message + "\n");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("El valor introducido no es númerico");
                    Console.WriteLine(e.Message + "\n");
                }
                Console.Write(reop);
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
        #region M-Pie
        public static void M_Pie()
        {
            bool rep = true;
            while (rep)
            {
                Console.Write("Inserte una cantidad para convertir a Pies: ");
                try
                {
                    double Metros = Convert.ToDouble(Console.ReadLine());
                    Op_Long.OpMPie(Metros);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.WriteLine(e.Message + "\n");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("El valor introducido no es númerico");
                    Console.WriteLine(e.Message + "\n");
                }
                Console.Write(reop);
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
        public static void Pie_M()
        {
            bool rep = true;
            while (rep)
            {
                Console.Write("Inserte una cantidad para convertir a Pies: ");
                try
                {
                    double Pie = Convert.ToDouble(Console.ReadLine());
                    Op_Long.OpPieM(Pie);
                }
                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.WriteLine(e.Message + "\n");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("El valor introducido no es númerico");
                    Console.WriteLine(e.Message + "\n");
                }
                Console.Write(reop);
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
    }
}
