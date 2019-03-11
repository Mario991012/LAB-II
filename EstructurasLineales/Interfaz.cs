using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasLineales
{
    interface Interfaz<T>
    {
        void AgregarNodoR(Nodo<T> Nodo, Nodo<T>papa, T valor);
        void AgregarHojas(Nodo<T> Arbol, Nodo<T> hijo, Nodo<T> papa, T hojaV);
        bool BuscarNodo(Nodo<T> buscado);
        void EliminarNodo(Nodo<T> arbol, Nodo<T> eliminado);//Metodo para encontrar la ubicacion del metodo a eliminar
        void Borrar(Nodo<T> borrado); //Metodo que SI elimina el nodo
        Nodo<T> Minimo(Nodo<T>tmp);  //Cuando tiene 2hijos, se mueve uno a la derecha, y recorre hasta encontrar el menor de la izquierda
        void Reemplazar(Nodo<T> arbol, Nodo<T> nuevo); //Cambia los apuntadores, para que se elimine un nodo
        void Destruir(Nodo<T> destruido); //Lo elimina, dejandolo sin hijos 
    }
}
