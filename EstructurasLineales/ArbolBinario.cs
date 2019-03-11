using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasLineales
{
    public class ArbolBinario<T> : Interfaz<T>, IEnumerable<T> where T : IComparable
    {
        public Nodo<T> RaizAux { get; set; }//Para formar el arbol
        public ArbolBinario() { RaizAux = null; }//Metodo constructor

        public void AgregarNodoR(Nodo<T> Nodo, Nodo<T> papa, T value)//El que quiero insertar, su papa, su valor
        {
            if (RaizAux ==  null)
            {
                RaizAux = Nodo;
                RaizAux.posicion = Nodo.posicion;
                RaizAux.valor = value;
                papa = null;
                RaizAux.Creador = papa;
            }
            else
            {
                AgregarHojas(RaizAux, Nodo, papa, value);
            }
        }

        public void AgregarHojas(Nodo<T> Arbol, Nodo<T> hijo, Nodo<T> papa, T hojaV)
        {
            if ((int)MyDelegate.DynamicInvoke(Arbol, hijo) > 0)//Verifico si va hacia la derecha
            {
                if (Arbol.Derecha == null) //Si el lado derecho esta vacio
                {
                    Arbol.Derecha = hijo;
                    Arbol.Derecha.valor = hojaV;
                    Arbol.Derecha.Creador = Arbol;
                    
                }
                else //De lo contrario, lo vuelve a llamar hasta encontrarle un espacio
                {
                    AgregarHojas(Arbol.Derecha, hijo, Arbol, hojaV);
                }
            }
            else if ((int)MyDelegate.DynamicInvoke(Arbol, hijo) < 0)//Verifico si va hacia la izquierda
            {
                if (Arbol.Izquierda == null) //Si el lado izquierdo esta vacio
                {
                    Arbol.Izquierda = hijo;
                    Arbol.Izquierda.valor = hojaV;
                    Arbol.Izquierda.Creador = Arbol;
                }
                else//De lo contrario, lo vuelve a llamar hasta encontrarle un espacio
                {
                    AgregarHojas(Arbol.Izquierda, hijo, Arbol, hojaV);
                }
            }
            else if ((int)MyDelegate.DynamicInvoke(Arbol, hijo) == 0)//Verifico si va hacia la derecha
            {
                throw new DuplicateWaitObjectException("DUPLICADOS NO EXISTEN EN ARBOL");
            }
        }      

        public bool BuscarNodo(Nodo<T> buscado)
        {
            if (RaizAux == null) { return false; }// si el arbol esta vacio
            else if ((int)MyDelegate.DynamicInvoke(RaizAux.valor, buscado.valor) == 0) { return true; }//Si la raiz es el que se busca
            else if ((int)MyDelegate.DynamicInvoke(RaizAux.valor, buscado.valor) < 0) { return BuscarNodo(RaizAux.Izquierda); }//Si la raiz es el que se busca
            else if ((int)MyDelegate.DynamicInvoke(RaizAux.valor, buscado.valor) > 0) { return BuscarNodo(RaizAux.Derecha); }//Si la raiz es el que se busca
            return ; //No se que retornar

            //ESTE METODO RETORNA TRUE OR FALSE... ENTONCES, CUANDO LO LLAMEMOS EN EL CONTROLADOR, DEBEMOS DE PONER ANTES UN CONDICIONAL PARA QUE FUNCIONE
        }

        public void EliminarNodo(Nodo<T>arbol, Nodo<T>eliminado)
        {
            if (RaizAux == null) { return; }//Si el arbol esta vacio
            else if ((int)MyDelegate.DynamicInvoke(arbol.valor, eliminado.valor) >0 )
            {

            }
            
        }

        public IEnumerator<T> GetEnumerator()
        {
            var NodoAux = RaizAux;
            while (NodoAux != null)
            {
                yield return NodoAux.valor;
                NodoAux = NodoAux.Derecha;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //Metodos de comparacion entre nodos que actuaran como delegados
        public static Comparison<Nodo<T>> CompareByName = delegate (Nodo<T> n1, Nodo<T> n2)
        {
            return n1.valor.CompareTo(n2.valor);
        };

        //Creacion del delegado
        public delegate int Delegado(Nodo<T> n1, Nodo<T> n2);

        //Instancia del tipo delegado y referencia al metodo
        Delegado MyDelegate = new Delegado(CompareByName);
    }
}
