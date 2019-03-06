using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EstructurasLineales
{
    public class ListaDoblementeEnlazada<T> : IEstructurasLineales<T>, IEnumerable<T> where T : IComparable
    {
        public Nodo<T> Cabeza { get; set; }
        public int tamaño { get; set; }

        public void Agregar(T valor)
        {
            var Nodo = new Nodo<T>(valor);
            if (tamaño == 0)
            {
                Cabeza = Nodo;
                tamaño++;
                Nodo.posicion = 0;
            }
            else
            {
                var NodoAux = Cabeza;
                while (NodoAux.Siguiente != null)
                {
                    NodoAux = NodoAux.Siguiente;
                }

                NodoAux.Siguiente = Nodo;
                Nodo.Anterior = NodoAux;
                tamaño++;
                Nodo.posicion = Nodo.Anterior.posicion + 1;
            }
            
        }

        public bool SimularSalida()
        {
            return false;
        }

        public T Get(int posicion)
        {
            var current = Cabeza;
            for (int i = 0; i < posicion - 1; i++)
            {
                current = current.Siguiente;
            }

            return current.Valor;
        }

        public IEnumerator<T> GetEnumerator()
        {
                var NodoAux = Cabeza;
                while (NodoAux != null)
                {
                    yield return NodoAux.Valor;
                    NodoAux = NodoAux.Siguiente;
                }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
