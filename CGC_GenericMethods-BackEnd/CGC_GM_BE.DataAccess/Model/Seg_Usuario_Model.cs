using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//> usings
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess.Context;
using CGC_GM_BE.DataAccess.Interface;
using CGC_GM_BE.DataAccess.Implement;

namespace CGC_GM_BE.DataAccess.Model
{
    public class Seg_Usuario_Model : CGC_GM_Contexto
    {
        public IResultadoConsulta Consulta()
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                _ConsultaT_Sql Consulta = new _ConsultaT_Sql() // Ingresar consulta
                {
                    ConsultaCruda = @"SELECT Id, NombreUsuario, Nombres, Apellidos, CorreoCorporativo, ContraseniaCorporativa FROM seg.Usuarios;",
                    TipoConsulta = _TipoConsultaEnum.Query
                };

                Resultado = Comandos.Ejecutar(Consulta); // Obtener tipo de resultado

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
