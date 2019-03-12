using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BetaLabUnidad3.Models;
using System.IO;

namespace BetaLabUnidad3.Singleton
{
    public class DataAlmacenada
    {
        private static DataAlmacenada instancia = null;
        public static DataAlmacenada Instancia
        {
            get
            {
                    if (instancia == null)
                    {
                        instancia = new DataAlmacenada();
                    }
                    return instancia;
            }
        }
            public List<Med> ListaMed = new List<Med>(); //LISTA PARA ALMACENAR TODA LA INFO DEL FARMACO
            public EstructurasLineales.ArbolBinario<Med> ArbolMed = new EstructurasLineales.ArbolBinario<Med>(); //INSTANCIAS PARA ALMACENAR EL NOMBRE E ID DEL FARMACO EN ARBOL 
            public List<Med> FarmacosEliminados = new List<Med>(); //LISTA AUXILIAR PARA ALMACENAR LOS FARMACOS QUE YA NO TIENEN EN EXISTENCIA, Y SERVIRAN PARA REABASTECER

            public void LecturaArchivo()
            {
                using (var writer = new StreamWriter("C:/Users/Marcos Andrés CM/Desktop/Estrucutra de datos I/Laboratorio unidad 3/Data-Laboratorio_Unidad_3.csv"))
                {
                    writer.WriteLine("test");
                }
            }
        
    }
}