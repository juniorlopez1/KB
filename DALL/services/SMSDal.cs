using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL.services
{
    public class SMSDal
    {
        private string contenido;
        private string numeroDestino;

        public string Contenido
        {
            get
            {
                return contenido;
            }

            set
            {
                contenido = value;
            }
        }

        public string NumeroDestino
        {
            get
            {
                return numeroDestino;
            }

            set
            {
                numeroDestino = value;
            }
        }
    }
}
