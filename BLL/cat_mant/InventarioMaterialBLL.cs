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
    public class InventarioMaterialBLL
    {
        public DataTable listar(ref string nombre,string param, ref string msjError)
        {
            try
            {

                String parametroSP = param;
                DBBLL client = new DBBLL();

                DataTable dt = new DataTable();

               // dt = client.ExecuteDataAdapter(nombre, parametroSP, SqlDbType.VarChar, "", ref msjError);

                return dt;
            }
            catch (Exception e)
            {
                msjError = e.Message;
                return null;
            }
        }

        public void modificar(ref InventarioMaterialDAL dal, ref string msjError)
        {
            try
            {
                String nombreSP = "SP_act_inven_materiales";

                DBBLL client = new DBBLL();

                DataTable DT = new DataTable();
                bool estado = false;
                #region CrearDataTable

                DataTable dtParametros = new DataTable("Parametros");

                dtParametros.Columns.Add("NombreParametro");
                dtParametros.Columns.Add("TipoDato");
                dtParametros.Columns.Add("ValorParametro");

                #endregion

                dtParametros.Rows.Add("@IDMaterial", NormalizarParametro.almacenarTipo(ParametroSQL.TINYINT), dal.IdMaterial);
                dtParametros.Rows.Add("@Peso", NormalizarParametro.almacenarTipo(ParametroSQL.DECIMAL), dal.Peso);

                estado = client.ExecuteNonQuery(nombreSP, dtParametros, ref msjError);

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
