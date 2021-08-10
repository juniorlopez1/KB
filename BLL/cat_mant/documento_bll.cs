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
    public class documento_bll
    {
        public DataTable listar_docs_sin_aprobar(ref documento_dal dal, ref string msjError)
        {
            try
            {
                DBBLL client = new DBBLL();

                DataTable dt = new DataTable();

                dt = client.ExecuteDataAdapter(dal.Nombre_sp, dal.DtParametros, ref msjError);

                return dt;
            }
            catch (Exception e)
            {
                msjError = e.Message;
                return null;
            }
        }

        public void registrar_doc(ref documento_dal dal, ref string msjError)
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

                dtParametros.Rows.Add("@titulo", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Titulo);
                dtParametros.Rows.Add("@fechaCreacion", NormalizarParametro.almacenarTipo(ParametroSQL.DATE), dal.FechaCreacion);
                dtParametros.Rows.Add("@numeroVersion", NormalizarParametro.almacenarTipo(ParametroSQL.TINYINT), dal.NumeroVersion);
                dtParametros.Rows.Add("@fechaModificacion", NormalizarParametro.almacenarTipo(ParametroSQL.DATE), dal.FechaModificacion);
                dtParametros.Rows.Add("@Contenido", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Contenido);
                dtParametros.Rows.Add("@idColaborador", NormalizarParametro.almacenarTipo(ParametroSQL.INT), dal.Idcolaborador);
                dtParametros.Rows.Add("@estado", NormalizarParametro.almacenarTipo(ParametroSQL.BIT), dal.Estado);


                estado = client.ExecuteNonQuery(dal.Nombre_sp, dtParametros, ref msjError);

                dal.EstadoTransaccionDB = estado;
            }
            catch (Exception e)
            {
                msjError = e.Message;
                dal.EstadoTransaccionDB = false;
            }
        }

        public void aprobar_doc(ref documento_dal dal, ref string msjError)
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

                dtParametros.Rows.Add("@idDocumento", NormalizarParametro.almacenarTipo(ParametroSQL.INT), dal.IdDocumento);
                dtParametros.Rows.Add("@estado", NormalizarParametro.almacenarTipo(ParametroSQL.BIT), dal.Estado);


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
