using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL.cat_mant
{
    public class recolector_dal
    {
        private string _smsj_error, _nombre_sp;
        private Boolean estadoTransaccionDB, _estado;
        private DataTable _DtParametros;

        //Parametros del SP
        private int idColaborador, idRecoleccion;

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

        public int IdColaborador
        {
            get
            {
                return idColaborador;
            }

            set
            {
                idColaborador = value;
            }
        }

        public int IdRecoleccion
        {
            get
            {
                return idRecoleccion;
            }

            set
            {
                idRecoleccion = value;
            }
        }
    }
}
