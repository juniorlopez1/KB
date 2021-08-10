using BLL.db;
using DALL.cat_mant;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.cat_mant
{
    public class ClienteBLL
    {
        public DataTable listar(ref cliente_web_dal dal, ref string msjError)
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

        public DataTable filtrarPorUsername(ref UsuarioDAL dal , ref string msjError)
        {
            try
            {
                DBBLL client = new DBBLL();

                DataTable dt = new DataTable();

                dt = client.ExecuteDataAdapter(dal.NombreSP, dal.Parametros, ref msjError);

                return dt;
            }
            catch (Exception e)
            {
                msjError = e.Message;
                return null;
            }
        }
    }
}
