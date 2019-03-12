using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BetaLabUnidad3.Singleton;
using System.ComponentModel;
using BetaLabUnidad3.Models;

namespace BetaLabUnidad3.Models
{
    public class Pedidos : IComparable
    {
        [DisplayName("Nombre del cliente")]
        public string nameClient { get; set; }
        [DisplayName("Direccion de residencia")]
        public string direccion { get; set; }
        [DisplayName("NIT")]
        public string nit { get; set; }
        [DisplayName("Total a despachar")]
        public double total { get; set; }


        public void AgregarALista(Med medicamento)
        {
            DataAlmacenada.Instancia.ListaMed.Add(medicamento); //
        }

        public void AgregarAArbol(Med medicamento)
        {
            DataAlmacenada.Instancia.ArbolMed.AgregarNodoR(medicamento);
        }
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}