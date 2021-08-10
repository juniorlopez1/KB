using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL.db
{
    public class DBDALL
    {
        #region variables
        private string _smsj_error, _scadena_conexion;

        public string sMsj_Error
        {
            get
            {
                return _smsj_error;
            }

            set
            {
                _smsj_error = value;
            }
        }

        public string sCadena_Conexion
        {
            get
            {
                return _scadena_conexion;
            }

            set
            {
                _scadena_conexion = value;
            }
        }

        #endregion

        #region Objetos Base de datos

        public SqlCommand Obj_sql_cmd;
        public SqlDataAdapter Obj_sql_adap;
        public SqlConnection Obj_sql_cnx;

        #endregion
    }
}
