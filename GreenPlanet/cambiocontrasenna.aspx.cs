using BLL.cat_mant;
using DALL.cat_mant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPlanet
{
    public partial class cambiocontrasenna : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void act_cliente(object sender, EventArgs e)
        {

            cliente_web_dal dal_usuario_web = new cliente_web_dal();
            registro_web_bll bll_registro = new registro_web_bll();

            dal_usuario_web.Nombre_sp = "sp_cambio_password";
            string msjError = "";

            dal_usuario_web.Contrasena = ComputeSha256Hash(Request.Form["exampleInputPassword2"]);


            dal_usuario_web.NombreUsuario = Session["nombreUsuario"].ToString();

            bll_registro.mod_cliente(ref dal_usuario_web, ref msjError);
            if (msjError == "")
            {
                Response.Write("<script>alert('Contraseña Actualizada Correctamente.');</script>");
                
            }
            else
            {

                Response.Write("<script>alert('Hubo problemas con el cambio de contraseña, intente de nuevo.');</script>");
            }


        }
        private string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }


    }
}