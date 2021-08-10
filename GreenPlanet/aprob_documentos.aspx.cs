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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarDSA();
        }

        public void cargarDSA()
        {

            documento_dal docuemnto_dal = new documento_dal();
            documento_bll documento_bll = new documento_bll();
            string smsj_error = string.Empty;

            docuemnto_dal.Nombre_sp = "SP_listar_documentos_sin_aprobar";


            #region CrearDataTable

            docuemnto_dal.DtParametros = new DataTable("Parametros");

            docuemnto_dal.DtParametros.Columns.Add("NombreParametro");
            docuemnto_dal.DtParametros.Columns.Add("TipoDato");
            docuemnto_dal.DtParametros.Columns.Add("ValorParametro");


            #endregion


            DataTable dt = new DataTable();

            if (dt != null)
            {

                dt = documento_bll.listar_docs_sin_aprobar(ref docuemnto_dal, ref smsj_error);

                GridViewDocs.DataSource = dt;
                GridViewDocs.DataBind();

            }
        }

        protected void GridViewDoc_sin_aprobar_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Select")
            {
                Int16 idDocumento = Convert.ToInt16(e.CommandArgument);

                documento_dal docuemnto_dal = new documento_dal();
                documento_bll documento_bll = new documento_bll();

                docuemnto_dal.Nombre_sp = "SP_aprobar_doc";
                string msjError = "";

                docuemnto_dal.IdDocumento = Convert.ToInt32(GridViewDocs.Rows[idDocumento].Cells[1].Text);
                docuemnto_dal.Estado = true;

                documento_bll.aprobar_doc(ref docuemnto_dal, ref msjError);

                if (msjError == "")
                {
                    Response.Write("<script>alert('Documento Aprobado Correctamente');</script>");
                    Response.Redirect("aprob_documentos.aspx", true);

                }
                else {
                    Response.Write("<script>alert('Hubo un problema aprobando el documento, por favor intentar mas tarde.');</script>");

                }

            }
           /* else if(e.CommandName == "ver")
            {


            }*/

        }
    }
}