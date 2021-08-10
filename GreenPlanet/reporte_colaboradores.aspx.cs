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
    public partial class reporte_colaboradores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // llenar grid con sp_buscar_col
            //primero lleno 
            //despues con ontextchanged del txt actualizo el databind
            listar_col();

        }

        public void listar_col()
        {

            // carga

            string sms_erro = string.Empty;
            cliente_web_dal dal_usuario_web = new cliente_web_dal();
            registro_web_bll obj_registro_bll = new registro_web_bll();
            dal_usuario_web.Nombre_sp = "sp_listar_col";

            DataTable dt = new DataTable();

            #region CrearDataTable

            dal_usuario_web.DtParametros = new DataTable("Parametros");

            dal_usuario_web.DtParametros.Columns.Add("NombreParametro");
            dal_usuario_web.DtParametros.Columns.Add("TipoDato");
            dal_usuario_web.DtParametros.Columns.Add("ValorParametro");

            #endregion

            dt = obj_registro_bll.listar(ref dal_usuario_web, ref sms_erro);
            
                GridView1.DataSource = dt;
                GridView1.DataBind();

              
          

        }
        protected void buscar_col(object sender, EventArgs e)
        {
            // llenar grid con sp_buscar_col
            //primero lleno 
            //despues con ontextchanged del txt actualizo el databind

            string sms_erro = string.Empty;
            cliente_web_dal dal_usuario_web = new cliente_web_dal();
            registro_web_bll obj_registro_bll = new registro_web_bll();
            dal_usuario_web.Nombre_sp = "sp_buscar_col";

            DataTable dt = new DataTable();

            #region CrearDataTable

            dal_usuario_web.DtParametros = new DataTable("Parametros");

            dal_usuario_web.DtParametros.Columns.Add("NombreParametro");
            dal_usuario_web.DtParametros.Columns.Add("TipoDato");
            dal_usuario_web.DtParametros.Columns.Add("ValorParametro");

            #endregion
            dal_usuario_web.DtParametros.Rows.Add("@cedula", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), txt_busqueda.Value);

            dt = obj_registro_bll.listar(ref dal_usuario_web, ref sms_erro);

            GridView1.DataSource = dt;
            GridView1.DataBind();


        }
    }
}