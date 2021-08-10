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
    public class DBBLL
    {
        // Listar, Filtrar
        public DataTable ExecuteDataAdapter(string sNombre_SP, DataTable dtParametros, ref string sMsjError)
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



                if (dtParametros.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtParametros.Rows)
                    {
                        SqlDbType dbt = NormalizarParametro.obtenerTipoSQL(Convert.ToByte(dr[1]));
                        Obj_BD_DAL.Obj_sql_adap.SelectCommand.Parameters.Add(dr[0].ToString(), dbt).Value = dr[2].ToString();
                    }

                }



                Obj_BD_DAL.Obj_sql_adap.SelectCommand.CommandType = CommandType.StoredProcedure;

                /*if (sValorParametro != string.Empty)
                {
                    Obj_BD_DAL.Obj_sql_adap.SelectCommand.Parameters.Add(sNombreParametro, DbType).Value = sValorParametro;
                }*/

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

        // Insertar no identity, Modificar
        public bool ExecuteNonQuery(string sNombre_SP, DataTable dtParametros, ref string sMsjError)
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

                Obj_BD_DAL.Obj_sql_cmd = new SqlCommand(sNombre_SP, Obj_BD_DAL.Obj_sql_cnx);

                Obj_BD_DAL.Obj_sql_cmd.CommandType = CommandType.StoredProcedure;


                #region Área de Agregar Parámetros

                if (dtParametros.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtParametros.Rows)
                    {
                        SqlDbType dbt = NormalizarParametro.obtenerTipoSQL(Convert.ToByte(dr[1]));
                        Obj_BD_DAL.Obj_sql_cmd.Parameters.Add(dr[0].ToString(), dbt).Value = dr[2].ToString();
                    }
                }

                #endregion

                Obj_BD_DAL.Obj_sql_cmd.ExecuteNonQuery();

                sMsjError = string.Empty;
                return true;
            }
            catch (SqlException ex)
            {
                sMsjError = ex.Message.ToString();
                return false;
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

        // Insertar con identity
        public string ExecuteScalar(string sNombre_SP, DataTable dtParametros, ref string sMsjError)
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

                Obj_BD_DAL.Obj_sql_cmd = new SqlCommand(sNombre_SP, Obj_BD_DAL.Obj_sql_cnx);

                Obj_BD_DAL.Obj_sql_cmd.CommandType = CommandType.StoredProcedure;


                #region Área de Agregar Parámetros

                if (dtParametros.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtParametros.Rows)
                    {
                        SqlDbType dbt = NormalizarParametro.obtenerTipoSQL(Convert.ToByte(dr[1]));
                        Obj_BD_DAL.Obj_sql_cmd.Parameters.Add(dr[0].ToString(), dbt).Value = dr[2].ToString();
                    }
                }

                #endregion

                Object tmp = Obj_BD_DAL.Obj_sql_cmd.ExecuteScalar();
                string sValorScalar = Convert.ToString(tmp);

                sMsjError = string.Empty;
                return sValorScalar;
            }
            catch (SqlException ex)
            {
                sMsjError = ex.Message.ToString();
                return string.Empty;
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
