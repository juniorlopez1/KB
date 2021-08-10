using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL.cat_mant
{
    public class CuponDAL
    {
        private string errorMsj;
        private bool estadoTransaccion;
        private int idDetalleCupon;
        private int idCliente;
        private Int16 idEstado;
        private string codigo;
        private string idCreado;

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

        public int IdDetalleCupon
        {
            get
            {
                return idDetalleCupon;
            }

            set
            {
                idDetalleCupon = value;
            }
        }

        public int IdCliente
        {
            get
            {
                return idCliente;
            }

            set
            {
                idCliente = value;
            }
        }

        public short IdEstado
        {
            get
            {
                return idEstado;
            }

            set
            {
                idEstado = value;
            }
        }

        public string Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
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
    }
}
