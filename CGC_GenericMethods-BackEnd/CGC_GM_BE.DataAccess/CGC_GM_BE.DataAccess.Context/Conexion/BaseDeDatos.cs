using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_BE.DataAccess.Context.Conexion
{
    internal static class BaseDeDatos
    {
        private static string CadenaDeConexion
        {
            get
            {
                return ConfigurationSettings.AppSettings["CadenaDeConexion"];
            }
        }

        /// <summary>
        /// Establece y abre la conexión con la base de datos
        /// </summary>
        /// <returns></returns>
        internal static SqlConnection Conectar()
        {
            SqlConnection Connection = null;
            try
            {
                Connection = new SqlConnection(CadenaDeConexion);
                if (Connection.State != System.Data.ConnectionState.Open)
                {
                    Connection.Open();
                }
            }
            catch (Exception)
            {

            }

            return Connection;
        }
    }
}
