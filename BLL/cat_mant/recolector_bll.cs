using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DALL.db;
using static DALL.db.NormalizarParametro;
using BLL.db;
using DALL.cat_mant;

namespace BLL.cat_mant
{
    public class recolector_bll
    {
        public void ing_cliente(ref recolector_dal dal, ref string msjError)
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

                dtParametros.Rows.Add("@idColaborador", NormalizarParametro.almacenarTipo(ParametroSQL.INT), dal.IdColaborador);
                dtParametros.Rows.Add("@idRecoleccion", NormalizarParametro.almacenarTipo(ParametroSQL.INT), dal.IdRecoleccion);
                
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
