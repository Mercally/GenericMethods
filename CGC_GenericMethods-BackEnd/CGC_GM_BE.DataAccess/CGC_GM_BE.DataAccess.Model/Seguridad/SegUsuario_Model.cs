using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess.Context.Conexion;
using CGC_GM_BE.DataAccess.Context.Consulta;
using CGC_GM_BE.DataAccess.Context.GenericInterface;

namespace CGC_GM_BE.DataAccess.Model.Seguridad
{
    /// <summary>
    /// Hereda de ConsultaImpl
    /// </summary>
    public class SegUsuario_Model : AjustesComandosGenerico
    {
        /// <summary>
        /// Inicializa la transacción
        /// </summary>
        /// <param name="TimeOut"></param>
        public SegUsuario_Model(int TimeOut = 5) : base(TimeOut) { }
        

        /// <summary>
        /// Realiza consulta de usuarios
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        public IResultadoConsulta Consulta()
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                ConsultaT_Sql Consulta = new ConsultaT_Sql() // Ingresar consulta
                {
                    ConsultaCruda = "SELECT Id, NombreUsuario, Nombres, Apellidos, CorreoCorporativo, ContraseniaCorporativa FROM seg.Usuarios;",
                    TipoConsulta = TipoConsultaEnum.Query,
                    TimeOut = this.TimeOut
                };

                Comandos.Execute(Consulta, Transaccion, Resultado); // Obtener tipo de resultado

            }
            catch (Exception ex)
            {
                Resultado.Excepcion = ex;
                Excepciones.Add(ex);
            }

            return Resultado;
        }
    }
}
