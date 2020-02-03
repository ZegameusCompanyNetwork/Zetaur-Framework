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
            Console.WriteLine("{0}ºC son {1}ºF y {2} kelvins", cels, fahr, kel); //Imprimimos en pantalla el valor en Fahrenheit y Kelvins
        }
        #endregion
        #region Fahr-Celsius-Kel
        public static void OpFahrCelKel(double fahr)
        {
            double cels = (fahr - 32) * 5 / 9;//Importante restar primero
            double kel = (fahr - 32) * 5 / 9 + 273.15;
            Console.WriteLine("{0}ºF son {1}ºC y {2} kelvins", fahr, cels, kel);
        }
        #endregion
        #region Kelvins
        public static void OpKelFahrCels(double kelvin)
        {
            double cels = kelvin - 273.15;
            double fahr = (kelvin - 273.15) * 9 / 5 + 32;
            Console.WriteLine("{0} kelvins son {1}ºC y {2}ºF", kelvin, cels, fahr);
        }
        #endregion
    }
    class Op_Long
    {
        static readonly string[] longs = { "Metros (m)", "Kilómetros (Km)", "Millas (Mi)", "Millas Náuticas (Nmi)", "Pulgadas (in)", "Yardas (Yd)", "Pies (ft)" };
        #region Metros-kilometros
        public static void OpM(double m)
        {
            //escribimos todas las formulas a ejecutar, importante ponerlas como doubles para poder tener decimales
            double km = m / 1000;
            double inc = m * 39.97;
            double millas = km / 1.609;
            double m_nautica = km / 1.852;
            double Yd = km * 1093.613;
            double Pie = m * 3.281;
            Console.WriteLine("{0} {1} son:\n{2} {3}.\n{4} {5} o {6} {7}.\n{8} {9}.\n{10} {11}.\n{12} {13}.", m, longs[0], km, longs[1], millas, longs[2], m_nautica, longs[3], inc, longs[3], Yd, longs[4], Pie, longs[5]);//Para reducir el texto de salida, creamos un formato de salida. Solo lo uso en este caso para mostrar 
        }
        public static void OpKm(double km)
        {
            double m = km * 1000;
            double inc = km * 39370;
            double millas = km / 1.609;
            double m_nauticas = km / 1.852;
            double Yd = m * 1093.613;
            double Pie = m * 3.281;
            Console.WriteLine("{0} Kilómetros son: {1} Metros (m).\n{2} Millas (Mi) o {3} Millas náuticas(Nmi).\n{4} Pulgadas (in).\n{5} Yardas (Yd).\n{6} Pies (ft).", km, m, millas, m_nauticas, inc, Yd, Pie);
        }
        #endregion
        #region Millas
        public static void OpMi(double Mi)
        {
            double m = Mi * 1609, km = Mi * 1.609, inc = Mi * 63360, nmi = Mi / 1.151, yd = Mi * 1760, Pie = Mi * 5280; //Para reducir espacio, denominamos a todos los valores de salida como doubles a traves de comas.
            Console.WriteLine("{0} Millas son: {1} Millas Náuticas (Nmi).\n{2} Metros (m) o {3} Kilómetros.\n{4} Pulgadas (in).\n{5} Yardas (Yd).\n{6} Pies (ft).", Mi, nmi, m, km, inc, yd, Pie);
        }
        public static void OpNmi(double Nmi)
        {
            double m = Nmi * 1852, km = Nmi * 1.852, inc = Nmi * 72913, mi = Nmi * 1.151, yd = Nmi * 2025.37, pie = Nmi * 6076.12;
            Console.WriteLine("{0} {1} son:\n{2} {3}.\n{4} {5} o {6} {7}.\n{8} {9}.\n{10} {11}.\n{12} {13}.", Nmi, longs[3], mi,longs[2], m,longs[0], km,longs[1],inc, longs[4], yd,longs[5], pie, longs[6]);
        }
        #endregion
        #region Pulgadas-Yardas-Pies
        public static void OpInc(double Inc){
            double m = Inc / 39.97, km = Inc / 39970, mi = Inc / 63360, Nmi = Inc / 72913, yd = 36, pie = Inc / 12;
            Console.WriteLine("{0} {1} son:\n{2} {3} o {4} {5}.\n{6} {7} o {8} {9}.\n{10} {11}.\n{12} {13}.", Inc,longs[4],m,longs[0],km,longs[1],mi,longs[2],Nmi,longs[3],yd,longs[5],pie,longs[6]);
        }
        public static void OpYd(double Yd)
        {
            double m = Yd / 1.094, km = m / 1000, Mi = Yd / 1760, Nmi = Yd / 2025, Inc = Yd * 36, pie = Yd * 3;
            Console.WriteLine("{0} {1} son:\n{2} {3} o {4} {5}.\n{6} {7} o {8} {9}.\n{10} {11}.\n{12} {13}.", Yd,longs[5],m,longs[0],km,longs[1],Mi,longs[2],Nmi,longs[3],Inc,longs[4],pie,longs[6]);
        }
        public static void OpPie (double pie) 
        {
            double m = pie / 3.281,km = m /1000, Mi = pie / 5280,Nmi = pie / 6076,Inc = pie * 12, Yd = pie /3;
            Console.WriteLine("{0} {1} son:\n{2} {3} o {4} {5}.\n{6} {7} o {8} {9}.\n{10} {11}.\n{12} {13}.", pie,longs[6],m,longs[0],km,longs[1],Mi,longs[2],Nmi,longs[3],Inc,longs[4],Yd,longs[5]);
        }
        #endregion
    }
}