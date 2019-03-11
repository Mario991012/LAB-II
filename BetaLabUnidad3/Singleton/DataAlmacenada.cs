using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetaLabUnidad3.Singleton
{
    public class DataAlmacenada
    {
        public class Data
        {
            private static Data instancia = null;
            public static Data Instancia
            {
                get
                {
                    if (instancia == null)
                    {
                        instancia = new Data();
                    }
                    return instancia;
                }
            }
        }
    }
}