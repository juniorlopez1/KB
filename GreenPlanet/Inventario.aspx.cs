using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using DALL.cat_mant;
using BLL.cat_mant;
using System.IO;

namespace GreenPlanet
{
    public partial class Inventario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            String tmp = "";
            Session["test"] = "b";
            tmp = Session["test"].ToString();
        }

        protected void Materiales_Linq_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            GreenClassesDataContext context = new GreenClassesDataContext();
            var entries = from inventory in context.InventarioMaterials
                          join material in context.Materials
                            on inventory.idMaterial equals material.idMaterial
                          select new { material.idMaterial, material.descripcionMaterial, inventory.peso };

            e.Result = entries.ToList();
        }

        protected void Cuentas_Linq_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            GreenClassesDataContext context = new GreenClassesDataContext();

            var entries = from account in context.CuentasXcobrars
                          join inventory in context.InventarioMaterials
                            on account.idInventarioMaterial equals inventory.idInventarioMaterial
                          join material in context.Materials
                            on inventory.idMaterial equals material.idMaterial
                          select new
                          {
                              account.idCuentasXcobrar,
                              material.descripcionMaterial,
                              account.pesoEntregado,
                              account.monto,
                              account.fecha
                          };

            e.Result = entries.ToList();
        }

        protected void Cupones_Linq_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            GreenClassesDataContext context = new GreenClassesDataContext();
            var entries = from coupon in context.Cupones
                          join details in context.DetalleCupons
                            on coupon.idDetalleCupon equals details.idDetalleCupon
                          join affiliate in context.ComercioAfiliados
                            on details.idComercioAfiliado equals affiliate.idComercioAfiliado
                          join status in context.EstadosCupons
                            on coupon.idEstadosCupon equals status.idEstadosCupon
                          select new
                          {
                              coupon.idDetalleCupon,
                              coupon.idCupones,
                              affiliate.nombreComercio,
                              details.DescCupon,
                              details.CantidadHojas,
                              status.Descripcion
                          };

            e.Result = entries.ToList();
        }

        protected void crear_cuentas_ServerClick(object sender, EventArgs e)
        {
            string material = Request.Form["salida_material"];
            string cantidad = Request.Form["salida_cantidad"];
            string monto = Request.Form["salida_monto"];
            string fecha = Request.Form["salida_fecha"];

            InventarioMaterialDAL inv = new InventarioMaterialDAL();
            InventarioMaterialBLL invBLL = new InventarioMaterialBLL();

            String err = "";

            inv.IdMaterial = material;
            inv.Peso = -Convert.ToDecimal(cantidad);
            invBLL.modificar(ref inv, ref err);

            if (err != "" || !inv.EstadoTransaccionDB)
            {
                Response.Write("<script>alert('No se puede sacar mas de lo disponible en inventario del material. Intente denuevo');</script>");
                return;
            }

            CuentaXCobrarDAL dal = new CuentaXCobrarDAL();
            CuentasXCobrarBLL bll = new CuentasXCobrarBLL();
            dal.IdMaterial = Convert.ToInt32(material);
            dal.Peso = Convert.ToDecimal(cantidad);
            dal.Monto = Convert.ToInt32(monto);
            dal.Fecha = Convert.ToDateTime(fecha);
            bll.crearCuenta(ref dal);

            if (dal.ErrorMsj != "" || dal.EstadoTransaccionDB == false)
            {
                Response.Write("<script>alert('No se logro registrar la cuenta x cobrar. Intente denuevo');</script>");
                return;
            }

            Response.Write("<script>alert('Transaccion finalizada exitosamente');</script>");
        }

        protected void crear_cupones_ServerClick(object sender, EventArgs e)
        {
            HttpPostedFile file = Request.Files.Get(0);

            if (file == null || file.ContentLength <= 0)
            {
                Response.Write("<script>alert('Ha ocurrido un error guardando el archivo');</<script>");
            }

            string fileName = Path.GetFileName(file.FileName);
            string absolutePath = Server.MapPath(Path.Combine("~/img/", fileName));
            file.SaveAs(absolutePath);


            GreenClassesDataContext context = new GreenClassesDataContext();
            int result = context.SP_crearDetalleCupon(Convert.ToByte(Request.Form["comerc_cupon"]),
                                Request.Form["desc_cupon"],
                                Convert.ToInt16(Request.Form["cant_hojas"]),
                                absolutePath);

            if (result == -1)
            {
                Response.Write("alert('Un error ocurrio durante la creación de cupones. Vuelva a intentar');");
                return;
            }
            
            CuponDAL cuponDal = new CuponDAL();
            CuponBLL cuponBll = new CuponBLL();

            cuponDal.IdDetalleCupon = Convert.ToInt32(result);
            cuponDal.IdEstado = 1;

            for (int i = Convert.ToInt32(Request.Form["cant_cupones"]); i > 0; --i)
            {
                Guid g = Guid.NewGuid();
                string GuidString = Convert.ToBase64String(g.ToByteArray());
                GuidString = GuidString.Replace("=", "").Replace("+", "");
                cuponDal.Codigo = GuidString;
                cuponBll.crearCupon(ref cuponDal);
            }
        }
    }
}