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
    public partial class registro_colaboradores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_provincia.Visible = false;
            drop_provincia.Visible = false;
            btn_act.Visible = false;
            dropdown();
            // carga dos dropdowns

        }
        protected void guardar_afi(object sender, EventArgs e)
        {


            cliente_web_dal dal_usuario_web = new cliente_web_dal();
            registro_web_bll bll_registro = new registro_web_bll();

            string msjError = "";
           
            if (listbox1.SelectedValue.ToString() != "5")
            {
                dal_usuario_web.Nombre_sp = "sp_crear_colaborador";

                dal_usuario_web.IdPersona = txt_ced.Value;
                dal_usuario_web.NombreUsuario = txt_username.Value ;
                dal_usuario_web.Nombre = txt_name.Value;
                dal_usuario_web.Apellidos = txt_ape.Value;
                dal_usuario_web.Correo = txt_correo.Value;
                dal_usuario_web.Tel = txt_tel.Value;
                int rol = Convert.ToInt32(listbox1.SelectedValue.ToString());

                dal_usuario_web.IdRoles = rol;

                string cont = txt_password.Value;
                string hash = ComputeSha256Hash(cont);
                dal_usuario_web.Contrasena = hash;

                Boolean estado = bool.Parse(DropDownList2.SelectedValue.ToString());
                dal_usuario_web.Estado1 = estado;
                bll_registro.ing_col(ref dal_usuario_web, ref msjError);


            }
            else {

                dal_usuario_web.Nombre_sp = "sp_crear_recolector";
                dal_usuario_web.IdPersona = txt_ced.Value;
                dal_usuario_web.NombreUsuario = txt_username.Value;
                dal_usuario_web.Nombre = txt_name.Value;
                dal_usuario_web.Apellidos = txt_ape.Value;
                dal_usuario_web.Correo = txt_correo.Value;
                dal_usuario_web.Tel = txt_tel.Value;
                int rol = Convert.ToInt32(listbox1.SelectedValue.ToString());

                dal_usuario_web.IdRoles = rol;

                string cont = txt_password.Value;
                string hash = ComputeSha256Hash(cont);
                dal_usuario_web.Contrasena = hash;

                Boolean estado = bool.Parse(DropDownList2.SelectedValue.ToString());
                dal_usuario_web.Estado1 = estado;
                bll_registro.ing_col(ref dal_usuario_web, ref msjError);


                dal_usuario_web.Nombre_sp = "sp_listar_colaboradorXcedula";

                // lleno dt

                #region CrearDataTable

                dal_usuario_web.DtParametros = new DataTable("Parametros");

                dal_usuario_web.DtParametros.Columns.Add("NombreParametro");
                dal_usuario_web.DtParametros.Columns.Add("TipoDato");
                dal_usuario_web.DtParametros.Columns.Add("ValorParametro");

                dal_usuario_web.DtParametros.Rows.Add("@cedula", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal_usuario_web.IdPersona);

                #endregion

                DataTable dt = new DataTable();
                dt = bll_registro.listar(ref dal_usuario_web, ref msjError);

                int idcol = Convert.ToInt32(dt.Rows[0]["idColaborador"].ToString());
                dal_usuario_web.Idcolaborador = idcol;
                dal_usuario_web.Provincia = Convert.ToInt32(drop_provincia.SelectedIndex.ToString());
                // fin dt 

                dal_usuario_web.Nombre_sp = "sp_asignar_area_cobertura";
                bll_registro.ing_area_col(ref dal_usuario_web, ref msjError);


            }

            if (msjError == "")
            {
                borrar();
                Response.Write("<script>alert('Colaborador Guardado Correctamente');</script>");
              
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


        protected void act_afi(object sender, EventArgs e)
        {

            cliente_web_dal dal_usuario_web = new cliente_web_dal();
            registro_web_bll bll_registro = new registro_web_bll();

            string msjError = "";
       
            dal_usuario_web.Nombre_sp = "sp_update_colaborador";

            // borra todo y 
            // si actualizo bien pone boton el false

            dal_usuario_web.IdPersona = txt_ced.Value;
            dal_usuario_web.Nombre = txt_name.Value;
            dal_usuario_web.Apellidos = txt_ape.Value;
            dal_usuario_web.Correo = txt_correo.Value;
            dal_usuario_web.Tel = txt_tel.Value;

            Boolean estado = bool.Parse(DropDownList2.SelectedValue.ToString());
            dal_usuario_web.Estado1 = estado;

            bll_registro.mod_colaborador(ref dal_usuario_web, ref msjError);

            if (msjError=="") {

                Response.Write("<script>alert('Colaborador Actualizado Correctamente');</script>");
                borrar();
            }
            else {

                Response.Write("<script>alert('Hubo problemas actualizando el Colaborador, intente de nuevo.');</script>");

            }

        }

        protected void listbox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox1.SelectedValue.ToString() == "5")
            {
                drop_provincia.Visible = true;
                lbl_provincia.Visible = true;
            }
            else {
                drop_provincia.Visible = false;
                lbl_provincia.Visible = false;
            }

        }

        protected void listbox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }
        
        protected void buscar_colaborador(object sender, EventArgs e)
        {

            string sms_erro = string.Empty;

            cliente_web_dal dal_usuario_web = new cliente_web_dal();
            registro_web_bll obj_registro_bll = new registro_web_bll();

            // lleno dt
 
            DataTable dt = new DataTable();

            dal_usuario_web.Nombre_sp = "sp_filtrar_colaborador";

            #region CrearDataTable

            dal_usuario_web.DtParametros = new DataTable("Parametros");

            dal_usuario_web.DtParametros.Columns.Add("NombreParametro");
            dal_usuario_web.DtParametros.Columns.Add("TipoDato");
            dal_usuario_web.DtParametros.Columns.Add("ValorParametro");
           
            dal_usuario_web.DtParametros.Rows.Add("@cedula", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR),txt_bus.Value);

            #endregion

            dt = obj_registro_bll.listar(ref dal_usuario_web, ref sms_erro);

            if (dt.Rows.Count <= 0) {

                Response.Write("<script>alert('No se encontro el colaborador con la cedula ');</script>");
            }
            else {

                
               string cedula = dt.Rows[0]["idPersona"].ToString(),
               nombre = dt.Rows[0]["nombre"].ToString(),
               apellidos = dt.Rows[0]["apellidos"].ToString(),
               username = dt.Rows[0]["nombreUsuario"].ToString(),
               tel = dt.Rows[0]["tel"].ToString(),
               email = dt.Rows[0]["correo"].ToString();
               
                txt_ced.Value = cedula;
                txt_username.Value = username;
                txt_name.Value = nombre;
                txt_ape.Value = apellidos;
                txt_correo.Value = email;
                txt_tel.Value = tel;
                txt_ced.Disabled = true;
                txt_password.Disabled = true;
                listbox1.Enabled = false;

               string est = dt.Rows[0]["estado"].ToString();
                if (est == "True")
                {

                    DropDownList2.SelectedValue = "true";

                }
                else {
                    DropDownList2.SelectedValue = "false";

                }
                txt_bus.Value = "";
                btn_act.Visible = true;
                btn_guardar.Visible = false;
            }

           
        }

        protected void cancelar(object sender, EventArgs e)
        {
            borrar();

        }


        public void borrar() {
            txt_ced.Value = "";
            txt_name.Value = "";
            txt_ape.Value = "";
            txt_username.Value = "";
            txt_tel.Value = "";
            txt_correo.Value = "";
            txt_password.Value = "";
            btn_guardar.Visible = true;
            btn_act.Visible = false;
            txt_ced.Disabled = false;
            txt_password.Disabled = false;
            listbox1.Enabled = true;

        }

        public void dropdown()
        {

            // carga provincia 
            if (!IsPostBack)
            {
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

            drop_provincia.DataSource = ds;
            drop_provincia.DataTextField = "nombreProvincia";
            drop_provincia.DataValueField = "idProvincia";
            drop_provincia.DataBind();
            drop_provincia.Items.Insert(0, new ListItem("selecciona", "0"));
            }

        }
    }
}