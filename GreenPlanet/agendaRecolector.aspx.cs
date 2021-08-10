using BLL.cat_mant;
using DALL.cat_mant;
using DALL.db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DALL.db.NormalizarParametro;

namespace GreenPlanet
{
    public partial class agendaRecolector : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarPSA();
            cargarPCL();

        }

        public void cargarPCL()
        {
            cliente_web_dal dal_usuario_web = new cliente_web_dal();
            registro_web_bll obj_registro_bll = new registro_web_bll();
            string smsj_error = string.Empty;

            dal_usuario_web.Nombre_sp = "SP_Listar_Pedido_Recolector";


            #region CrearDataTable

            dal_usuario_web.DtParametros = new DataTable("Parametros");

            dal_usuario_web.DtParametros.Columns.Add("NombreParametro");
            dal_usuario_web.DtParametros.Columns.Add("TipoDato");
            dal_usuario_web.DtParametros.Columns.Add("ValorParametro");

            dal_usuario_web.DtParametros.Rows.Add("@idColaborador", NormalizarParametro.almacenarTipo(ParametroSQL.INT), 1);


            #endregion


            DataTable dt = new DataTable();

            if (dt != null)
            {

                dt = obj_registro_bll.listar(ref dal_usuario_web, ref smsj_error);

                GridViewMisPedidos.DataSource = dt;
                GridViewMisPedidos.DataBind();

            }
        }

        public void cargarPSA()
        {
            cliente_web_dal dal_usuario_web = new cliente_web_dal();
            registro_web_bll obj_registro_bll = new registro_web_bll();
            string smsj_error = string.Empty;

            dal_usuario_web.Nombre_sp = "SP_Listar_Pedido_sinAsignar";


            #region CrearDataTable

            dal_usuario_web.DtParametros = new DataTable("Parametros");

            dal_usuario_web.DtParametros.Columns.Add("NombreParametro");
            dal_usuario_web.DtParametros.Columns.Add("TipoDato");
            dal_usuario_web.DtParametros.Columns.Add("ValorParametro");




            #endregion


            DataTable dt = new DataTable();

            if (dt != null)
            {

                dt = obj_registro_bll.listar(ref dal_usuario_web, ref smsj_error);

                GridViewSinAsignar.DataSource = dt;
                GridViewSinAsignar.DataBind();

            }
        }

        protected void GridViewSinAsignar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Int16 idRecoleccion = Convert.ToInt16(e.CommandArgument);

                recolector_dal dal_obj_recolector = new recolector_dal();
                recolector_bll bll_SR_HOGAR = new recolector_bll();

                dal_obj_recolector.Nombre_sp = "SP_asignar_recoleccion";
                string msjError = "";

                dal_obj_recolector.IdColaborador = Convert.ToInt32(1);
                dal_obj_recolector.IdRecoleccion = Convert.ToInt32(GridViewSinAsignar.Rows[idRecoleccion].Cells[1].Text);

                bll_SR_HOGAR.ing_cliente(ref dal_obj_recolector, ref msjError);



                if (msjError == "")
                {

                    Response.Redirect(Request.RawUrl);
                    //Response.Write("<script>alert('Recolección asignada correctamente');</script>");
                }
            }
        }

        protected void GridViewMisPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);


            }

        }


    }
    }     

        
    
