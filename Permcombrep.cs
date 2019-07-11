using System;

namespace Consola
{
    class Permcombrep
    {
        public void Factorial()
        {
        Inicio:
            try
            {
                int obj1, res = 1;

                Console.WriteLine("Calculadora de factoriales \n Inserta numero a factorizar:");
                obj1 = int.Parse(Console.ReadLine());

                for (int i = 1; i <= obj1; i++)
                {
                    res = res * i;
                }

                Console.WriteLine("El factorial de " + obj1 + " es: " + res);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("El valor introducido no es válido, Error {0}", e);
                Console.Clear();
                goto Inicio;
            }
        }
    }
}
