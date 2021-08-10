using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DALL;
using BLL;
using System.Data;
using DALL.cat_mant;
using BLL.cat_mant;
using DALL.db;
using static DALL.db.NormalizarParametro;

namespace GreenPlanet
{
    public partial class pedidosCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSolicitarPedido.Enabled = false;
            llenarDataTable();
            validarPedidos();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void validarPedidos()
        {

            cliente_web_dal dal_usuario_web = new cliente_web_dal();
            registro_web_bll obj_registro_bll = new registro_web_bll();
            string smsj_error = string.Empty;

            dal_usuario_web.Nombre_sp = "SP_Listar_pendientes_Clientes";


            #region CrearDataTable

            dal_usuario_web.DtParametros = new DataTable("Parametros");

            dal_usuario_web.DtParametros.Columns.Add("NombreParametro");
            dal_usuario_web.DtParametros.Columns.Add("TipoDato");
            dal_usuario_web.DtParametros.Columns.Add("ValorParametro");


            dal_usuario_web.DtParametros.Rows.Add("@idCliente", NormalizarParametro.almacenarTipo(ParametroSQL.INT), 3);

            #endregion


            DataTable dt = new DataTable();
            dt = obj_registro_bll.listar(ref dal_usuario_web, ref smsj_error);

            


            if (dt != null)
            {
                int totalColumnas = dt.Rows.Count;

                if (totalColumnas == 0)
                {

                    btnSolicitarPedido.Enabled = true;
                }
            }
        }

        public void llenarDataTable()
        {

            cliente_web_dal dal_usuario_web = new cliente_web_dal();
            registro_web_bll obj_registro_bll = new registro_web_bll();
            string smsj_error = string.Empty;

            dal_usuario_web.Nombre_sp = "SP_Listar_Pedidos_Clientes";


            #region CrearDataTable

            dal_usuario_web.DtParametros = new DataTable("Parametros");

            dal_usuario_web.DtParametros.Columns.Add("NombreParametro");
            dal_usuario_web.DtParametros.Columns.Add("TipoDato");
            dal_usuario_web.DtParametros.Columns.Add("ValorParametro");


            dal_usuario_web.DtParametros.Rows.Add("@idCliente", NormalizarParametro.almacenarTipo(ParametroSQL.INT), 3);

            #endregion


            DataTable dt = new DataTable();

            if (dt != null)
            {

                dt = obj_registro_bll.listar(ref dal_usuario_web, ref smsj_error);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }



        }

        protected void btnSolicitarPedido_Click(object sender, EventArgs e)
        {
            Response.Redirect("solicitudRecoleccion.aspx");
        }
    }
}