﻿using System;
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
        public string ClientName { get; set; }
        [DisplayName("Direccion de residencia")]
        public string direccion { get; set; }
        [DisplayName("NIT")]
        public string nit { get; set; }
        [DisplayName("Total a despachar")]
        public double total { get; set; }
        [DisplayName("Medicamentos Agregados")]
        public List<Med> ListaAgregar { get; set; }
        public string Medicamentos { get; set; }

        public List<Med> nuevo = new List<Med>(); 
        //Lista de pedidos
        public void AgregarALista(Med medicamento)
        {
            DataAlmacenada.Instancia.ListaMed.Add(medicamento); 
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