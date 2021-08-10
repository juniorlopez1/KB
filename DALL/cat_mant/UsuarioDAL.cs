using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL.cat_mant
{
    public class UsuarioDAL
    {
        private string username;
        private string contrasenna;
        private string role;
        private string tel;
        private string nombreSP;
        private DataTable parametros;

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Contrasenna
        {
            get
            {
                return contrasenna;
            }

            set
            {
                contrasenna = value;
            }
        }

        public string Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
            }
        }

        public string Tel
        {
            get
            {
                return tel;
            }

            set
            {
                tel = value;
            }
        }


        public string NombreSP
        {
            get
            {
                return nombreSP;
            }

            set
            {
                nombreSP = value;
            }
        }

        public DataTable Parametros
        {
            get
            {
                return parametros;
            }

            set
            {
                parametros = value;
            }
        }
    }
}
