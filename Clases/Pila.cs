using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Pila
    {
        private Nodo cima;

        public Pila()
        {
            cima = null;
        }

        public void Push(string dato)
        {
            Nodo nuevo = new Nodo(dato);
            nuevo.Siguiente = cima;
            cima = nuevo;
        }

        public string Pop()
        {
            string dato = cima.Dato;
            cima = cima.Siguiente;
            return dato;
        }

        public bool EstaVacia()
        {
            return cima == null;
        }
    }
}
