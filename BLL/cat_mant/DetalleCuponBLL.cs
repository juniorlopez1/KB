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
    public class DetalleCuponBLL
    {
        public void crearDetalle(ref DetalleCuponDAL dal)
        {
            String nombreSP = "SP_crearDetalleCupon";
            String errorMsj = "";

            #region CrearDataTable

            DataTable dtParametros = new DataTable("Parametros");

            dtParametros.Columns.Add("NombreParametro");
            dtParametros.Columns.Add("TipoDato");
            dtParametros.Columns.Add("ValorParametro");

            #endregion

            dtParametros.Rows.Add("@idComercio", NormalizarParametro.almacenarTipo(ParametroSQL.TINYINT), dal.IdComercio);
            dtParametros.Rows.Add("@DescCupon", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.DescCupon);
            dtParametros.Rows.Add("@cantHojas", NormalizarParametro.almacenarTipo(ParametroSQL.SMALLINT), dal.CantHojas);
            dtParametros.Rows.Add("@imagen", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Imagen);

            DBBLL client = new DBBLL();

            dal.IdCreado = client.ExecuteScalar(nombreSP, dtParametros, ref errorMsj);
            dal.ErrorMsj = errorMsj;
        }
    }
}
