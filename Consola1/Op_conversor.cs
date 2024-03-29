﻿/*#########################################################
 *#    Copyright 2019 Zegameus Company Network Records    #
 *#                     Licencia MIT                      #
 *#########################################################
 */
using System;
//Vamos a separar las clases dependiendo de la unidad a convertir
namespace Zetaur
{
    /// <summary>
    /// Clase con los métodos de transformación de unidades de temperaturas.
    /// <list type="table">
    /// <listheader><term>Unidad</term><description>Nombre de completo de unidad</description></listheader>
    /// <item><term>ºC</term><description>Grados Celsius</description></item>
    /// <item><term>ºF</term><description>Grados Fahrenheits</description></item>
    /// <item><term>K</term><description>Grados Kelvin</description></item>
    /// </list>
    /// </summary>
    class Op_Temp
    {
        #region Celsius
        /// <summary>
        /// Método de conversión de Celsius a Fahrenheits y a Kelvins.
        /// </summary>
        /// <param name="cels">cels es un número double. Representa el valor entrante en celsius.</param>
        public static void Celsius(double cels)
        {
            double fahr = (cels * 9 / 5) + 32; //Establecemos un valor para los grados Fahrenheit y la operación oportuna para transformarlos de grados Celsius a Fahrenheit
            double kel = cels + 273.15;//Importante el punto es la coma en programación cuando hablamos de nº decimales
            Console.WriteLine("{0}ºC son {1}ºF y {2}K", cels, fahr, kel); //Imprimimos en pantalla el valor en Fahrenheit y Kelvins
        }
        #endregion
        #region Fahrenheits
        /// <summary>
        /// Método de conversión de Fahrenheits a Celisus y a Kelvins
        /// </summary>
        /// <param name="fahr">fahr es un número double. Representa el valor entrante en fahrenheits.</param>
        public static void Fahrenheits(double fahr)
        {
            double cels = (fahr - 32) * 5 / 9;//Importante restar primero
            double kel = (fahr - 32) * 5 / 9 + 273.15;
            Console.WriteLine("{0}ºF son {1}ºC y {2}K", fahr, cels, kel);
        }
        #endregion
        #region Kelvins
        /// <summary>
        /// Método de conversión de Kelvins al resto de unidades
        /// </summary>
        /// <param name="kelvin">Kelvin es un número double. Representa el valor entrante en Kelvins</param>
        public static void Kelvin(double kelvin)
        {
            double cels = kelvin - 273.15;
            double fahr = (kelvin - 273.15) * 9 / 5 + 32;
            Console.WriteLine("{0}K son {1}ºC y {2}ºF", kelvin, cels, fahr);
        }
        #endregion
        #region Rankine
        /// <summary>
        /// Método de conversión de Rankine al resto de unidades
        /// </summary>
        /// <param name="i"></param>
        public static void Rankine(double i)
        {
            double cels = (i - 491.67) * 5 / 9, fahr = i - 459.67, kel = i * 5 / 9, reaumur = (fahr - 32) * 4 / 9;
            Console.WriteLine($"{i}R son: \n{cels}ºC\n{fahr}ºF\n{reaumur}ºRe");
        }
        #endregion
    }

    /// <summary>
    /// Clase con los métodos de transformación de unidades de longitud.
    /// <list type="table">
    /// <listheader><term>Unidad</term><description>Nombre de completo de unidad</description></listheader>
    /// <item><term>m</term><description>Metros</description></item>
    /// <item><term>Km</term><description>Kilómetros</description></item>
    /// <item><term>Mi</term><description>Millas</description></item>
    /// <item><term>Nmi</term><description>Millas Náuticas</description></item>
    /// <item><term>in</term><description>Pulgadas</description></item>
    /// <item><term>Yd</term><description>Yardas</description></item>
    /// <item><term>ft</term><description>Pies</description></item>
    /// </list>
    /// </summary>
    class Op_Long
    {
        static readonly string[] longs = { "Metros (m)", "Kilómetros (Km)", "Millas (Mi)", "Millas Náuticas (Nmi)", "Pulgadas (in)", "Yardas (Yd)", "Pies (ft)" };
        #region Metros-kilometros
        /// <summary>
        /// Transforma Metros (m) al resto de unidades <see cref="Op_Long"/>.
        /// </summary>
        /// <param name="m">m es un número double.</param>
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
        /// <summary>
        /// Transforma Kilómetros (Km) al resto de unidades <see cref="Op_Long"/>.
        /// </summary>
        /// <param name="km">km es un número double.</param>
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
        /// <summary>
        /// Transforma Millas (Mi) al resto de unidades <see cref="Op_Long"/>.
        /// </summary>
        /// <param name="Mi">Mi es un número double.</param>
        public static void OpMi(double Mi)
        {
            double m = Mi * 1609, km = Mi * 1.609, inc = Mi * 63360, nmi = Mi / 1.151, yd = Mi * 1760, Pie = Mi * 5280; //Para reducir espacio, denominamos a todos los valores de salida como doubles a traves de comas.
            Console.WriteLine("{0} Millas son: {1} Millas Náuticas (Nmi).\n{2} Metros (m) o {3} Kilómetros.\n{4} Pulgadas (in).\n{5} Yardas (Yd).\n{6} Pies (ft).", Mi, nmi, m, km, inc, yd, Pie);
        }
        /// <summary>
        /// Transforma Millas Náuticas al resto de unidades <see cref="Op_Long"/>.
        /// </summary>
        /// <param name="Nmi">Nmi es un número double.</param>
        public static void OpNmi(double Nmi)
        {
            double m = Nmi * 1852, km = Nmi * 1.852, inc = Nmi * 72913, mi = Nmi * 1.151, yd = Nmi * 2025.37, pie = Nmi * 6076.12;
            Console.WriteLine("{0} {1} son:\n{2} {3}.\n{4} {5} o {6} {7}.\n{8} {9}.\n{10} {11}.\n{12} {13}.", Nmi, longs[3], mi, longs[2], m, longs[0], km, longs[1], inc, longs[4], yd, longs[5], pie, longs[6]);
        }
        #endregion
        #region Pulgadas-Yardas-Pies
        /// <summary>
        /// Transforma Pulgadas (in) al resto de unidades <see cref="Op_Long"/>
        /// </summary>
        /// <param name="Inc">Inc es un número double</param>
        public static void OpInc(double Inc)
        {
            double m = Inc / 39.97, km = Inc / 39970, mi = Inc / 63360, Nmi = Inc / 72913, yd = 36, pie = Inc / 12;
            Console.WriteLine("{0} {1} son:\n{2} {3} o {4} {5}.\n{6} {7} o {8} {9}.\n{10} {11}.\n{12} {13}.", Inc, longs[4], m, longs[0], km, longs[1], mi, longs[2], Nmi, longs[3], yd, longs[5], pie, longs[6]);
        }
        /// <summary>
        /// Transforma Yardas (Yd) al resto de unidades <see cref="Op_Long"/>
        /// </summary>
        /// <param name="Yd">Yd es número double.</param>
        public static void OpYd(double Yd)
        {
            double m = Yd / 1.094, km = m / 1000, Mi = Yd / 1760, Nmi = Yd / 2025, Inc = Yd * 36, pie = Yd * 3;
            Console.WriteLine("{0} {1} son:\n{2} {3} o {4} {5}.\n{6} {7} o {8} {9}.\n{10} {11}.\n{12} {13}.", Yd, longs[5], m, longs[0], km, longs[1], Mi, longs[2], Nmi, longs[3], Inc, longs[4], pie, longs[6]);
        }
        /// <summary>
        /// Transforma pies (ft) al resto de unidades <see cref="Op_Long"/>
        /// </summary>
        /// <param name="pie">pie es un número double.</param>
        public static void OpPie(double pie)
        {
            double m = pie / 3.281, km = m / 1000, Mi = pie / 5280, Nmi = pie / 6076, Inc = pie * 12, Yd = pie / 3;
            Console.WriteLine("{0} {1} son:\n{2} {3} o {4} {5}.\n{6} {7} o {8} {9}.\n{10} {11}.\n{12} {13}.", pie, longs[6], m, longs[0], km, longs[1], Mi, longs[2], Nmi, longs[3], Inc, longs[4], Yd, longs[5]);
        }
        #endregion
    }
    /// <summary>
    /// Accede a los métodos de conversión de unidades de masa.
    /// <list type="bullet">
    /// <item><description>Kilogramos</description></item>
    /// <item><description>Gramos</description></item>
    /// <item><description>Toneladas (métricas)</description></item>
    /// <item><description>Toneladas Cortas (Us t)</description></item>
    /// <item><description>Toneladas Largas (Uk t)</description></item>
    /// <item><description>Onzas</description></item>
    /// <item><description>Libras</description></item>
    /// <item><description>Stones</description></item>
    /// </list>
    /// </summary>
    class Op_Masa
    {
        /// <summary>
        /// 0 = Kg, 1 = g, 2 = t, 3 = US t, 4 = UK t, 5 = Oz, 6 = Lb, 7 = St
        /// </summary>
        static readonly string[] masas = { "Kilogramos (kg)", "Gramos (g)", "Toneladas (t)", "Tonelada Corta (US t)", "Tonelada larga (UK t)", "Onzas (Oz)", "Libras (lb)", "Stones (st)" };
        #region Kilogramos-Gramos
        /// <summary>
        /// Transforma Kilogramos al resto de unidades <see cref="Op_Masa"/>
        /// </summary>
        /// <param name="Kg">Kg es un número double.</param>
        public static void OpKg(double Kg)
        {
            double g = Kg * 1000, T = Kg / 1000, UsT = Kg / 907.185, UkT = Kg / 1016, Oz = Kg * 32.274, Lb = Kg * 2.20462, St = Kg / 6.35;
            Console.WriteLine("{0} {1} son:\n{2} {3}.\n{4} {5}, {6} {7} o {8} {9}.\n{10} {11}.\n{12} {13}.\n{14} {15}", Kg, masas[0], g, masas[1], T, masas[2], UsT, masas[3], UkT, masas[4], Oz, masas[5], Lb, masas[6], St, masas[7]);
        }
        /// <summary>
        /// Transforma Gramos (g) al resto de unidades <see cref="Op_Masa"/>
        /// </summary>
        /// <param name="g">g es un número double </param>
        public static void OpG(double g)
        {
            double Kg = g / 1000, T = Kg / 1000, UsT = g / 907185, UkT = g / (1.016 * Math.E + 6), Oz = g / 28.35, Lb = g / 454, St = g / 6350;
            //Para convertir de gramos a Tonelada larga (Uk t) tenemos que multiplicar por el número e, para ello usamos la clase Math.E
            //Es importante el uso de parentesis en la conversión de g a Uk t, porque sino dividirá entre 1.016, después multiplicara por e y por último sumara 6 al resultado final y eso no es lo que queremos.
            Console.WriteLine("{0} {1} son:\n{2} {3}.\n{4} {5}, {6} {7} o {8} {9}.\n{10} {11}.\n{12} {13}.\n{14} {15}", g, masas[1], Kg, masas[0], T, masas[2], UsT, masas[3], UkT, masas[4], Oz, masas[5], Lb, masas[6], St, masas[7]);
        }
        #endregion
        #region Toneladas
        /// <summary>
        /// Transforma toneladas (métricas) al resto de unidades <see cref="Op_Masa"/>.
        /// </summary>
        /// <param name="T">T es un número double.</param>
        public static void OpT(double T)
        {
            double Kg = T * 1000, g = Kg * 1000, UsT = T * 1.10231, UkT = T / 1.016, Oz = T * 35274, Lb = T * 2204.62, St = T * 157;
            Console.WriteLine("{0} {1} son:\n{2} {3} o {4} {5}.\n{6} {7} o {8} {9}.\n{10} {11}.\n{12} {13}.\n{14} {15}.", T, masas[2], Kg, masas[0], g, masas[1], UsT, masas[3], UkT, masas[4], Oz, masas[5], Lb, masas[6], St, masas[7]);
        }
        /// <summary>
        /// Transforma toneladas cortas (Us t) al resto de unidades <see cref="Op_Masa"/>.
        /// </summary>
        /// <param name="UsT">UsT es un número double.</param>
        public static void OpUsT(double UsT)
        {
            double Kg = UsT * 907.185, g = UsT * 907185, t = UsT / 1.10231, UkT = UsT / 1.12, Oz = UsT * 32000, Lb = UsT * 2000, St = UsT * 142.857;
            Console.WriteLine("{0} {1} son:\n{2} {3} o {4} {5}.\n{6} {7} o {8} {9}.\n{10} {11}.\n{12} {13}.\n{14} {15}.", UsT, masas[3], Kg, masas[0], g, masas[1], t, masas[2], UkT, masas[4], Oz, masas[5], Lb, masas[6], St, masas[7]);
        }
        /// <summary>
        /// Transforma Toneladas Cortas (Uk T) al resto de unidades <see cref="Op_Masa"/>
        /// </summary>
        /// <param name="UkT">UkT es un número double.</param>
        public static void OpUkT(double UkT)
        {
            double Kg = UkT * 1026, g = UkT * 1.016 * Math.E + 6, T = UkT * 1.016, UsT = UkT * 1.12, Lb = UkT * 2240, Oz = UkT * 35840, St = UkT * 160;
            Console.WriteLine("{0} {1} son:\n{2} {3} o {4} {5}.\n{6} {7} o {8} {9}.\n{10} {11}.\n{12} {13}.\n{14} {15}.", UkT, masas[4], Kg, masas[0], g, masas[1], T, masas[2], UsT, masas[3], Oz, masas[5], Lb, masas[6], St, masas[7]);
        }
        #endregion
        #region Libras-Onzas-Stones
        /// <summary>
        /// Transforma Onzas (Oz) al resto de unidades <see cref="Op_Masa"/>.
        /// </summary>
        /// <param name="Oz">Oz es un número double.</param>
        public static void OpOz(double Oz)
        {
            double Kg = Oz / 35.274, g = Oz * 28.3495, T = Oz / 35274, UsT = Oz / 35840, UkT = Oz / 32000, Lb = Oz / 16, St = Oz / 224;
            Console.WriteLine("{0} {1} son:\n{2} {3} o {4} {5}.\n{6} {7}, {8} {9} o {10} {11}.\n{12} {13}.\n{14} {15}.", Oz, masas[5], Kg, masas[0], g, masas[1], T, masas[2], UsT, masas[3], UkT, masas[4], Lb, masas[6], St, masas[7]);
        }
        /// <summary>
        /// Transforma Libras (Lb) al resto de unidades <see cref="Op_Masa"/>.
        /// </summary>
        /// <param name="Lb">Lb es un número double.</param>
        public static void OpLb(double Lb)
        {
            double Kg = Lb / 2.205, g = Lb / 454, T = Lb / 2205, UsT = Lb / 2240, UkT = Lb / 2000, Oz = Lb * 16, St = Lb / 14;
            Console.WriteLine("{0} {1} son:\n{2} {3} o {4} {5}.\n{6} {7}, {8} {9} o {10} {11}.\n{12} {13}.\n{14} {15}.", Lb, masas[6], Kg, masas[0], g, masas[1], T, masas[2], UsT, masas[3], UkT, masas[4], Oz, masas[5], St, masas[7]);
        }
        /// <summary>
        /// Transforma Stones (St) al resto de unidades <see cref="Op_Masa"/>.
        /// </summary>
        /// <param name="St">St es un número double.</param>
        public static void OpSt(double St)
        {
            double Kg = St * 6.35029, g = St * 6350.29, T = St / 157, UsT = St / 160, UkT = St / 143, Oz = St * 224, Lb = St * 14;
            Console.WriteLine("{0} {1} son:\n{2} {3} o {4} {5}.\n{6} {7}, {8} {9} o {10} {11}.\n{12} {13}.\n{14} {15}.", St, masas[7], Kg, masas[0], g, masas[1], T, masas[2], UsT, masas[3], UkT, masas[4], Oz, masas[5], Lb, masas[6]);
        }
        #endregion
    }
    /// <summary>
    /// Clase con los métodos de transformación de unidades de presión.
    /// <list type="table">
    /// <listheader><term>Unidad</term><description>Nombre de completo de unidad</description></listheader>
    /// <item><term>atm</term><description>Atmósferas Técnicas</description></item>
    /// <item><term>bar</term><description>Bares</description></item>
    /// <item><term>mbar</term><description>Milibares</description></item>
    /// <item><term>PSI</term><description>Libras por pulgada cuadrada</description></item>
    /// <item><term>Pa</term><description>Pascales</description></item>
    /// <item><term>hPa</term><description>Hectopascales</description></item>
    /// <item><term>mmHg</term><description>Milímetros de Mercurio</description></item>
    /// <item><term>torr</term><description>Torr</description></item>
    /// </list>
    /// </summary>
    class Op_Presion
    {
        /// <summary>
        /// 0 = Atm, 1 = bar, 2 = mbar, 3 = PSI, 4 = Pa, 5 = hPa, 6 = mmHg, 7 = Torr, 8 = kp/cm2
        /// </summary>
        static readonly string[] p = { "Atmósferas (atm)", "Bares (bar)", "Milibares (mbar)", "Libra por pulgada cuadrada (PSI)", "Pascales (Pa)", "Hectopascales (hPa)", "Milímetros de Mercurio (mmHg)", "Torr (torr)", "Kilopondio por centímetro cuadrado" };
        /// <summary>
        /// Transforma Atmósferas Técnicas al resto de unidades <see cref="Op_Presion"/>
        /// </summary>
        /// <param name="Atm">Atm es un número double que representa la cantidad a transformar</param>
        public static void OpAtm(double Atm)
        {
            double bar = Atm * 1.01325, mbar = Atm * 1013.25, PSI = Atm * 14.6959, Pa = Atm * 101325, hPa = Pa / 100, mmHg = Atm * 760, kpcm2 = Atm * 1.03323;
            Console.WriteLine($"{Atm} {p[0]} son:\n{bar} {p[1]} o {mbar} {p[2]}.\n{PSI} {p[3]}.\n{Pa} {p[4]} o {hPa} {p[5]}.\n{mmHg} {p[6]}/{p[7]}\n{kpcm2} {p[8]}");
        }
        public static void OpBar(double Bar)
        {
            double Atm = Bar / 1.01325, mBar = Bar * 1000, PSI = Bar * 14.5038, Pa = Bar * 100000, hPa = Pa / 100, mmHg = 750.062, kpcm2 = Bar * 1.01972;
            Console.WriteLine($"{Bar} {p[1]} son: {mBar} {p[2]}.\n{Atm} {p[0]}.\n{PSI} {p[3]}.\n{Pa} {p[4]} o {hPa} {p[5]}.\n {mmHg} {p[6]}/{p[7]}.\n{kpcm2} {p[8]}");
        }
        public static void OpmBar(double mBar)
        {
            double Atm = mBar / 1013.25, Bar = mBar / 1000, PSI = mBar * 68.948, Pa = mBar * 100, hPa = mBar, mmHg = mBar / 1.333, kpcm2 = mBar / 981;
            Console.WriteLine($"{mBar} {p[2]} son: {Bar} {p[1]}.\n{Atm} {p[0]}.\n{PSI} {p[3]}.\n{Pa} {p[4]} o {hPa} {p[5]}.\n {mmHg} {p[6]}/{p[7]}.\n{kpcm2} {p[8]}");
        }
        public static void OpPSI(double PSI)
        {
            double Atm = PSI / 14.696, Bar = PSI / 14.5038, mBar = Bar * 1000, Pa = PSI * 6895, hPa = PSI * 69.95, mmHg = PSI * 57.715, kpcm2 = PSI / 14.223;
            Console.WriteLine($"{PSI} {p[3]} son: {Bar} {p[1]} o {mBar} {p[2]}.\n{Atm} {p[0]}.\n{Pa} {p[4]} o {hPa} {p[5]}.\n {mmHg} {p[6]}/{p[7]}.\n{kpcm2} {p[8]}");
        }
        public static void OpPa(double Pa)
        {
            double Atm = Pa / 101325, Bar = Pa / 100000, mBar = Bar * 1000, PSI = Pa / 6895, hPa = Pa / 100, mmHg = Pa / 133, kpcm2 = Pa / 98067;
            Console.WriteLine($"{Pa} {p[4]} son: {Bar} {p[1]} o {mBar} {p[2]}.\n{Atm} {p[0]}.\n{PSI} {p[3]}.\n{hPa} {p[5]}.\n {mmHg} {p[6]}/{p[7]}.\n{kpcm2} {p[8]}");
        }
        public static void OphPa(double hPa)
        {
            double Pa = hPa * 100, Atm = Pa / 101325, Bar = Pa / 100000, mBar = Bar * 1000, PSI = Pa / 6895, mmHg = Pa / 133, kpcm2 = Pa / 98067;
            Console.WriteLine($"{hPa} {p[5]} son: {Bar} {p[1]} o {mBar} {p[2]}.\n{Atm} {p[0]}.\n{PSI} {p[3]}.\n{Pa} {p[4]}.\n {mmHg} {p[6]}/{p[7]}.\n{kpcm2} {p[8]}");
        }
        public static void OpmmHgTorr(double mmHgTorr)
        {
            double Atm = mmHgTorr / 760, Bar = mmHgTorr / 750, mBar = Bar * 1000, PSI = mmHgTorr / 51.715, Pa = mmHgTorr * 133, hPa = Pa / 100, kpcm2 = mmHgTorr / 735.559;
            Console.WriteLine($"{mmHgTorr} {p[6]}/{p[7]} son: {Bar} {p[1]} o {mBar} {p[2]}.\n{Atm} {p[0]}.\n{PSI} {p[3]}.\n{Pa} {p[4]} o {hPa} {p[5]}.\n{kpcm2} {p[8]}");
        }
        public static void Opkpcm2(double kpcm2)
        {
            double Atm = kpcm2 / 1.033, Bar = kpcm2 / 1.01972, mBar = Bar * 1000, PSI = kpcm2 * 14.223, Pa = kpcm2 * 98067, hPa = Pa / 100, mmHg = kpcm2 * 735.559;
            Console.WriteLine($"{kpcm2} {p[8]} son: {Bar} {p[1]} o {mBar} {p[2]}.\n{Atm} {p[0]}.\n{PSI} {p[3]}\n{Pa} {p[4]} o {hPa} {p[5]}.\n {mmHg} {p[6]}/{p[7]}.");
        }
    }
}