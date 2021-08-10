using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenPlanet.utils.autenticacion
{
    public class UsuarioEnSistema
    {

        private string usuario;

        private UsuarioUtilidad.rolesAlmacenados currRoles;

        public string Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        public UsuarioUtilidad.rolesAlmacenados CurrRoles
        {
            get
            {
                return currRoles;
            }

            set
            {
                currRoles = value;
            }
        }
    }
}