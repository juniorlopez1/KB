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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_fecha_creacion.Value = DateTime.Now.ToString("yyyy-MM-dd");
        }

        
        protected void reg_documento(object sender, EventArgs e)
        {

            documento_dal dal_documento = new documento_dal();
            documento_bll bll_documento = new documento_bll();

            dal_documento.Nombre_sp = "SPInsertarDocumento";
            string msjError = "";

            dal_documento.Titulo = txt_titulo.Value;
            dal_documento.FechaCreacion = Convert.ToDateTime(txt_fecha_creacion.Value);
            dal_documento.NumeroVersion = Convert.ToInt32(txt_version.Value);
                dal_documento.FechaModificacion = Convert.ToDateTime(txt_fecha_creacion.Value);
            dal_documento.Contenido = txt_contenido.Value;
            dal_documento.Idcolaborador = Convert.ToInt32(Session["idColaborador"].ToString());
            dal_documento.Estado = false;

            bll_documento.registrar_doc(ref dal_documento, ref msjError);
            if (msjError == "")
            {
                Response.Write("<script>alert('Documento Guardado Correctamente');</script>");
                txt_contenido.Value = "";
                txt_titulo.Value = "";
               
            }
            else
            {

                Response.Write("<script>alert('Hubo problemas en el registro, intente de nuevo.');</script>");
            }
            
        }

    }
}