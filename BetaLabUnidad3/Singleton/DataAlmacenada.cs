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
        public List<Pedidos> ListaPedidos = new List<Pedidos>(); //LISTA PARA ALMACENAR TODA LA INFO DEL FARMACO
        public EstructurasLineales.ArbolBinario<Med> ArbolMed = new EstructurasLineales.ArbolBinario<Med>(); //INSTANCIAS PARA ALMACENAR EL NOMBRE E ID DEL FARMACO EN ARBOL 
        public List<Med> FarmacosEliminados = new List<Med>(); //LISTA AUXILIAR PARA ALMACENAR LOS FARMACOS QUE YA NO TIENEN EN EXISTENCIA, Y SERVIRAN PARA REABASTECER

        

        public void LecturaArchivo()
        {
            string[] lineas = File.ReadAllLines("C:/Users/Mario/Desktop/CLASES/Ciclo III/Estructura de Datos I/Lab 3/BetaLaboratorioUnidad3/Prueba.txt");
            int contador = 0;
            char[] separadores = { ','};
            foreach(var linea in lineas)
            {
                if(contador>0)
                {
                    Med agregado = new Med();
                    agregado.id = Convert.ToInt32(linea.Split(separadores)[0]);
                    agregado.Nombre = linea.Split(separadores)[1];
                    agregado.descripcion = linea.Split(separadores)[2];
                    agregado.casa = linea.Split(separadores)[3];
                    agregado.precio = linea.Split(separadores)[4];
                    agregado.existencia = Convert.ToInt32(linea.Split(separadores)[5]);
                    ListaMed.Add(agregado);
                    contador++;
                }
                else
                {
                    contador++;
                }
                
            }
            //char[] comas = new char[20];
            //int contadorcomas = 0; int contadorcomillas = 0;
            //char[] comillas = new char[20];
            //foreach(var linea in lineas)
            //{
            //    for (int i = 0; i < linea.Length; i++)
            //    {
            //        if (linea[i] == ',')
            //        {
            //            comas[contadorcomas] = linea[i];
            //            contadorcomas++;
            //        }else if (linea[i] == '"')
            //        {
            //            comillas[contadorcomillas] = linea[i];
            //            contadorcomillas++;
            //        }
            //    }
            //    while()
            //}
            
        }

        public int Comparador(char a, char b)
        {
            return a.CompareTo(b);
        }

    }
}
