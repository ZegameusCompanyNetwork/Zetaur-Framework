using System;
using System.Text;

namespace Consola
{
    class Teclas
    {
        public void Wkeytouch() //IMPORTANTE, ESTE MÉTODO NO PUEDE SER Static
        {
            ConsoleKeyInfo entrada;
            do
            {
                Console.WriteLine("Pulsa una tecla, con Alt, Ctrl, o Shift.");
                Console.WriteLine("Pulsa Esc para salir.");
                entrada = Console.ReadKey(true); //Establecemos que la tecla introducida tiene importancia

                StringBuilder salida = new StringBuilder(string.Format("Has pulsado {0}", entrada.Key.ToString())); //{0} es para establecer el valor de input.key.ToString() en una posicion del texto
                bool modifiers = false; //hacemos que los modificadores Alt, Ctrl y Shift tengan el valor falso como que no están pulsados
                
                //Ahora comprobamos si la combinacion pulsada contiene Alt
                if ((entrada.Modifiers & ConsoleModifiers.Alt) == ConsoleModifiers.Alt)
                {
                    salida.Append(", con " + ConsoleModifiers.Alt.ToString());
                    modifiers = true;
                } 
                //Ahora comprobamos si la combinacion pulsada contiene Ctrl
                if ((entrada.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control)
                {
                    if (modifiers)
                    {
                        salida.Append(" y ");
                    }
                    else
                    {
                        salida.Append(", con ");
                        modifiers = true;
                    }
                    salida.Append(ConsoleModifiers.Control.ToString());
                }
                //Ahora comprobamos si la combinacion pulsada contiene Shift
                if ((entrada.Modifiers & ConsoleModifiers.Shift) == ConsoleModifiers.Shift)
                {
                    if (modifiers)
                    {
                        salida.Append(" y ");
                    }
                    else
                    {
                        salida.Append(", con ");
                        modifiers = true;
                    }
                    salida.Append(ConsoleModifiers.Shift.ToString());
                }
                salida.Append(".\n"); // Le ponemos el punto final
                Console.WriteLine(salida.ToString()); // Imprimimos todo en pantalla
            } while (entrada.Key != ConsoleKey.Escape);
        }
    }
}