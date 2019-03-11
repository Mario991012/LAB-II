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
        void EliminarNodo(Nodo<T> arbol, Nodo<T> eliminado);
    }
}
