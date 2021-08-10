using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.cat_mant;
using DALL.cat_mant;
using System.Data;
using DALL.db;
using static DALL.db.NormalizarParametro;

namespace GreenPlanet
{
    public partial class solicitudRecoleccion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            string sms_erro = string.Empty;

            cliente_web_dal dal_usuario_web = new cliente_web_dal();
            registro_web_bll obj_registro_bll = new registro_web_bll();
            dal_usuario_web.Nombre_sp = "SP_Filtrar_Cliente";


            #region CrearDataTable

            dal_usuario_web.DtParametros = new DataTable("Parametros");

            dal_usuario_web.DtParametros.Columns.Add("NombreParametro");
            dal_usuario_web.DtParametros.Columns.Add("TipoDato");
            dal_usuario_web.DtParametros.Columns.Add("ValorParametro");

            dal_usuario_web.DtParametros.Rows.Add("@idPersona", NormalizarParametro.almacenarTipo(ParametroSQL.INT), 1156748392);

            #endregion

            DataTable dt = new DataTable();

            dt = obj_registro_bll.listar(ref dal_usuario_web, ref sms_erro);

      
            if (dt != null) { 
            string idCliente = "7";
            string nombreCliente = dt.Rows[0]["Nombre Cliente"].ToString();
            string telefono = dt.Rows[0]["Telefono"].ToString();
            string provincia = dt.Rows[0]["Provincia"].ToString();
            string canton = dt.Rows[0]["Canton"].ToString();
            string distrito = dt.Rows[0]["Distrito"].ToString();
            string direccion = dt.Rows[0]["Direccion Completa"].ToString();

            inputIdCliente.Value = idCliente;
            inputNombreCliente.Value = nombreCliente;
            inputTelefonoCliente.Value = telefono;
            inputProvinciaPedido.Value = provincia;
            inputCantonCliente.Value = canton;
            inputDistritoPedido.Value = distrito;
            inputDireccionPedido.Value = direccion;

            }

        }

        public void reg_cliente(object sender, EventArgs e)
        {
            int estadoRecoleccion = 2;
            solicitudRecoleccionHogar_dal dal_SR_hogar = new solicitudRecoleccionHogar_dal();
            solicitudRecoleccionHogar_bll bll_SR_HOGAR = new solicitudRecoleccionHogar_bll();
            

            dal_SR_hogar.Nombre_sp = "SP_Solicitud_Recoleccion";
            string msjError = "";

            dal_SR_hogar.IdCliente = Convert.ToInt32(inputIdCliente.Value);
            dal_SR_hogar.FechaRecoleccion = Request.Form["datepicker"]; ;
            dal_SR_hogar.HoraRecoleccion = Request.Form["datetimepicker5"];
            dal_SR_hogar.EstadoRecoleccion = estadoRecoleccion;

            dal_SR_hogar.TipoMaterial = Convert.ToInt32(Request.Form["checkBoxAluminio"]);
            dal_SR_hogar.CantidadMaterial = Convert.ToInt32(Request.Form["listaCantidadAluminio"]);

            dal_SR_hogar.HojasRecoleccion = 0;

            
            bll_SR_HOGAR.ing_cliente(ref dal_SR_hogar, ref msjError);



            if (msjError == "")
            {
                Response.Write("<script>alert('Usuario Guardado Correctamente');</script>");
               
            }
            else
            {

                Response.Write("<script>alert('Hubo problemas en el registro, intente de nuevo.');</script>");
            }


        }
    }
}