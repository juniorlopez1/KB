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
    public partial class comercio_afiliado_form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            btn_act.Visible = false;


        }

        protected void guardar_afi(object sender, EventArgs e)
        {


            cliente_web_dal dal_usuario_web = new cliente_web_dal();
            registro_web_bll bll_registro = new registro_web_bll();

            dal_usuario_web.Nombre_sp = "sp_crear_afiliado";
            string msjError = "";

            dal_usuario_web.NombreUsuario = txt_username_afi.Value;
            dal_usuario_web.Nombre = txt_name_afi.Value;
            dal_usuario_web.Correo = txt_correo.Value;
            dal_usuario_web.Tel = txt_tel_afi.Value;
            dal_usuario_web.IdRoles = 4;
            string cont = txt_password.Value;
            string hash = ComputeSha256Hash(cont);
            dal_usuario_web.Contrasena = hash;

            Boolean estado = true;
            dal_usuario_web.Estado1 = estado;

            bll_registro.ing_comercio_afi(ref dal_usuario_web, ref msjError);
            if (msjError == "")
            {
                borrar();
                Response.Write("<script>alert('Afiliado Guardado Correctamente');</script>");

            }
            else
            {

                Response.Write("<script>alert('Hubo problemas en el registro, intente de nuevo.');</script>");
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

        protected void buscar_afiliado(object sender, EventArgs e)
        {

            string sms_erro = string.Empty;

            cliente_web_dal dal_usuario_web = new cliente_web_dal();
            registro_web_bll obj_registro_bll = new registro_web_bll();

            // lleno dt

            DataTable dt = new DataTable();

            dal_usuario_web.Nombre_sp = "sp_filtrar_afiliado";

            #region CrearDataTable

            dal_usuario_web.DtParametros = new DataTable("Parametros");

            dal_usuario_web.DtParametros.Columns.Add("NombreParametro");
            dal_usuario_web.DtParametros.Columns.Add("TipoDato");
            dal_usuario_web.DtParametros.Columns.Add("ValorParametro");

            dal_usuario_web.DtParametros.Rows.Add("@nombreComercio", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), txt_buscar.Value);

            #endregion

            dt = obj_registro_bll.listar(ref dal_usuario_web, ref sms_erro);

            if (dt.Rows.Count <= 0)
            {

                Response.Write("<script>alert('No se encontro el comercio, por favor intente de nuevo.');</script>");
            }
            else
            {


                string username = dt.Rows[0]["nombreUsuario"].ToString(),
                nombre_comer = dt.Rows[0]["nombreComercio"].ToString(),
                tel = dt.Rows[0]["telefono"].ToString(),
                email = dt.Rows[0]["correo"].ToString();




                txt_username_afi.Value = username;
                txt_name_afi.Value = nombre_comer;
                txt_correo.Value = email;
                txt_tel_afi.Value = tel;

                txt_username_afi.Disabled = true;
                txt_password.Disabled = true;

                string est = dt.Rows[0]["estado"].ToString();
                if (est == "True")
                {

                    DropDownList2.SelectedValue = "true";

                }
                else
                {
                    DropDownList2.SelectedValue = "false";

                }
                txt_buscar.Value = "";
                btn_act.Visible = true;
                btn_guardar.Visible = false;
            }




        }

        protected void cancelar(object sender, EventArgs e)
        {
            borrar();
        }


        public void borrar()
        {
            txt_buscar.Value = "";
            txt_username_afi.Value = "";
            txt_name_afi.Value = "";
            txt_tel_afi.Value = "";
            txt_correo.Value = "";
            txt_username_afi.Disabled = false;
            txt_password.Disabled = false;
            btn_act.Visible = false;
            btn_guardar.Visible = true;
        }

        protected void act_afi(object sender, EventArgs e)
        {



            cliente_web_dal dal_usuario_web = new cliente_web_dal();
            registro_web_bll bll_registro = new registro_web_bll();

            string msjError = "";

            dal_usuario_web.Nombre_sp = "sp_update_afiliado";

            // borra todo y 
            // si actualizo bien pone boton el false

            dal_usuario_web.Nombre = txt_name_afi.Value;

            Boolean estado = bool.Parse(DropDownList2.SelectedValue.ToString());
            dal_usuario_web.Estado1 = estado;

            bll_registro.mod_afiliado(ref dal_usuario_web, ref msjError);

            if (msjError == "")
            {

                Response.Write("<script>alert('Comercio afiliado Actualizado Correctamente');</script>");
                borrar();
            }
            else
            {

                Response.Write("<script>alert('Hubo problemas actualizando el Comercio afiliado, intente de nuevo.');</script>");

            }


        }

    }
}