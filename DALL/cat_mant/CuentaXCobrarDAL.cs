using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL.cat_mant
{
    public class CuentaXCobrarDAL
    {
        private Int32 idMaterial;
        private decimal peso;
        private int monto;
        private DateTime fecha;
        private string errorMsj;
        private bool estadoTransaccionDB;
        private string idCreado;

        public int IdMaterial
        {
            get
            {
                return idMaterial;
            }

            set
            {
                idMaterial = value;
            }
        }

        public decimal Peso
        {
            get
            {
                return peso;
            }

            set
            {
                peso = value;
            }
        }

        public int Monto
        {
            get
            {
                return monto;
            }

            set
            {
                monto = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public bool EstadoTransaccionDB
        {
            get
            {
                return estadoTransaccionDB;
            }

            set
            {
                estadoTransaccionDB = value;
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
    }
}
