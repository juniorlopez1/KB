using BLL.db;
using DALL.cat_mant;
using DALL.db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DALL.db.NormalizarParametro;

namespace BLL.cat_mant
{
    public class CuentasXCobrarBLL
    {
        public void crearCuenta(ref CuentaXCobrarDAL dal)
        {
            String nombreSP = "sp_ingreso_cuenta";
            String errorMsj = "";

            #region CrearDataTable

            DataTable dtParametros = new DataTable("Parametros");

            dtParametros.Columns.Add("NombreParametro");
            dtParametros.Columns.Add("TipoDato");
            dtParametros.Columns.Add("ValorParametro");

            #endregion

            dtParametros.Rows.Add("@IdMaterial", NormalizarParametro.almacenarTipo(ParametroSQL.TINYINT), dal.IdMaterial);
            dtParametros.Rows.Add("@peso", NormalizarParametro.almacenarTipo(ParametroSQL.DECIMAL), dal.Peso);
            dtParametros.Rows.Add("@monto", NormalizarParametro.almacenarTipo(ParametroSQL.INT), dal.Monto);
            dtParametros.Rows.Add("@fecha", NormalizarParametro.almacenarTipo(ParametroSQL.DATE), dal.Fecha);

            DBBLL client = new DBBLL();

            dal.IdCreado = client.ExecuteScalar(nombreSP, dtParametros, ref errorMsj);
            dal.ErrorMsj = errorMsj;
        }
    }
}
