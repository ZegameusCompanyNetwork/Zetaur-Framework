/*#########################################################
 *#    Copyright 2019 Zegameus Company Network Records    #
 *#                     Licencia MIT                      #
 *#########################################################
 */
using System;
//Vamos a separar las clases dependiendo de la unidad a convertir
namespace Consola
{
    class Op_Temp
    {
        #region Temperatura
        #region Celsius-Fahrenheit
        public static void OpCelFahr(double cels) //Necesitamos un valor para poder hacer la operación, por eso ponemos en el párentesis el tipo de valor y un nombre para poder usarlo más tarde
        {
            double fahr = (cels * 9 / 5) + 32; //Establecemos un valor para los grados Fahrenheit y la operación oportuna para transformarlos de grados Celsius a Fahrenheit
            Console.WriteLine(fahr); //Imprimimos en pantalla el valor en Fahrenheit
        }
        public static void OpFarcel(double fahr)
        {
            double cels = (fahr - 32) * 5 / 9;
            Console.WriteLine("Son {0}ºC", cels);
        }
        #endregion
        #region Celsius-Kelvin
        public static void OpCelKel(double celsius)
        {
            double kelvin = celsius + 273.15; //Importante el punto es la coma en numeros decimales en la programación
            Console.WriteLine("Son {0}K", kelvin); //Imprimimos el valor en pantalla seguido de su unidad
        }
        public static void OpKelCel(double kelvin)
        {
            double cels = kelvin - 273.15;
            Console.WriteLine("Son {0}ºC", cels);
        }
        #endregion
        #region Fahrenheit-Kelvin
        public static void OpFahrKel(double fahrenheit)
        {
            double kelvin = (fahrenheit - 32) * 5 / 9 + 273.15;//Importante el punto es la coma en numeros decimales en la programación
            Console.WriteLine("Son {0}K", kelvin);//K es la abreviatura de Kelvins
        }
        public static void OpKelFahr(double kelvin)
        {
            double fahr = (kelvin - 273.15) * 9 / 5 + 32;
            Console.WriteLine("Son {0}ºF", fahr);
        }
        #endregion
        #endregion
    }
    class Op_Long
    {
        #region Longitud
        #region Kilometros-Millas-M.Náuticas
        public static void OpKmMMN(double km)
        {
            double millas = km / 1.609;
            double m_nautica = km / 1.852;
            Console.WriteLine("{0}km son {1} millas y {2} millas náuticas", km, millas, m_nautica);//Devolvemos el resultado
            Console.WriteLine("Para convertir de kilometros a millas se divide entre 1.609 y entre 1.852 si es para millas náuticas");//Explicación al usuario
        }
        public static void OpMKm(double Millas)
        {
            double km = Millas * 1.609;
            Console.WriteLine("{0} millas son {1}km", Millas, km);//Devolvemos el resultado
            Console.WriteLine("Para convertir de millas a kilometros se multiplica por 1.609");//Explicación al usuario
        }
        public static void OpMnKm(double Millas_nauticas)
        {
            double km = Millas_nauticas * 1.852;
            Console.WriteLine("{0} millas náuticas son {1}km", Millas_nauticas, km);//Devolvemos el resultado
            Console.WriteLine("Para convertir de millas náuticas a kilometros se multiplica por 1.852");//Explicación al usuario
        }
        public static void OpM_MN(double Millas)
        {
            double M_nau = Millas / 1.151;
            Console.WriteLine("{0} millas son {1} millas náuticas", Millas, M_nau);//Devolvemos el resultado
            Console.WriteLine("Para convertir de millas náuticas a millas se divide entre 1.151");//Explicación al usuario
        }
        public static void OpMN_M(double Millas_nauticas)
        {
            double Millas = Millas_nauticas * 1.151;
            Console.WriteLine("{0} millas náuticas son {1} millas", Millas_nauticas, Millas);//Devolvemos el resultado
            Console.WriteLine("Para convertir de millas náuticas a millas se multiplica por 1.151");//Explicación al usuario
        }
        #endregion
        #region Kilómetros-Yardas
        public static void OpKmYd(double Km)
        {
            double Yd = Km * 1093.613;
            Console.WriteLine("{0}Km son {1} yardas", Km, Yd);
            Console.WriteLine("Para pasar de Kilometros a Yardas se multiplica por 1093.613 los Km.");
        }
        public static void OpYdKm(double Yd)
        {
            double Km = Yd / 1093.613;
            Console.WriteLine("{0} Yardas son {1}Km",Yd,Km);
            Console.WriteLine("Para pasar de Yd a Km se divide entre 1093.613 las Yd.");
        }
        #endregion
        #region M - Pie
        public static void OpMPie(double M)
        {
            double Pie = M * 3.281;
            Console.WriteLine("{0} metros son {1} pies",M,Pie);
            Console.WriteLine("Para obtener un valor aproximado se multiplican los metros por 3.281");
        }
        public static void OpPieM(double Pie)
        {
            double M = Pie / 3.281;
            Console.WriteLine("{0} pies son {1} metros",Pie,M);
        }
        #endregion
        #endregion
    }
}