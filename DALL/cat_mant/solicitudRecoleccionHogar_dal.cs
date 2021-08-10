using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL.cat_mant
{
    public class solicitudRecoleccionHogar_dal
    {
        //Parametros de BD
        private string _smsj_error, _nombre_sp;
        private Boolean estadoTransaccionDB, _estado;
        private DataTable _DtParametros;

        //Parametros del SP
        private int idCliente, tipoMaterial, cantidadMaterial, estadoRecoleccion, hojasRecoleccion;
        private string fechaRecoleccion, horaRecoleccion;

        public string Smsj_error
        {
            get
            {
                return _smsj_error;
            }

            set
            {
                _smsj_error = value;
            }
        }

        public string Nombre_sp
        {
            get
            {
                return _nombre_sp;
            }

            set
            {
                _nombre_sp = value;
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

        public bool Estado
        {
            get
            {
                return _estado;
            }

            set
            {
                _estado = value;
            }
        }

        public DataTable DtParametros
        {
            get
            {
                return _DtParametros;
            }

            set
            {
                _DtParametros = value;
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

        public int TipoMaterial
        {
            get
            {
                return tipoMaterial;
            }

            set
            {
                tipoMaterial = value;
            }
        }

        public int CantidadMaterial
        {
            get
            {
                return cantidadMaterial;
            }

            set
            {
                cantidadMaterial = value;
            }
        }

        public int EstadoRecoleccion
        {
            get
            {
                return estadoRecoleccion;
            }

            set
            {
                estadoRecoleccion = value;
            }
        }

        public int HojasRecoleccion
        {
            get
            {
                return hojasRecoleccion;
            }

            set
            {
                hojasRecoleccion = value;
            }
        }

        public string FechaRecoleccion
        {
            get
            {
                return fechaRecoleccion;
            }

            set
            {
                fechaRecoleccion = value;
            }
        }

        public string HoraRecoleccion
        {
            get
            {
                return horaRecoleccion;
            }

            set
            {
                horaRecoleccion = value;
            }
        }
    }
}
