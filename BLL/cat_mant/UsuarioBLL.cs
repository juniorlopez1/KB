using BLL.db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.cat_mant
{
    public class UsuarioBLL
    {
        public DataTable filtrar(string valorParametro, ref string msjError)
        {
            try
            {
                String nombreSP = "";
                String parametroSP = "";
                DBBLL client = new DBBLL();

                DataTable dt = new DataTable();

               // dt = client.ExecuteDataAdapter(nombreSP, parametroSP, SqlDbType.VarChar, valorParametro, ref msjError);

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
