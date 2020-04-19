using System;

namespace Zetaur
{
    class Permcombrep
    {
        public void Factorial()
        {
        Inicio:
            double num;//Para permitir la introducción de valores decimales
            double res = 1;//Este es el valor de salida, (A de ser double para permitir decimales
            Console.WriteLine("Calculadora de factoriales \n Inserta numero a factorizar:");
            try
            {
                num = double.Parse(Console.ReadLine());

                for (int i = 1; i <= num; i++)
                {
                    res = res * i;
                }

                Console.WriteLine("El factorial de {0} es: {1}", num, res);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("El valor introducido no es válido, Error {0}", e);
                Console.Clear();
                goto Inicio;
            }
        }
    }
}
