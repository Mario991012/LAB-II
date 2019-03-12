using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BetaLabUnidad3.Singleton;
using System.ComponentModel;
using BetaLabUnidad3.Models;

namespace BetaLabUnidad3.Models
{
    public class Med : IComparable
    {
        [DisplayName("ID")]
        public string id { get; set; }
        [DisplayName("Nombre de Medicamento")]
        public string Nombre { get; set; }
        [DisplayName("Descripcion")]
        public string descripcion { get; set; }
        [DisplayName("Casa Medica")]
        public string casa { get; set; }
        [DisplayName("Precio de Medicamento")]
        public double precio { get; set; }
        [DisplayName("En existencia")]
        public int existencia { get; set; }

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