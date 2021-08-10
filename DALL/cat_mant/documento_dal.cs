using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DALL.cat_mant
{
    public class documento_dal
    {
        private string _smsj_error, _nombre_sp, _titulo,_contenido;
        private int _numeroVersion,_idcolaborador,_idDocumento;
        private Boolean estadoTransaccionDB, _estado;
        private DateTime _fechaCreacion, _fechaModificacion;
        private DataTable _DtParametros;

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

        public string Titulo
        {
            get
            {
                return _titulo;
            }

            set
            {
                _titulo = value;
            }
        }

        public string Contenido
        {
            get
            {
                return _contenido;
            }

            set
            {
                _contenido = value;
            }
        }

        public int NumeroVersion
        {
            get
            {
                return _numeroVersion;
            }

            set
            {
                _numeroVersion = value;
            }
        }

        public int Idcolaborador
        {
            get
            {
                return _idcolaborador;
            }

            set
            {
                _idcolaborador = value;
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

        public DateTime FechaCreacion
        {
            get
            {
                return _fechaCreacion;
            }

            set
            {
                _fechaCreacion = value;
            }
        }

        public DateTime FechaModificacion
        {
            get
            {
                return _fechaModificacion;
            }

            set
            {
                _fechaModificacion = value;
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

        public int IdDocumento
        {
            get
            {
                return _idDocumento;
            }

            set
            {
                _idDocumento = value;
            }
        }
    }
}
