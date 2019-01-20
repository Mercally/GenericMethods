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
    public class Rpt_Actividades : ContextoBase
    {
        public Rpt_Actividades(IContextoCustomizado Contexto) : base(Contexto) { }

        public _Resultado<List<RptActividades>> ReporteActividadesSegunBoleta(int boletaId)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"SELECT
                                ac.Id,
                                ac.BoletaId,
                                ac.Descripcion,
                                ac.FechaActividad,
                                ac.TiempoActividad,
                                ac.EstadoId,
                                ev.Nombre AS EstadoNombre,
                                ac.FechaRegistro,
                                ac.EsActivo
                                FROM com.Actividad AS ac
                                INNER JOIN cat.EstadoVisita AS ev ON ev.Id = ac.EstadoId
                                WHERE ac.BoletaId = @boletaId
                                ORDER BY ac.FechaRegistro ASC, ac.Id ASC;",
                _TipoConsulta = TipoConsulta.Query,
                Parametros = new List<SqlParameter>()
               {
                    new SqlParameter("@boletaId", boletaId)
               }
            };

            return Ejecutar<List<RptActividades>>(Consulta);
        }
    }
}
