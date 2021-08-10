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
    public partial class registro_cliente_no_web : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dropdowns();
        }
        
             protected void reg_cliente(object sender, EventArgs e)
        {
            cliente_web_dal dal_usuario_web = new cliente_web_dal();
            registro_web_bll bll_registro = new registro_web_bll();

            dal_usuario_web.Nombre_sp = "SP_Ingresar_Cliente_especial";
            string msjError = "";

            dal_usuario_web.IdPersona = txt_user_cedula.Value;
            dal_usuario_web.NombreUsuario = txt_user_name.Value ;
            dal_usuario_web.Nombre = txt_user_name.Value;
            dal_usuario_web.Apellidos = txt_p_ape.Value;
            int distrito = Convert.ToByte(DropDownList3.SelectedValue.ToString());
            dal_usuario_web.IdDistrito = distrito;

            dal_usuario_web.NombreDireccion = exampleFormControlTextarea1.Value;
            int rol_us_web = 3;
            dal_usuario_web.IdRoles = rol_us_web;

            string cont = exampleInputPassword2.Value;
            string hash = ComputeSha256Hash(cont);
            dal_usuario_web.Contrasena = hash;

            Boolean estado = true;
            dal_usuario_web.Estado1 = estado;
            int hojas = 0;
            dal_usuario_web.Hojas = hojas;

            bll_registro.ing_cliente(ref dal_usuario_web, ref msjError);
            if (msjError == "")
            {
                Response.Write("<script>alert('Usuario Guardado Correctamente');</script>");
                //Response.Redirect("Registrarse.aspx", true);
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
        public void dropdowns()
        {

            // carga provincia DropDownList1
            if (!IsPostBack) {

                string sms_erro = string.Empty;
                cliente_web_dal dal_usuario_web = new cliente_web_dal();
                registro_web_bll obj_registro_bll = new registro_web_bll();
                dal_usuario_web.Nombre_sp = "SP_carga_provincia";

                DataTable ds = new DataTable();

                #region CrearDataTable

                dal_usuario_web.DtParametros = new DataTable("Parametros");

                dal_usuario_web.DtParametros.Columns.Add("NombreParametro");
                dal_usuario_web.DtParametros.Columns.Add("TipoDato");
                dal_usuario_web.DtParametros.Columns.Add("ValorParametro");

                #endregion

                ds = obj_registro_bll.listar(ref dal_usuario_web, ref sms_erro);
                
                    DropDownList1.DataSource = ds;
                    DropDownList1.DataTextField = "nombreProvincia";
                    DropDownList1.DataValueField = "idProvincia";
                    DropDownList1.DataBind();

                DropDownList1.Items.Insert(0, new ListItem("selecciona", "0"));
                DropDownList2.Items.Insert(0, new ListItem("selecciona", "0"));
                DropDownList3.Items.Insert(0, new ListItem("selecciona", "0"));


            }
       

        }


        protected void changed(object sender, EventArgs e)
        {
           
                string sms_erro = string.Empty;

                cliente_web_dal dal_usuario_web = new cliente_web_dal();
                registro_web_bll obj_registro_bll = new registro_web_bll();
                dal_usuario_web.Nombre_sp = "SP_prinviaXcanton";


                #region CrearDataTable

                dal_usuario_web.DtParametros = new DataTable("Parametros");

                dal_usuario_web.DtParametros.Columns.Add("NombreParametro");
                dal_usuario_web.DtParametros.Columns.Add("TipoDato");
                dal_usuario_web.DtParametros.Columns.Add("ValorParametro");

                dal_usuario_web.DtParametros.Rows.Add("@idCanton", NormalizarParametro.almacenarTipo(ParametroSQL.TINYINT), DropDownList1.SelectedValue.ToString());

                #endregion

                DataTable dt = new DataTable();

                dt = obj_registro_bll.listar(ref dal_usuario_web, ref sms_erro);

                DropDownList2.DataSource = dt;
                DropDownList2.DataTextField = "nombreCanton";
                DropDownList2.DataValueField = "idCanton";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new ListItem("selecciona", "0"));

            


        }

        public void changed_distri(object sender, EventArgs e)
        {


            string sms_erro = string.Empty;

            cliente_web_dal dal_usuario_web = new cliente_web_dal();
            registro_web_bll obj_registro_bll = new registro_web_bll();

            dal_usuario_web.Nombre_sp = "SP_distritosxcanton";


            #region CrearDataTable

            dal_usuario_web.DtParametros = new DataTable("Parametros");

            dal_usuario_web.DtParametros.Columns.Add("NombreParametro");
            dal_usuario_web.DtParametros.Columns.Add("TipoDato");
            dal_usuario_web.DtParametros.Columns.Add("ValorParametro");

            dal_usuario_web.DtParametros.Rows.Add("@idCanton", NormalizarParametro.almacenarTipo(ParametroSQL.TINYINT), DropDownList2.SelectedValue.ToString());

            #endregion

            DataTable ds = new DataTable();

            ds = obj_registro_bll.listar(ref dal_usuario_web, ref sms_erro);

            DropDownList3.DataSource = ds;
            DropDownList3.DataTextField = "nombreDistrito";
            DropDownList3.DataValueField = "idDistrito";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, new ListItem("selecciona", "0"));


        }

    }
}