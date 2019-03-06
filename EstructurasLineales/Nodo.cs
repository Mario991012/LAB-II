using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasLineales
{
    public class Nodo<T>
    {
        public Nodo<T> Siguiente { get; set; }
        public Nodo<T> Anterior { get; set; }

        public Nodo<T> Derecha { get; set; }
        public Nodo<T> Izquierda { get; set; }

        public T Valor { get; set; }
        public int posicion { get; set; }

        public Nodo(T valor)
        {
            //Atributos en constructor
            Valor = valor;

            Siguiente = null;
            Anterior = null;

            Derecha = null;
            Izquierda = null;

            posicion = 0;
        }
    }
}
