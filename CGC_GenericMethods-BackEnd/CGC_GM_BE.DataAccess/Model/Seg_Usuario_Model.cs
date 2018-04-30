using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess.Conexion;
using CGC_GM_BE.DataAccess.Consulta;
using CGC_GM_BE.DataAccess.Interface;
using CGC_GM_BE.DataAccess.Implement;
using CGC_GM_BE.DataAccess.Context;

namespace CGC_GM_BE.DataAccess.Model
{
    public class Seg_Usuario_Model
    {
        public CGC_GM_Contexto Contexto { get; }

        internal Seg_Usuario_Model(CGC_GM_Contexto Contexto)
        {
            this.Contexto = Contexto;
        }

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
                    TimeOut = Contexto.TimeOut
                };

                Resultado = Contexto.Comandos.Ejecutar(Consulta); // Obtener tipo de resultado

            }
            catch (Exception ex)
            {
                Resultado.Excepcion = ex;
                Contexto.Excepciones.Add(ex);
            }

            return Resultado;
        }
    }
}
