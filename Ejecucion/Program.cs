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
                    // Leer el operador
                    if ("+" == caracter.ToString() || "-" == caracter.ToString() || "*" == caracter.ToString() || "/" == caracter.ToString())
                    {
                        pila.Push(caracter.ToString());
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
            Console.WriteLine("Expresión en notación postfija:");
            lista.Recorrer();
        }
    }
}
