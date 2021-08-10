using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace GreenPlanet.utils.autenticacion
{
    public class AuthCookie
    {
        public HttpCookie generarCookie(string usuario, string role)
        {
            FormsAuthenticationTicket tkt;
            string cookiestr;
            HttpCookie ck;
            tkt = new FormsAuthenticationTicket(1, usuario, DateTime.Now,
            DateTime.Now.AddMinutes(30), false, role);
            cookiestr = FormsAuthentication.Encrypt(tkt);
            ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
            ck.Path = FormsAuthentication.FormsCookiePath;
            return ck;
        }
    }
}