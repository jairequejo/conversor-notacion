using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ListaEnlazada
    {
        private Nodo primero;
        private Nodo ultimo;

        public void Insertar(string dato)
        {
            Nodo nuevo = new Nodo(dato);
            if (primero == null)
            {
                primero = nuevo;
                ultimo = nuevo;
            }
            else
            {
                ultimo.Siguiente = nuevo;
                ultimo = nuevo;
            }
        }

        public void Recorrer()
        {
            Nodo actual = primero;
            while (actual != null)
            {
                Console.Write(actual.Dato + " ");
                actual = actual.Siguiente;
            }
            Console.WriteLine();
        }
    }
}
