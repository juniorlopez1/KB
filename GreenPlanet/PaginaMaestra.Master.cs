using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPlanet
{
    public partial class PaginaMaestra : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["idRoles"] == null)
            {
       
               
                link_Registro.Visible = false;
                link_act_docs.Visible = false;
                link_busqueda.Visible = false;
                link_apro_docs.Visible = false;
                link_logout.Visible = false;

            }
            else
            {
               
                lbl_username.Text = Session["nombreUsuario"].ToString();
                string rol = Session["idRoles"].ToString();

                switch (rol)
                {
                    case "1":// Administrador
                        link_Registro.Visible = true;
                        link_act_docs.Visible = true;
                        link_busqueda.Visible = true;
                        link_apro_docs.Visible = true;
                        link_logout.Visible = true;

                        break;
                    case "2":// editor
                        link_Registro.Visible = true;
                        link_act_docs.Visible = true;
                        link_busqueda.Visible = true;
                        link_logout.Visible = true;

                        break;
                    case "3":// lectore
                    
                        link_busqueda.Visible = true;
                        link_logout.Visible = true;

                        break;
                   
                    default:
                        break;
                }
            }
    
        }

        protected void logout(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Session.Remove("idRoles");
            Response.Redirect("Login.aspx");
        }
        

    }
}