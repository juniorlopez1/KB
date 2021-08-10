using DALL.db;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.db
{
    class registro_bd_bll
    {

        public DataTable ExecuteDataAdapter(string sNombre_SP, string sNombreParametro,
                                         SqlDbType DbType, string sValorParametro,
                                         ref string sMsjError)
        {
            DBDALL Obj_BD_DAL = new DBDALL();

            try
            {
                Obj_BD_DAL.sCadena_Conexion = ConfigurationManager.ConnectionStrings["ubuntu_sql"].ToString();

                Obj_BD_DAL.Obj_sql_cnx = new SqlConnection(Obj_BD_DAL.sCadena_Conexion);

                if (Obj_BD_DAL.Obj_sql_cnx.State == ConnectionState.Closed)
                {
                    Obj_BD_DAL.Obj_sql_cnx.Open();
                }

                Obj_BD_DAL.Obj_sql_adap = new SqlDataAdapter(sNombre_SP, Obj_BD_DAL.Obj_sql_cnx);

                Obj_BD_DAL.Obj_sql_adap.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (sValorParametro != string.Empty)
                {
                    Obj_BD_DAL.Obj_sql_adap.SelectCommand.Parameters.Add(sNombreParametro, DbType).Value = sValorParametro;
                }

                DataSet DS = new DataSet();

                Obj_BD_DAL.Obj_sql_adap.Fill(DS);

                sMsjError = string.Empty;

                return DS.Tables[0];
            }
            catch (SqlException ex)
            {
                sMsjError = ex.Message.ToString();
                return null;
            }
            finally
            {
                if (Obj_BD_DAL.Obj_sql_cnx != null)
                {
                    if (Obj_BD_DAL.Obj_sql_cnx.State == ConnectionState.Open)
                    {
                        Obj_BD_DAL.Obj_sql_cnx.Close();
                    }

                    Obj_BD_DAL.Obj_sql_cnx.Dispose();
                }
            }

        }
    }
}
