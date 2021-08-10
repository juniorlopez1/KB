using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GreenPlanet
{
    public partial class VerificarCupon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            filtrarCupon(Request.QueryString["id"]);
        }

        protected void Cupones_Linq_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            GreenClassesDataContext context = new GreenClassesDataContext();
            var entries = from detail in context.DetalleCupons
                          join cupon in context.Cupones
                            on detail.idDetalleCupon equals cupon.idDetalleCupon
                          join status in context.EstadosCupons
                            on cupon.idEstadosCupon equals status.idEstadosCupon
                          select new
                          {
                              cupon.idCupones,
                              cupon.codigoCupon,
                              detail.DescCupon,
                              cupon.fechaIngreso,
                              cupon.fechaVencimiento,
                              status.Descripcion,
                              cupon.idCliente
                          };
            e.Result = entries.ToList();
        }

        protected void Details_ServerClick(object sender, EventArgs e)
        {
            HtmlInputButton btn = (HtmlInputButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string idCupon = gvr.Cells[1].Text;
            //filtrarCupon(idCupon);
        }

        private void filtrarCupon(String codigoCupon)
        {
            byte idCommerce = Convert.ToByte(Session[""]);

            GreenClassesDataContext context = new GreenClassesDataContext();
            var entries = from cupon in context.Cupones
                          join detail in context.DetalleCupons
                            on cupon.idDetalleCupon equals detail.idDetalleCupon
                          join status in context.EstadosCupons
                            on cupon.idEstadosCupon equals status.idEstadosCupon
                          join customer in context.Clientes
                            on cupon.idCliente equals customer.idCliente
                          join person in context.Personas
                            on customer.idPersona equals person.idPersona
                          where detail.idComercioAfiliado == idCommerce
                          select new
                          {
                              detail.DescCupon,
                              cupon.fechaIngreso,
                              cupon.fechaVencimiento,
                              detail.imagen,
                              status.Descripcion,
                              person.idPersona,
                              person.nombre,
                              person.apellidos
                          };


            var data = entries.ToList();
            if (data.Count == 0)
            {
                Response.Write("<script>alert('El cupon no esta asignado')</script>");
                //return;
            }


            /*
                        desc_cupon.InnerText = data[0].DescCupon;
                        adquir_cupon.Value = Convert.ToString(data[0].fechaIngreso);
                        venc_cupon.Value = Convert.ToString(data[0].fechaVencimiento);
                        estado_cupon.Value = data[0].Descripcion;
                        cedula.Value = data[0].idPersona;
                        nombre.Value = data[0].nombre + " " + data[0].apellidos;
                        */

            desc_cupon.Value = "asd";
            adquir_cupon.Value = "qwe";
            venc_cupon.Value = "asd";
            estado_cupon.Value = "asd";
            cedula.Value = "asd";
            nombre.Value = "asd";

            /*
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script language='javascript'>");
            sb.Append(@"$('#myModal').modal('show');");
            sb.Append(@"</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "displayPopup", sb.ToString());
            ClientScript.RegisterStartupScript(this.GetType(), "displayPopup", "openModal();", true);
            */
        }
    }
}