using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALL.cat_mant;
using BLL.db;
using System.Data;
using DALL.db;
using static DALL.db.NormalizarParametro;

namespace BLL.cat_mant
{
    public class solicitudRecoleccionHogar_bll
    {
        public void ing_cliente(ref solicitudRecoleccionHogar_dal dal, ref string msjError)
        {
            try
            {

                DBBLL client = new DBBLL();

                DataTable DT = new DataTable();
                bool estado = false;
                #region CrearDataTable

                DataTable dtParametros = new DataTable("Parametros");

                dtParametros.Columns.Add("NombreParametro");
                dtParametros.Columns.Add("TipoDato");
                dtParametros.Columns.Add("ValorParametro");

                #endregion

                dtParametros.Rows.Add("@idCliente", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.IdCliente);
                dtParametros.Rows.Add("@horaRecoleccion", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.HoraRecoleccion);
                dtParametros.Rows.Add("@fechaRecoleccion", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.FechaRecoleccion);
                dtParametros.Rows.Add("@idEstadoRecoleccion", NormalizarParametro.almacenarTipo(ParametroSQL.TINYINT), dal.EstadoRecoleccion);
                dtParametros.Rows.Add("@totalHojas", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.HojasRecoleccion);
                dtParametros.Rows.Add("@idMaterial", NormalizarParametro.almacenarTipo(ParametroSQL.TINYINT), dal.TipoMaterial);
                dtParametros.Rows.Add("@pesoRecoleccion", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.CantidadMaterial);           

                estado = client.ExecuteNonQuery(dal.Nombre_sp, dtParametros, ref msjError);

                dal.EstadoTransaccionDB = estado;
            }
            catch (Exception e)
            {
                msjError = e.Message;
                dal.EstadoTransaccionDB = false;
            }
        }
    }
}
