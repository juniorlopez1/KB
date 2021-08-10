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
    public partial class informacionPersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string sms_erro = string.Empty;

            cliente_web_dal dal_usuario_web = new cliente_web_dal();
            registro_web_bll obj_registro_bll = new registro_web_bll();
            dal_usuario_web.Nombre_sp = "sp_listar_persona";


            #region CrearDataTable

            dal_usuario_web.DtParametros = new DataTable("Parametros");

            dal_usuario_web.DtParametros.Columns.Add("NombreParametro");
            dal_usuario_web.DtParametros.Columns.Add("TipoDato");
            dal_usuario_web.DtParametros.Columns.Add("ValorParametro");

            dal_usuario_web.DtParametros.Rows.Add("@cedula", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), Session["idPersona"].ToString());

            #endregion

            DataTable dt = new DataTable();
            dt = obj_registro_bll.listar(ref dal_usuario_web, ref sms_erro);


            string cedu = dt.Rows[0]["idPersona"].ToString();
            string nombre = dt.Rows[0]["nombre"].ToString();
            string ape = dt.Rows[0]["apellidos"].ToString();

            lbl_ced.Text = cedu;
            lbl_nombre.Text = nombre;
            lbl_ape.Text = ape;
            lbl_correo.Text = Session["correo"].ToString();
            lbl_tel.Text = Session["tel"].ToString();

        }
    }
}