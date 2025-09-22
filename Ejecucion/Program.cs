using Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Ejecucion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListaEnlazada lista = new ListaEnlazada();
            Pila pila = new Pila();

            Console.WriteLine("Ingrese una expresión matemática:");
            string expresion = Console.ReadLine();
            string numeroActual = "";

            foreach (char caracter in expresion)
            {
                if (char.IsWhiteSpace(caracter)) // Ignorar espacios en blanco
                {
                    continue;
                }
                if (char.IsDigit(caracter))
                {
                    // Construir el número actual
                    numeroActual += caracter;
                }
                else
                {
                    // Se agrega el numero actual a la lista si existe
                    if (numeroActual != "")
                    {
                        lista.Insertar(numeroActual);
                        numeroActual = ""; // Reinicio
                    }

                    string op = caracter.ToString();

                    if (op == "(")
                    {
                        pila.Push(op);
                    }

                    else if (op == ")")
                    {
                        // Mientras la pila no esté vacía y el tope no sea '(',
                        while (!pila.EstaVacia() && pila.Peek() != "(")
                        {
                            lista.Insertar(pila.Pop()); // desapilar operadores y agregarlos a la lista.
                        }

                        // Al final, sacar el '(' de la pila para descartarlo
                        if (!pila.EstaVacia() && pila.Peek() == "(")
                        {
                            pila.Pop();
                        }
                    }

                    // Leer el operador
                    if ("+" == caracter.ToString() || "-" == caracter.ToString() || "*" == caracter.ToString() || "/" == caracter.ToString())
                    {
                        pila.Push(caracter.ToString());
                    }
                    else
                    {
                        if (caracter != '(' && caracter != ')')
                        {
                            Console.WriteLine($"Carácter no válido: {caracter}");
                        }
                    }
                }
            }

            // Leer el ultimo número que no entra al else
            if (numeroActual != "")
            {
                lista.Insertar(numeroActual);
            }

            // Desapilar todos los operadores restantes y agregarlos a la lista
            while (!pila.EstaVacia())
            {
                lista.Insertar(pila.Pop());
            }
            Console.WriteLine("Expresión en notación postfija:");
            lista.Recorrer();
        }
    }
}
