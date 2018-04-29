using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.DataAccess.Context.Consulta;
using CGC_GM_BE.DataAccess.Context.GenericInterface;

namespace CGC_GM_BE.DataAccess.Context.Conexion
{
    public class Comandos
    {
        /// <summary>
        /// Retorna una tabla de acuerdo a la consulta proporcionada
        /// </summary>
        /// <param name="Consulta"></param>
        /// <param name="Transaccion"></param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(ConsultaT_Sql Consulta, SqlTransaction Transaccion)
        {
            DataTable DataTable = new DataTable();

            if (Transaccion.Connection.State != ConnectionState.Open)
            {
                Transaccion.Connection.Open();
            }

            SqlCommand cmd = new SqlCommand(Consulta.ConsultaCruda, Transaccion.Connection, Transaccion);
            cmd.CommandTimeout = Consulta.TimeOut;
            cmd.Parameters.AddRange(Consulta.Parametros.ToArray());

            SqlDataReader sqldr = cmd.ExecuteReader();
            DataTable.Load(sqldr);

            return DataTable;
        }

        /// <summary>
        /// Ejecuta comandos delete y update
        /// </summary>
        /// <param name="Consulta"></param>
        /// <param name="Transaccion"></param>
        /// <returns></returns>
        public static bool ExecuteNonQuery(ConsultaT_Sql Consulta, SqlTransaction Transaccion)
        {
            if (Transaccion.Connection.State != ConnectionState.Open)
            {
                Transaccion.Connection.Open();
            }

            SqlCommand cmd = new SqlCommand(Consulta.ConsultaCruda, Transaccion.Connection, Transaccion);
            cmd.CommandTimeout = Consulta.TimeOut;
            cmd.Parameters.AddRange(Consulta.Parametros.ToArray());

            int Changes = cmd.ExecuteNonQuery();

            return Changes > 0 || true; // Si no hay cambios
        }

        /// <summary>
        /// Ejecuta un comando que devuelve un solo valor
        /// </summary>
        /// <param name="Consulta"></param>
        /// <param name="Transaction"></param>
        /// <returns></returns>
        public static int ExecuteScalarInsert(ConsultaT_Sql Consulta, SqlTransaction Transaccion)
        {
            int? Result = 0;

            if (Transaccion.Connection.State != ConnectionState.Open)
            {
                Transaccion.Connection.Open();
            }

            SqlCommand cmd = new SqlCommand(Consulta.ConsultaCruda, Transaccion.Connection, Transaccion);
            cmd.CommandTimeout = Consulta.TimeOut;
            cmd.Parameters.AddRange(Consulta.Parametros.ToArray());
            
            Result = (int?)cmd.ExecuteScalar() as int?;

            return Result ?? 0;
        }

        /// <summary>
        /// Ejecuta un comando que devuelve un solo valor
        /// </summary>
        /// <param name="Consulta"></param>
        /// <param name="Transaction"></param>
        /// <returns></returns>
        public static object ExecuteScalar(ConsultaT_Sql Consulta, SqlTransaction Transaccion)
        {
            object Result = null;

            if (Transaccion.Connection.State != ConnectionState.Open)
            {
                Transaccion.Connection.Open();
            }

            SqlCommand cmd = new SqlCommand(Consulta.ConsultaCruda, Transaccion.Connection, Transaccion);
            cmd.CommandTimeout = Consulta.TimeOut;
            cmd.Parameters.AddRange(Consulta.Parametros.ToArray());

            Result = cmd.ExecuteScalar();

            return Result;
        }

        /// <summary>
        /// Ejecuta la consulta de acuerdo a la especificacion del tipo de consulta
        /// </summary>
        /// <param name="Consulta">Consulta a ejecutar</param>
        /// <param name="Transaccion">Transaccion original</param>
        /// <returns>objeto segun tipo de transaccion</returns>
        public static void Execute(ConsultaT_Sql Consulta, SqlTransaction Transaccion, IResultadoConsulta Resultado)
        {
            if (Resultado == null)
            {
                Resultado = new ResultadoGenericoImpl();
            }

            switch (Consulta.TipoConsulta)
            {
                case TipoConsultaEnum.Insert:
                    Resultado.ResultadoTipoInsert = ExecuteScalarInsert(Consulta, Transaccion);
                    break;
                case TipoConsultaEnum.Update:
                    Resultado.ResultadoTipoUpdate = ExecuteNonQuery(Consulta, Transaccion);
                    break;
                case TipoConsultaEnum.Delete:
                    Resultado.ResultadoTipoDelete = ExecuteNonQuery(Consulta, Transaccion);
                    break;
                case TipoConsultaEnum.Query:
                    Resultado.ResultadoTipoQuery = ExecuteQuery(Consulta, Transaccion);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("No existe la opción especificada");
            }
        }
    }
}
