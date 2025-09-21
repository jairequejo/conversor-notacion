using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Nodo
    {
        public string Dato { get; set; }
        public Nodo Siguiente { get; set; }
        //public Nodo Anterior { get; set; }

        public Nodo(string dato)
        {
            this.Dato = dato;
            Siguiente = null;
            //Anterior = null;
        }
    }
}
