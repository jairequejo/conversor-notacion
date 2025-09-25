using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Nodo
    {
        public string Dato;
        public Nodo Siguiente;

        public Nodo(string dato)
        {
            this.Dato = dato;
            Siguiente = null;
        }
    }
}
