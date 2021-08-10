using BLL.cat_mant;
using DALL.cat_mant;
using static DALL.db.NormalizarParametro;
using GreenPlanet.utils.autenticacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DALL.db;

namespace GreenPlanet
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void ing_cliente(object sender, EventArgs e)
        {
          
                    this.iniciarColaborador();
                 
       
        }

        protected void ver_registro(object sender, EventArgs e)
        {
            Response.Redirect("./Registrarse.aspx");
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


        private void iniciarColaborador()
        {
            /////////////////////////////////

            //SOLO ESTE FUNCIONA 

            ////////////////////////////////

            String username = txt_username.Value;
            String pwd = txt_contrasenna.Value;
            bool usuarioValido;
            string role = UsuarioUtilidad.roleAID(UsuarioUtilidad.rolesAlmacenados.noregistro);

            DataTable ds = new DataTable();

            #region CrearDataTable

            UsuarioDAL user = new UsuarioDAL();
            user.Username = username;
            user.Contrasenna = pwd;

            user.NombreSP = "SPLogueo";
            user.Parametros = new DataTable("Parametros");
            user.Parametros.Columns.Add("NombreParametro");
            user.Parametros.Columns.Add("TipoDato");
            user.Parametros.Columns.Add("ValorParametro");
            user.Parametros.Rows.Add("@nombreUsuario", NormalizarParametro.almacenarTipo(NormalizarParametro.ParametroSQL.VARCHAR), username);
            user.Parametros.Rows.Add("@contrasena", NormalizarParametro.almacenarTipo(NormalizarParametro.ParametroSQL.VARCHAR), pwd);

            ClienteBLL bll = new ClienteBLL();
            String errorMsj = "";
            ds = bll.filtrarPorUsername(ref user, ref errorMsj);

            #endregion

            usuarioValido = ds != null && ds.Rows.Count != 0 && ds.Rows[0][5].Equals(pwd);
            if (!usuarioValido) Response.Redirect("Login.aspx", true);

            Session["idColaborador"] = ds.Rows[0][0];
            Session["idPersona"] = ds.Rows[0][1];
            Session["Direccion"] = ds.Rows[0][2];
            Session["idRoles"] = ds.Rows[0][3];
            Session["nombreUsuario"] = ds.Rows[0][4];
            Session["contrasena"] = ds.Rows[0][5];
            Session["correo"] = ds.Rows[0][6];
            Session["tel"] = ds.Rows[0][7];
            Session["estado"] = ds.Rows[0][8];

            Response.Redirect("Default.aspx", true);
        }

    
    }
}