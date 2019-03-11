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
            else if ((int)MyDelegate.DynamicInvoke(RaizAux.valor, buscado.valor) < 0) { return BuscarNodo(RaizAux.Izquierda); }//Si es menor el dato, se vuelve a llamar
            else { return BuscarNodo(RaizAux.Derecha); }//Si es mayor el dato, se vuelve a llamar
            
            //ESTE METODO RETORNA TRUE OR FALSE... ENTONCES, CUANDO LO LLAMEMOS EN EL CONTROLADOR, DEBEMOS DE PONER ANTES UN CONDICIONAL PARA QUE FUNCIONE
        }

        public void EliminarNodo(Nodo<T>arbol, Nodo<T>eliminado)//Envio la raiz y el nodo a eliminar
        {
            if (arbol == null) { return; }//Si el arbol esta vacio

            else if ((int)MyDelegate.DynamicInvoke(arbol.valor, eliminado.valor) > 0) //Si el valor es mayor
            { EliminarNodo(arbol.Derecha, eliminado); } //Recursividad hacia la derecha

            else if ((int)MyDelegate.DynamicInvoke(arbol.valor, eliminado.valor) < 0) //Si el valor es menor
            { EliminarNodo(arbol.Izquierda, eliminado); }//Recursividad hacia la izquierda

            else if ((int)MyDelegate.DynamicInvoke(arbol.valor, eliminado.valor) == 0) //Cuando lo encuentre
            { Borrar(arbol); }//Llama al metodo para verificar cuantos hijos tiene
        }

        public void Borrar(Nodo<T> borrado)//Revisa cuantos hijos tiene (NODO A ELIMINAR)
        {
            if ((borrado.Derecha !=null) &&(borrado.Izquierda != null)) //Si tiene ambos hijos
            {
                Nodo<T> Nodo = Minimo(borrado.Derecha);//Instanceo el nodo, que se define como el menor de la derecha
                borrado.valor = Nodo.valor; //Reemplazo el valor del nodo a borrar con el del izquierdo mas pequenio
                Borrar(Nodo);
            }
            else if (borrado.Izquierda!= null) //Cuando solo tenga un hijo izquierdo
            {
                Reemplazar(borrado, borrado.Izquierda);
                Destruir(borrado);
            }
            else if (borrado.Derecha != null) //Cuando solo tenga un hijo izquierdo
            {
                Reemplazar(borrado, borrado.Derecha);
                Destruir(borrado);
            }
            else  //Cuando sea una hoja el nodo a eliminar
            {
                Reemplazar(borrado, null);
                Destruir(borrado);
            } 

        }
        public Nodo<T> Minimo(Nodo<T> tmp)//Funcion para determinar el nodo mas izquierdo derecho
        {
            if (tmp == null) { return null; }//Si el arbol esta vacio
            else if (tmp.Izquierda != null) { return Minimo(tmp.Izquierda); }//va a recorrer izquierda hasta encontrar el menor de la derecha
            else { return tmp; }
                    
        }
        //Le mandamos el nodo a eliminar y su hijo NUEVO= HIJO DERECHO O IZQUIERDO
        public void Reemplazar(Nodo<T> arbol, Nodo<T> nuevo) //Cuando tenga un solo hijo (ya sea izquierda o derecha))
        {
            if (arbol.Creador != null)//El padre apunta a nuevo padre
            {
                if ((int)MyDelegate.DynamicInvoke(arbol.valor,arbol.Creador.Izquierda.valor) == 0) //Si es el hijo izquierdo
                {
                    arbol.Creador.Izquierda = nuevo; //El padre convierte a su hijo izquierdo el hijo del eliminado
                }
                else if((int)MyDelegate.DynamicInvoke(arbol.valor, arbol.Creador.Derecha.valor) == 0)
                {
                    arbol.Creador.Derecha = nuevo; //El padre convierte a su hijo izquierdo el hijo del eliminado
                }
            }
            if (nuevo != null) //Le asignamos un padre
            { nuevo.Creador = arbol.Creador; }
        }

        public void Destruir(Nodo<T> destruido)
        {
            destruido.Derecha = null;
            destruido.Izquierda = null;
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
