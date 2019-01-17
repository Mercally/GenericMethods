using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.DataAccess.Modelo;
using CGC_GM_BE.DataAccess.Interfaces;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.Common.Entities.Constantes;

namespace CGC_GM_BE.DataAccess
{
    public class ContextoBase
    {
        private IContextoCustomizado Contexto { get; set; }

        public ContextoBase(IContextoCustomizado Contexto)
        {
            this.Contexto = Contexto;
        }
        
        private ContextoBase() { }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="consulta"></param>
        /// <returns></returns>
        public _Resultado<T> Ejecutar<T>(_ConsultaT_Sql consulta)
        {
            _ResultadoDB ResultadoDB = new _ResultadoDB();

            try
            {
                ResultadoDB = this.Contexto.Ejecutar(consulta);
            }
            catch (Exception ex)
            {
                ResultadoDB.Excepcion = ex;
                this.Contexto.Excepciones(ex);
            }

            return new _Resultado<T>(ResultadoDB);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pObjecto"></param>
        /// <param name="tipoConsulta"></param>
        /// <returns></returns>
        public _Resultado<T> Ejecutar<T>(object pObjecto, int tipoConsulta)
        {
            _ResultadoDB ResultadoDB = new _ResultadoDB();

            var Consulta = _ConsultaT_Sql.CreateQuery(pObjecto, tipoConsulta);

            try
            {
                ResultadoDB = this.Contexto.Ejecutar(Consulta);
            }
            catch (Exception ex)
            {
                ResultadoDB.Excepcion = ex;
                this.Contexto.Excepciones(ex);
            }
            
            return new _Resultado<T>(ResultadoDB);
        }

        public _ResultadoV2 EjecutarV2(_ConsultaT_Sql Consulta)
        {
            _ResultadoV2 Resultado = new _ResultadoV2();

            try
            {
                Resultado = this.Contexto.EjecutarV2(Consulta);
            }
            catch (Exception ex)
            {
                Resultado.Excepcion = ex;
                this.Contexto.Excepciones(ex);
            }

            return Resultado;
        }
    }
}
