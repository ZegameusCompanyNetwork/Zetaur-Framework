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
        #region Celsius-Fahr-Kel
        public static void OpCelFahrKel(double cels)
        {
            double fahr = (cels * 9 / 5) + 32; //Establecemos un valor para los grados Fahrenheit y la operación oportuna para transformarlos de grados Celsius a Fahrenheit
            double kel = cels + 273.15;//Importante el punto es la coma en programación cuando hablamos de nº decimales
            Console.WriteLine("{0}ºC son {1}ºF y {2} kelvins",cels,fahr,kel); //Imprimimos en pantalla el valor en Fahrenheit y Kelvins
        }
        #endregion
        #region Fahr-Celsius-Kel
        public static void OpFahrCelKel(double fahr)
        {
            double cels = (fahr - 32) * 5 / 9;//Importante restar primero
            double kel = (fahr - 32) * 5 / 9 + 273.15;
            Console.WriteLine("{0}ºF son {1}ºC y {2} kelvins", fahr,cels,kel);
        }
        #endregion
        #region Kelvins
        public static void OpKelFahrCels(double kelvin)
        {
            double cels = kelvin - 273.15;
            double fahr = (kelvin - 273.15) * 9 / 5 + 32;
            Console.WriteLine("{0} kelvins son {1}ºC y {2}ºF",kelvin,cels,fahr);
        }
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
            Console.WriteLine("{0} metros son {1} pies.",M,Pie);
            Console.WriteLine("Para obtener un valor aproximado se multiplican los metros por 3.281");
        }
        public static void OpPieM(double Pie)
        {
            double M = Pie / 3.281;
            Console.WriteLine("{0} pies son {1} metros",Pie,M);
            Console.WriteLine("Para obtener un valor aproximado se dividen los pies entre 3.281");
        }
        #endregion
        #region Millas-Yardas
        public static void OpMMNYd(double Millas)
        {
            double Yd = Millas * 1760;
            double Yd1 = Millas * 2025.372;
            Console.WriteLine("{0} millas son {1} yardas.",Millas,Yd);
            Console.WriteLine("{0} millas náuticas son {1} yardas",Millas,Yd1);
            Console.WriteLine("Para obtener un valor aproximado se multiplican las millas por 1760 para obtener Yardas.\nO se multiplican las millas náuticas por 2025.372 para obtener yardas.");
        }
        public static void OpYdMMN(double Yardas)
        {
            double Millas = Yardas / 1760;
            double MiNa = Yardas / 2025.372;
            Console.WriteLine("{0} yardas son {1} millas y {2} millas náuticas.", Yardas, Millas, MiNa);
            Console.WriteLine("Para obtener un valor aproximado se dividen las yardas entre 1760 para obtener Millas.\nY entre 2025.372 para obtener las millas náuticas.");
        }
        #endregion
        #endregion
    }
}