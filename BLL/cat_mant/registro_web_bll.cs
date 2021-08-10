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
    public class registro_web_bll
    {
        public DataTable listar(ref cliente_web_dal dal ,ref string msjError)
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

        public void ing_cliente(ref cliente_web_dal dal, ref string msjError)
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

                dtParametros.Rows.Add("@idPersona", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.IdPersona);
                dtParametros.Rows.Add("@nombre", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Nombre);
                dtParametros.Rows.Add("@apellidos", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Apellidos);
                dtParametros.Rows.Add("@idDistrito", NormalizarParametro.almacenarTipo(ParametroSQL.TINYINT), dal.IdDistrito);
                dtParametros.Rows.Add("@nombreDireccion", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.NombreDireccion);
                dtParametros.Rows.Add("@idRoles", NormalizarParametro.almacenarTipo(ParametroSQL.TINYINT), dal.IdRoles);
                dtParametros.Rows.Add("@nombreUsuario", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.NombreUsuario);
                dtParametros.Rows.Add("@contrasena", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Contrasena);
                dtParametros.Rows.Add("@correo", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Correo);
                dtParametros.Rows.Add("@tel", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Tel);
                dtParametros.Rows.Add("@estado", NormalizarParametro.almacenarTipo(ParametroSQL.BIT), dal.Estado1);
                dtParametros.Rows.Add("@hojas", NormalizarParametro.almacenarTipo(ParametroSQL.INT), dal.Hojas);
                

                estado = client.ExecuteNonQuery(dal.Nombre_sp, dtParametros, ref msjError);

                dal.EstadoTransaccionDB = estado;
            }
            catch (Exception e)
            {
                msjError = e.Message;
                dal.EstadoTransaccionDB = false;
            }
        }

        public void mod_cliente(ref cliente_web_dal dal, ref string msjError)
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

                dtParametros.Rows.Add("@username", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.NombreUsuario);
                dtParametros.Rows.Add("@pass", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Contrasena);

                estado = client.ExecuteNonQuery(dal.Nombre_sp, dtParametros, ref msjError);

                dal.EstadoTransaccionDB = estado;
            }
            catch (Exception e)
            {
                msjError = e.Message;
                dal.EstadoTransaccionDB = false;
            }
        }
        public void mod_colaborador(ref cliente_web_dal dal, ref string msjError)
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

                dtParametros.Rows.Add("@idPersona", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.IdPersona);
                dtParametros.Rows.Add("@nombre", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Nombre);
                dtParametros.Rows.Add("@apellidos", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Apellidos);
                dtParametros.Rows.Add("@correo", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Correo);
                dtParametros.Rows.Add("@tel", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Tel);
                dtParametros.Rows.Add("@estado", NormalizarParametro.almacenarTipo(ParametroSQL.BIT), dal.Estado1);

                estado = client.ExecuteNonQuery(dal.Nombre_sp, dtParametros, ref msjError);

                dal.EstadoTransaccionDB = estado;
            }
            catch (Exception e)
            {
                msjError = e.Message;
                dal.EstadoTransaccionDB = false;
            }
        }
        public void mod_afiliado(ref cliente_web_dal dal, ref string msjError)
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

                dtParametros.Rows.Add("@nombreComercio", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Nombre);
               
                dtParametros.Rows.Add("@estado", NormalizarParametro.almacenarTipo(ParametroSQL.BIT), dal.Estado1);

                estado = client.ExecuteNonQuery(dal.Nombre_sp, dtParametros, ref msjError);

                dal.EstadoTransaccionDB = estado;
            }
            catch (Exception e)
            {
                msjError = e.Message;
                dal.EstadoTransaccionDB = false;
            }
        }
        public void ing_col(ref cliente_web_dal dal, ref string msjError)
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

                dtParametros.Rows.Add("@idPersona", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.IdPersona);
                dtParametros.Rows.Add("@nombre", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Nombre);
                dtParametros.Rows.Add("@apellidos", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Apellidos);
                dtParametros.Rows.Add("@idRoles", NormalizarParametro.almacenarTipo(ParametroSQL.TINYINT), dal.IdRoles);
                dtParametros.Rows.Add("@nombreUsuario", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.NombreUsuario);
                dtParametros.Rows.Add("@contrasena", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Contrasena);
                dtParametros.Rows.Add("@correo", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Correo);
                dtParametros.Rows.Add("@tel", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Tel);
                dtParametros.Rows.Add("@estado", NormalizarParametro.almacenarTipo(ParametroSQL.BIT), dal.Estado1);
           
                estado = client.ExecuteNonQuery(dal.Nombre_sp, dtParametros, ref msjError);

                dal.EstadoTransaccionDB = estado;
            }
            catch (Exception e)
            {
                msjError = e.Message;
                dal.EstadoTransaccionDB = false;
            }
        }
        public void ing_area_col(ref cliente_web_dal dal, ref string msjError)
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

                dtParametros.Rows.Add("@colaborador", NormalizarParametro.almacenarTipo(ParametroSQL.INT), dal.Idcolaborador);
                dtParametros.Rows.Add("@provincia", NormalizarParametro.almacenarTipo(ParametroSQL.TINYINT), dal.Provincia);
           
                estado = client.ExecuteNonQuery(dal.Nombre_sp, dtParametros, ref msjError);

                dal.EstadoTransaccionDB = estado;
            }
            catch (Exception e)
            {
                msjError = e.Message;
                dal.EstadoTransaccionDB = false;
            }
        }

        public void ing_comercio_afi(ref cliente_web_dal dal, ref string msjError)
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

                dtParametros.Rows.Add("@roles", NormalizarParametro.almacenarTipo(ParametroSQL.INT), dal.IdRoles);
                dtParametros.Rows.Add("@nombreComercio", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Nombre);
                dtParametros.Rows.Add("@nombreUsuario", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.NombreUsuario);
                 dtParametros.Rows.Add("@pass", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Contrasena);
                dtParametros.Rows.Add("@correo", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Correo);
                dtParametros.Rows.Add("@tel", NormalizarParametro.almacenarTipo(ParametroSQL.VARCHAR), dal.Tel);
                dtParametros.Rows.Add("@estado", NormalizarParametro.almacenarTipo(ParametroSQL.BIT), dal.Estado1);

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
