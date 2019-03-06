using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasLineales
{
    class ArbolBinario<T> : IEstructurasLineales<T>, IEnumerable<T> where T : IComparable
    {
        public Nodo<T> Raiz { get; set; }

        //Constructor
        public ArbolBinario()
        {
            Raiz = null;
        }

        public void Insertar (T valor)
        {
            //Nodo Raiz auxiliar para no modificar la raiz del arbol
            var RaizAux = Raiz;
            //Creando el nodo con su respectivo valor
            var Nodo = new Nodo<T>(valor);

            //Si el arbol esta vacio 
            if(Raiz == null)
            {
                Raiz = Nodo;
                Nodo.Valor = valor;
                Nodo.posicion = 0;
            }
            //Si el valor a insertar es mayor a la raiz
            else if (Nodo.Valor.CompareTo(RaizAux.Valor) > 0)
            {   
                RaizAux.Derecha = Raiz;
                Insertar(valor);
            }
            //Si el valor a insertar es menor a la raiz
            else if (Nodo.Valor.CompareTo(RaizAux.Valor) < 0)
            {
                RaizAux.Izquierda = Raiz;
                Insertar(valor);
            }
            //Si el valor a insertar es igual a la raiz
            else if (Nodo.Valor.CompareTo(RaizAux.Valor) == 0)
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var NodoAux = Raiz;
            while (NodoAux != null)
            {
                yield return NodoAux.Valor;
                NodoAux = NodoAux.Derecha;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

         
    }
}
