using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities.Modelo;
using CGC_GM_BE.Common.Entities.Constantes;
using CGC_GM_BE.DataAccess.Interfaces;

namespace CGC_GM_BE.DataAccess.Modelo
{
    public class Com_BoletasModelo : ContextoBase
    {
        public Com_BoletasModelo(IContextoCustomizado Contexto)
            : base(Contexto) { }

        public _Resultado<List<Boleta>> ConsultarBoletas()
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"SELECT Id, NumeroBoleta, Descripcion, FechaEntrada, FechaSalida, TiempoEfectivo, TiempoInvertidoEn, ProyectoId, ClienteId, FechaRegistro, UsuarioId, DepartamentoId, EsActivo 
                                  FROM com.Boleta;",
                TipoConsulta = TipoConsulta.Query
            };

            return Ejecutar<List<Boleta>>(Consulta);
        }

        public _ResultadoV2 ConsultarBoletasV2()
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"SELECT Id, NumeroBoleta, Descripcion, FechaEntrada, FechaSalida, TiempoEfectivo, TiempoInvertidoEn, ProyectoId, ClienteId, FechaRegistro, UsuarioId, DepartamentoId, EsActivo 
                                  FROM com.Boleta;",
                TipoConsulta = TipoConsulta.Query
            };

            return EjecutarV2(Consulta);
        }

        public _Resultado<Boleta> ConsultaPorBoletaId(int BoletaId)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"SELECT Id, NumeroBoleta, Descripcion, FechaEntrada, FechaSalida, TiempoEfectivo, TiempoInvertidoEn, ProyectoId, ClienteId, FechaRegistro, UsuarioId, DepartamentoId, EsActivo 
                                  FROM com.Boleta 
                                  Where Id = @BoletaId",
                Parametros = new List<SqlParameter>()
                {
                    new SqlParameter("@BoletaId", BoletaId)
                },
                TipoConsulta = TipoConsulta.Query
            };

            return Ejecutar<Boleta>(Consulta);
        }

        public _Resultado<int> InsertarBoleta(Boleta Boleta)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"INSERT INTO com.Boleta(NumeroBoleta, Descripcion, FechaEntrada, FechaSalida, TiempoEfectivo, TiempoInvertidoEn, ProyectoId, ClienteId, UsuarioId, DepartamentoId, FechaRegistro, EsActivo)  
                                  VALUES(@NumeroBoleta, @Descripcion, @FechaEntrada, @FechaSalida, @TiempoEfectivo, @TiempoInvertidoEn, @ProyectoId, @ClienteId, @UsuarioId, @DepartamentoId, @FechaRegistro, @EsActivo);
                                  SELECT SCOPE_IDENTITY();",
                Parametros = new List<SqlParameter>() {
                                new SqlParameter("NumeroBoleta", Boleta.NumeroBoleta),
                                new SqlParameter("Descripcion", Boleta.Descripcion),
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
                TipoConsulta = TipoConsulta.Insert
            };

            return Ejecutar<int>(Consulta);
        }

        public _Resultado<bool> ModificarBoleta(Boleta Boleta)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"UPDATE com.Boleta SET NumeroBoleta=@NumeroBoleta, Descripcion=@Descripcion, FechaEntrada=@FechaEntrada, FechaSalida=@FechaSalida, 
                                  TiempoEfectivo=@TiempoEfectivo, TiempoInvertidoEn=@TiempoInvertidoEn, ProyectoId=@ProyectoId, 
                                  ClienteId=@ClienteId, UsuarioId=@UsuarioId, DepartamentoId=@DepartamentoId, FechaRegistro=@FechaRegistro, EsActivo=@EsActivo WHERE Id=@BoletaId;",
                Parametros = new List<SqlParameter>() {
                                new SqlParameter("BoletaId", Boleta.Id),
                                new SqlParameter("NumeroBoleta", Boleta.NumeroBoleta),
                                new SqlParameter("Descripcion", Boleta.Descripcion),
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
                TipoConsulta = TipoConsulta.Update
            };

            return Ejecutar<bool>(Consulta);
        }

        public _Resultado<bool> EliminarBoleta(int BoletaId, bool EsEliminadoFisico = false)
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
                TipoConsulta = TipoConsulta.Delete
            };

            return Ejecutar<bool>(Consulta);
        }
    }
}
