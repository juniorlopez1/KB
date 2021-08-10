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
    public class CuponBLL
    {
        public void crearCupon( ref CuponDAL dal)
        {
            String nombreSP = "SP_crearCupon";
            String errorMsj = "";

            #region CrearDataTable

            DataTable dtParametros = new DataTable("Parametros");

            dtParametros.Columns.Add("NombreParametro");
            dtParametros.Columns.Add("TipoDato");
            dtParametros.Columns.Add("ValorParametro");

            #endregion

            dtParametros.Rows.Add("@idDetalleCupon", NormalizarParametro.almacenarTipo(ParametroSQL.INT), dal.IdDetalleCupon);
            //dtParametros.Rows.Add("@idCliente", NormalizarParametro.almacenarTipo(ParametroSQL.TINYINT), dal.IdCliente);
            dtParametros.Rows.Add("@idEstado", NormalizarParametro.almacenarTipo(ParametroSQL.TINYINT), dal.IdEstado);
            dtParametros.Rows.Add("@codigo", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Codigo);

            DBBLL client = new DBBLL();

            dal.IdCreado = client.ExecuteScalar(nombreSP, dtParametros, ref errorMsj);
            dal.ErrorMsj = errorMsj;
        }
    }
}
