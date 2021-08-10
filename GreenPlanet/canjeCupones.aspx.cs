using BLL.cat_mant;
using DALL.cat_mant;
using DALL.db;
using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using static DALL.db.NormalizarParametro;
using System.Drawing;
using System.IO;
using System.Web.UI;

namespace GreenPlanet
{
    public partial class canjeCupones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["idCliente"] == null) {

            //  container.Visible = false;

            //}

            listarHojas();


        }

        public void listarHojas()
        {

            string sms_erro = string.Empty;

            cliente_web_dal dal_usuario_web = new cliente_web_dal();
            registro_web_bll obj_registro_bll = new registro_web_bll();
            dal_usuario_web.Nombre_sp = "SP_Listar_hojas_Clientes";


            #region CrearDataTable

            dal_usuario_web.DtParametros = new DataTable("Parametros");

            dal_usuario_web.DtParametros.Columns.Add("NombreParametro");
            dal_usuario_web.DtParametros.Columns.Add("TipoDato");
            dal_usuario_web.DtParametros.Columns.Add("ValorParametro");

            dal_usuario_web.DtParametros.Rows.Add("@idCliente", NormalizarParametro.almacenarTipo(ParametroSQL.INT), 3);

            #endregion

            DataTable dt = new DataTable();

            dt = obj_registro_bll.listar(ref dal_usuario_web, ref sms_erro);

            if (dt != null)
            {
                string nombreCliente = dt.Rows[0]["hojas"].ToString();
                
                lbl_hojas.Value = nombreCliente;
                Session["hojas"] = nombreCliente;
            }


        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            int rol = 3;
            string rolCliente = Convert.ToString(rol);
            string session = Convert.ToString(Session["idRoles"]);

            Button lnkid = (Button)e.Item.FindControl("Button1");
            Label identificador = (Label)e.Item.FindControl("Label4");
            Label monto = (Label)e.Item.FindControl("Label2");

            string idenLabel = identificador.Text;
            int montoLabel = Convert.ToInt32( monto.Text);
            Session["idCuponSeleccionado"] = idenLabel;
            Session["montoCuponSeleccionado"] = montoLabel;

            //Hojas en el momento
            listarHojas();
            int valorHojas = Convert.ToInt32(Session["hojas"]);

            

            //No suficientes
            if(montoLabel > valorHojas)
            {
                Response.Write("<script>alert('No tiene hojas suficientes para canjear este cupón');</script>");

            }

            //Suficientes
            else if (montoLabel <= valorHojas){

                canjearCupon();
                 
            }





            /*   if (session == null && session != rolCliente)
               {
                   //Button lnkid = (Button)e.Item.FindControl("Button1");
                   //lnkid.Visible = false;
                   Response.Redirect("Login.aspx");
               }
               else if (session == rolCliente)
               {
                   //La wea
               }
               else
               {
                   Response.Redirect("Login.aspx");
               }
           }*/
        }

        public void canjearCupon()
        {
            string sms_erro = string.Empty;
            int idCupones = Convert.ToInt32(Session["idCuponSeleccionado"]);
            int costoHojas = Convert.ToInt32(Session["montoCuponSeleccionado"]);

            cliente_web_dal dal_usuario_web = new cliente_web_dal();
            registro_web_bll obj_registro_bll = new registro_web_bll();
            dal_usuario_web.Nombre_sp = "SP_canjear_Cupon";


            #region CrearDataTable

            dal_usuario_web.DtParametros = new DataTable("Parametros");

            dal_usuario_web.DtParametros.Columns.Add("NombreParametro");
            dal_usuario_web.DtParametros.Columns.Add("TipoDato");
            dal_usuario_web.DtParametros.Columns.Add("ValorParametro");


            dal_usuario_web.DtParametros.Rows.Add("@idCliente", NormalizarParametro.almacenarTipo(ParametroSQL.INT), 3);
            dal_usuario_web.DtParametros.Rows.Add("@hojas", NormalizarParametro.almacenarTipo(ParametroSQL.INT), costoHojas);
            dal_usuario_web.DtParametros.Rows.Add("@idCupones", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), idCupones);
            #endregion

            DataTable dt = new DataTable();

            dt = obj_registro_bll.listar(ref dal_usuario_web, ref sms_erro);

            if (dt != null)
            {
                string nombreCliente = dt.Rows[0]["codigoCupon"].ToString();
                string fechavencimiento = dt.Rows[0]["fechaVencimiento"].ToString();

                string code = nombreCliente;
      
        
                System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                imgBarCode.Height = 150;
                imgBarCode.Width = 150;
         
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                       
                        byte[] byteImage = ms.ToArray();
                        imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                    }
                    PlaceHolder1.Controls.Add(imgBarCode);
                    inputCupon.Text = nombreCliente;
                    inputVencimiento.Text = fechavencimiento;
                    
                }

            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
            
    }
}