using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CGC_GM_BE.DataAccess.Interfaces;
using CGC_GM_BE.Common.Entities.Modelo;
using CGC_GM_BE.Common.Extensions;

namespace CGC_GM_BE.DataAccess.Modelo
{
    public class Rpt_Boletas : ContextoBase
    {
        public Rpt_Boletas(IContextoCustomizado Contexto) : base(Contexto) { }

        public _Resultado<List<RptBoletas>> ReporteBoleta(string fechaEntrada, string fechaSalida)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"SELECT
                                    bo.Id,
                                    bo.NumeroBoleta,
                                    bo.FechaEntrada,
                                    bo.FechaSalida,
                                    bo.TiempoEfectivo,
                                    bo.TiempoInvertidoEn,
                                    bo.ProyectoId,
                                    pro.Nombre AS ProyectoNombre,
                                    bo.ClienteId,
                                    cli.Nombre AS ClienteNombre,
                                    bo.UsuarioId,
                                    usu.Nombre + ' ' + usu.Apellido AS UsuarioNombreCompleto,
                                    bo.DepartamentoId,
                                    dep.Nombre AS DepartamentoNombre,
                                    bo.FechaRegistro,
                                    bo.EsActivo,
                                    bo.EsCobrable,
                                    bo.Descripcion
                                    FROM com.Boleta AS bo
                                    INNER JOIN neg.Proyecto AS pro ON pro.Id = bo.ProyectoId
                                    INNER JOIN neg.Cliente AS cli ON cli.Id = bo.ClienteId
                                    INNER JOIN seg.Usuario AS usu ON usu.Id = bo.UsuarioId
                                    INNER JOIN cat.Departamento AS dep ON dep.Id = bo.DepartamentoId
                                    WHERE
	                                    FechaEntrada >= @fechaEntrada 
                                    AND FechaSalida <= @fechaSalida 
                                    ORDER BY bo.ClienteId ASC, bo.FechaEntrada ASC, bo.Id ASC;",
                _TipoConsulta = TipoConsulta.Query,
                Parametros = new List<SqlParameter>()
               {
                    new SqlParameter("@fechaEntrada", fechaEntrada),
                    new SqlParameter("@fechaSalida", fechaSalida)
               }
            };

            return Ejecutar<List<RptBoletas>>(Consulta);
        }
    }
}
