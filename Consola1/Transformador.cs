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
        #region Temperatura
        #region Fahrenheit a Celsius
        public static void FahrCel ()
        {
            bool rep = true; //Declaramos un booleano en condicion true para poder ejecutar un while a continuación
            const string Frm = "ºC = (ºF - 32) * 5 / 9";
            while (rep)
            {
                Console.WriteLine("Introduzca una temperatura en grados Fahrenheit a calcular");
                try
                {
                    double Fahrenheit = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("\nLa formula para realizar la conversión es: {0}", Frm);
                    Op_conversor.OpFarcel(Fahrenheit);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine("Otra temperatura que calcular? S/N: ");
                /*Creamos una condicion if, sin else, ya que este último vendría siendo el while; para mostrar en pantalla la cadena "go"
                 con la instrucción go.ToUpper() hacemos que el valor introducido se combierta a mayúsculas, y si no es igual a S (!= "S") hace que el bool rep
                 sea false, finalizando el bucle while
                 */
                string go = Console.ReadLine();
                if (go.ToUpper() != "S")
                {
                    rep = false;//Cambiamos de true a false
                }
            }

        }
#endregion
        #region Celsisus a Fahrenheit
        public static void CelFahr()
        {
            bool rep = true; //Declaramos un booleano en condicion true para poder ejecutar un while a continuación
            while (rep)
            {
                const string Frm = "ºF = (ºC x 9 / 5) + 32";//Declaramos un string con la fórmula utilizada
                Console.WriteLine("Introduzca una temperatura en grados Celsius a calcular");
                try
                {
                    double Celsisus = Convert.ToDouble(Console.ReadLine());//Hacemos que la entrada en consola se combierta a Double para poder hacer operaciones aritméticas
                    Console.WriteLine("\nLa formula para realizar la conversión es: {0}", Frm); //Mostramos en pantalla la fórmula utilizada, donde {0} es la cadena Frm
                    Op_conversor.OpCelFahr(Celsisus);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); //Imprimos la excepcion en caso de haber algún error (Por parte del usuario)
                }
                Console.Write("Otra temperatura que calcular? S/N: ");
                /*Creamos una condicion if, sin else, ya que este último vendría siendo el while; para mostrar en pantalla la cadena "go"
                 con la instrucción go.ToUpper() hacemos que el valor introducido se combierta a mayúsculas, y si no es igual a S (!= "S") hace que el bool rep
                 sea false, finalizando el bucle while
                 */
                string go = Console.ReadLine();
                if (go.ToUpper() != "S") 
                {
                    rep = false; //Cambiamos de true a false
                }
            }
        }

        #endregion
        #region Celsius-Kelvin
        public static void CelKel()
        {
            bool rep = true;
            const string Frm = "K= ºC + 273.15";
            while (rep)
            {
                try {
                    
                    Console.WriteLine("Introduce una temperatura en Grados Celsius a calcular");
                    double Celsius = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("\nLa formula para realizar la conversión es: {0}", Frm);
                    Op_conversor.OpCelKel(Celsius);//Llamamos a la funcion de calcular dando el valor introducido
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine("Otra temperatura que calcular (S/N): ");
                string go = Console.ReadLine();
                if (go.ToString() != "S")
                {
                    rep = false;
                }
            }
        }
        #endregion
        #region Kelvins-Celsius
        public static void KelCel()
        {
            bool rep = true;
            const string Frm = "ºC = K - 273.15";
            while (rep)
            {
                try
                {
                    Console.WriteLine("Introduce una temperatura en Kelvins a calcular");
                    double kelvin = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("\nLa formula para realizar la conversión es: {0}", Frm);
                    Op_conversor.OpKelCel(kelvin);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine("Otra temperatura que calcular (S/N): ");
                string go = Console.ReadLine();
                if (go.ToString() != "S")
                {
                    rep = false;
                }
            }
        }
        #endregion
        #region Fahrenheit-Kelvin
        public static void FahrKel()
        {
            bool rep = true;
            const string Frm = "K = (ºF - 32) * 5 / 9 + 273.15";
            while (rep)
            {
                try
                {
                    Console.WriteLine("Introduce una temperatura en grados Fahrenheit a calcular");
                    double fahr = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("\nLa formula para realizar la conversión es: {0}", Frm);
                    Op_conversor.OpFahrKel(fahr);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine("Otra temperatura que calcular (S/N): ");
                string go = Console.ReadLine();
                if (go.ToString() != "S")
                {
                    rep = false;
                }
            }
        }
        #endregion
        #region Kelvin-Fahrenheit
        public static void KelFahr()
        {
            bool rep = true;
            const string Frm = "ºF = (K -273.15) * 9 / 5 + 32";
            while (rep)
            {
                try
                {
                    Console.WriteLine("Introduce una temperatura en Kelvins a calcular");
                    double kelvin = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("\nLa formula para realizar la conversión es: {0}", Frm);
                    Op_conversor.OpKelFahr(kelvin);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine("Otra temperatura que calcular (S/N): ");
                string go = Console.ReadLine();
                if (go.ToString() != "S")
                {
                    rep = false;
                }
            }
        }
        #endregion
        #endregion
        #region Longitud
        const string reop = "Otra medida a convertir (S/N): ";//Vamos a ahorrar espacio creando una constante para las repeticiones
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
                    Op_conversor.OpKmMMN(km);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                Console.Write(reop);//llamamos a la constante reop declarada al inicio de la region Longitud, usamos solo Write para que se muestre a continuación el valor de S o N
                string inp = Console.ReadLine();
                if (inp.ToUpper() != "S")
                {
                    rep = false;
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
                    Op_conversor.OpMKm(Millas);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                Console.Write(reop);
                string inp = Console.ReadLine();
                if (inp.ToUpper() != "S")
                {
                    rep = false;
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
                    Op_conversor.OpMnKm(MNau);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
                Console.Write(reop);
                string inp = Console.ReadLine();
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
                    Op_conversor.OpM_MN(Millas);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
                Console.Write(reop);
                string inp = Console.ReadLine();
                if (inp.ToUpper() != "S")
                {
                    rep = false;
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
                    Op_conversor.OpMN_M(Millas_Nau);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                Console.Write(reop);
                string inp = Console.ReadLine();
                if (inp.ToUpper() != "S")
                {
                    rep = false;
                }
            }
        }
        #endregion
        #endregion
    }
}
