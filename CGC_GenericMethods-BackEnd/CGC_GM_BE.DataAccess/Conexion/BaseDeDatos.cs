using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_BE.DataAccess.Conexion
{
    /// <summary>
    /// Establece conexión con las bases de datos
    /// </summary>
    internal static class BaseDeDatos
    {
        /// <summary>
        /// Recupera la cadena de conexion del archivo de configuracion respectivo
        /// </summary>
        private static string CadenaDeConexion_CGC_GM
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
        internal static SqlConnection Conectar_CGC_GM()
        {
            SqlConnection Connection = null;

            Connection = new SqlConnection(CadenaDeConexion_CGC_GM);

            if (Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.Open();
            }

            return Connection;
        }
    }
}
