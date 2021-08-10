using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace GreenPlanet.utils.autenticacion
{
    public class UsuarioUtilidad
    {
        public enum rolesAlmacenados
        {
            administrador, secretaria, comercio,
            clienteSitio, clienteWeb, recolectorSitio, recolectorRuta, noregistro
        }

        public static UsuarioEnSistema obtenerUsuario()
        {
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        FormsIdentity id =
                            (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = id.Ticket;

                        string userData = ticket.UserData;
                        string[] roles = userData.Split(',');
                        UsuarioEnSistema tmp = new UsuarioEnSistema();
                        tmp.Usuario = HttpContext.Current.User.Identity.Name;
                        tmp.CurrRoles = new UsuarioUtilidad.rolesAlmacenados();
                        if(roles.Length > 0)
                            tmp.CurrRoles = transformarRole(roles[0]);

                        return tmp;
                    }
                }
            }

            return null;
        }

        public static rolesAlmacenados transformarRole(string role)
        {
            switch (role.ToLower())
            {
                case "Administrador":
                    return rolesAlmacenados.administrador;
                case "Secretaria":
                    return rolesAlmacenados.secretaria;
                case "Comercio":
                    return rolesAlmacenados.comercio;
                case "Cliente en sitio":
                    return rolesAlmacenados.clienteSitio;
                case "Cliente web":
                    return rolesAlmacenados.clienteWeb;
                case "Recolector en sitio":
                    return rolesAlmacenados.recolectorSitio;
                case "Recolector en ruta":
                    return rolesAlmacenados.recolectorRuta;
                default:
                    return rolesAlmacenados.noregistro;
            }
        }

        public static string roleAID(rolesAlmacenados role)
        {
            switch (role)
            {
                case rolesAlmacenados.administrador:
                    return "Administrador";
                case rolesAlmacenados.secretaria:
                    return "Secretaria";
                case rolesAlmacenados.comercio:
                    return "Comercio";
                case rolesAlmacenados.clienteSitio:
                    return "Cliente en sitio";
                case rolesAlmacenados.clienteWeb:
                    return "Cliente web";
                case rolesAlmacenados.recolectorSitio:
                    return "Recolector en sitio";
                case rolesAlmacenados.recolectorRuta:
                    return "Recolector en ruta";
                default:
                    return "No registrado";
            }
        }
    }
}