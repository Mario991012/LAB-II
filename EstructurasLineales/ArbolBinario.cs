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

        public void InsertarRaiz (T valor, Nodo<T> tmp)
        {
            //Nodo tmp que sirve como parametro para agregar al arbol
  
            //Si el arbol esta vacio 
            if(Raiz == null)
            {
                Raiz = tmp;
                tmp.Valor = valor;
                tmp.posicion = 0;
            }
            else
            {
                AgregandoHojas(valor, Raiz, tmp);
            }
          
        }

        public void AgregandoHojas(T valor, Nodo<T>papa, Nodo<T> hijo)
        {
            if (papa.Valor.CompareTo(hijo.Valor) > 0)//Si el nodo a agregar es mayor que la raiz
            {
                if (papa.Derecha == null) { hijo = papa.Derecha; }
                else { AgregandoHojas(valor, papa.Derecha, hijo); }
            }

            else if (papa.Valor.CompareTo(hijo.Valor) < 0)//Si el nodo a agregar es menor que la raiz
            {
                if (papa.Izquierda == null) { hijo = papa.Izquierda; }
                else { AgregandoHojas(valor, papa.Izquierda, hijo); }
            }
            else if (papa.Valor.CompareTo(hijo.Valor) == 0)
            {
                throw new DuplicateWaitObjectException("Duplicate objects are not allowed");
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

        public void Agregar(T valor)
        {
            throw new NotImplementedException();
        }
    }
}
