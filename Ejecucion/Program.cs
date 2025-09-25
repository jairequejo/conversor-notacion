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
        static int Precedencia(string op)
        {
            if (op == "+" || op == "-")
            {
                return 1;
            }
            if (op == "*" || op == "/") 
            {
                return 2;
            }
            return 0;
        }
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
                    // Se agrega el numero actual a la lista
                    if (numeroActual != "")
                    {
                        lista.Insertar(numeroActual);
                        numeroActual = ""; // Reinicio
                    }

                    string operador = caracter.ToString();

                    if (operador == "(")
                    {
                        pila.Push(operador);
                    }
                    else if (operador == ")")
                    {
                        while (!pila.EstaVacia() && pila.Peek() != "(")
                        {
                            lista.Insertar(pila.Pop());
                        }
                        if (!pila.EstaVacia() && pila.Peek() == "(")
                        {
                            pila.Pop();
                        }
                    }
                    else if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
                    {
                        // Mientras la pila no esté vacía y la jerarquia del operador en la cima de la pila sea mayor o igual a la del operador actual   
                        while (!pila.EstaVacia() && Precedencia(pila.Peek()) >= Precedencia(operador))
                        {
                            lista.Insertar(pila.Pop());
                        }
                        pila.Push(operador);
                    }
                    else
                    {
                        Console.WriteLine($"Carácter no válido: {caracter}");
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

            // Mostrar la expresión en notación postfija
            Console.WriteLine("Expresión en notación postfija:");
            lista.Recorrer();
        }
    }
}
