using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DALL.cat_mant
{
    public class cliente_web_dal
    {
        private string _smsj_error,_nombre_sp,_idPersona,_nombre,_apellidos,_nombreDireccion;
        private int _idDistrito,_idRoles, _hojas,_provincia,_idcolaborador;
        private string _nombreUsuario, _contrasena, _correo, _tel, idCliente;
        private Boolean estadoTransaccionDB, _estado;
       
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

        public string IdPersona
        {
            get
            {
                return _idPersona;
            }

            set
            {
                _idPersona = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public string Apellidos
        {
            get
            {
                return _apellidos;
            }

            set
            {
                _apellidos = value;
            }
        }

        public string NombreDireccion
        {
            get
            {
                return _nombreDireccion;
            }

            set
            {
                _nombreDireccion = value;
            }
        }

        public int IdDistrito
        {
            get
            {
                return _idDistrito;
            }

            set
            {
                _idDistrito = value;
            }
        }

        public int IdRoles
        {
            get
            {
                return _idRoles;
            }

            set
            {
                _idRoles = value;
            }
        }

        public int Hojas
        {
            get
            {
                return _hojas;
            }

            set
            {
                _hojas = value;
            }
        }

        public string NombreUsuario
        {
            get
            {
                return _nombreUsuario;
            }

            set
            {
                _nombreUsuario = value;
            }
        }

        public string Contrasena
        {
            get
            {
                return _contrasena;
            }

            set
            {
                _contrasena = value;
            }
        }

        public string Correo
        {
            get
            {
                return _correo;
            }

            set
            {
                _correo = value;
            }
        }

        public string Tel
        {
            get
            {
                return _tel;
            }

            set
            {
                _tel = value;
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

        public bool Estado1
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

        public string IdCliente
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

        public int Provincia
        {
            get
            {
                return _provincia;
            }

            set
            {
                _provincia = value;
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
    }
}
