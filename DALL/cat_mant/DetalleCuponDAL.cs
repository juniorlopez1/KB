using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL.cat_mant
{
    public class DetalleCuponDAL
    {
        private Int16 idComercio, cantHojas;
        private string descCupon, imagen;
        private string idCreado;
        private string errorMsj;
        private bool estadoTransaccion;

        public short IdComercio
        {
            get
            {
                return idComercio;
            }

            set
            {
                idComercio = value;
            }
        }

        public short CantHojas
        {
            get
            {
                return cantHojas;
            }

            set
            {
                cantHojas = value;
            }
        }

        public string DescCupon
        {
            get
            {
                return descCupon;
            }

            set
            {
                descCupon = value;
            }
        }

        public string Imagen
        {
            get
            {
                return imagen;
            }

            set
            {
                imagen = value;
            }
        }

        public string IdCreado
        {
            get
            {
                return idCreado;
            }

            set
            {
                idCreado = value;
            }
        }

        public string ErrorMsj
        {
            get
            {
                return errorMsj;
            }

            set
            {
                errorMsj = value;
            }
        }

        public bool EstadoTransaccion
        {
            get
            {
                return estadoTransaccion;
            }

            set
            {
                estadoTransaccion = value;
            }
        }
    }
}
