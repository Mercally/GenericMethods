using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess.Interfaces;

namespace CGC_GM_BE.DataAccess.Modelo
{
    public class Com_BoletasModelo : ContextoBase
    {
        public Com_BoletasModelo(IContextoCustomizado Contexto)
            : base(Contexto) { }

        public _Resultado ConsultaPorBoletaId(int BoletaId)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"SELECT Id, NumeroBoleta, FechaEntrada, FechaSalida, TiempoEfectivo, TiempoInvertidoEn, ProyectoId, ClienteId, FechaRegistro, UsuarioId, DepartamentoId, EsActivo 
                                  FROM com.Boleta 
                                  Where Id = @BoletaId",
                Parametros = new List<SqlParameter>()
                {
                    new SqlParameter("@BoletaId", BoletaId)
                },
                TipoConsulta = _TipoConsultaEnum.Query
            };

            _Resultado Resultado = new _Resultado();

            return Ejecutar(Consulta);
        }

        public _Resultado InsertarBoleta(Boleta Boleta)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"INSERT INTO com.Boleta(NumeroBoleta, FechaEntrada, FechaSalida, TiempoEfectivo, TiempoInvertidoEn, ProyectoId, ClienteId, UsuarioId, DepartamentoId, FechaRegistro, EsActivo)  
                                  VALUES(@NumeroBoleta, @FechaEntrada, @FechaSalida, @TiempoEfectivo, @TiempoInvertidoEn, @ProyectoId, @ClienteId, @UsuarioId, @DepartamentoId, @FechaRegistro, @EsActivo);
                                  SELECT SCOPE_IDENTITY();",
                Parametros = new List<SqlParameter>() {
                                new SqlParameter("NumeroBoleta", Boleta.NumeroBoleta),
                                new SqlParameter("FechaEntrada", Boleta.FechaEntrada),
                                new SqlParameter("FechaSalida", Boleta.FechaSalida),
                                new SqlParameter("TiempoInvertidoEn", Boleta.TiempoInvertidoEn),
                                new SqlParameter("TiempoEfectivo", Boleta.TiempoEfectivo),
                                new SqlParameter("ProyectoId", Boleta.ProyectoId),
                                new SqlParameter("ClienteId", Boleta.ClienteId),
                                new SqlParameter("UsuarioId", Boleta.UsuarioId),
                                new SqlParameter("DepartamentoId", Boleta.DepartamentoId),
                                new SqlParameter("FechaRegistro", Boleta.FechaRegistro),
                                new SqlParameter("EsActivo", Boleta.EsActivo)
                            },
                TipoConsulta = _TipoConsultaEnum.Insert
            };

            return Ejecutar(Consulta);
        }

        public _Resultado ModificarBoleta(Boleta Boleta)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"UPDATE com.Boleta SET NumeroBoleta=@NumeroBoleta, FechaEntrada=@FechaEntrada, FechaSalida=@FechaSalida, 
                                  TiempoEfectivo=@TiempoEfectivo, TiempoInvertidoEn=@TiempoInvertidoEn, ProyectoId=@ProyectoId, 
                                  ClienteId=@ClienteId, UsuarioId=@UsuarioId, DepartamentoId=@DepartamentoId, FechaRegistro=@FechaRegistro, EsActivo=@EsActivo WHERE Id=@id",
                Parametros = new List<SqlParameter>() {
                                new SqlParameter("id", Boleta.Id),
                                new SqlParameter("NumeroBoleta", Boleta.NumeroBoleta),
                                new SqlParameter("FechaEntrada", Boleta.FechaEntrada),
                                new SqlParameter("FechaSalida", Boleta.FechaSalida),
                                new SqlParameter("TiempoInvertidoEn", Boleta.TiempoInvertidoEn),
                                new SqlParameter("TiempoEfectivo", Boleta.TiempoEfectivo),
                                new SqlParameter("ProyectoId", Boleta.ProyectoId),
                                new SqlParameter("ClienteId", Boleta.ClienteId),
                                new SqlParameter("UsuarioId", Boleta.UsuarioId),
                                new SqlParameter("DepartamentoId", Boleta.DepartamentoId),
                                new SqlParameter("FechaRegistro", Boleta.FechaRegistro),
                                new SqlParameter("EsActivo", Boleta.EsActivo)
                            },
                TipoConsulta = _TipoConsultaEnum.Update
            };

            return Ejecutar(Consulta);
        }

        public _Resultado EliminarBoleta(int BoletaId, bool EsEliminadoFisico = false)
        {
            string ConsultaCruda = string.Empty;

            if (EsEliminadoFisico)
            {
                ConsultaCruda = "DELETE com.Boleta WHERE Id = @BoletaId;";
            }
            else
            {
                ConsultaCruda = "UPDATE com.Boleta SET EsActivo = 0 WHERE Id = @BoletaId";
            }

            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = ConsultaCruda,
                Parametros = new List<SqlParameter>()
                {
                    new SqlParameter("@BoletaId", BoletaId)
                },
                TipoConsulta = _TipoConsultaEnum.Delete
            };

            return Ejecutar(Consulta);
        }
    }
}
