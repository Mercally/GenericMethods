using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.DataAccess.Modelo;
using CGC_GM_BE.DataAccess.Interfaces;

namespace CGC_GM_BE.DataAccess
{
    public class ContextoBase : IBaseContext
    {
        private IContextoCustomizado Contexto { get; set; }

        public ContextoBase(IContextoCustomizado Contexto)
        {
            this.Contexto = Contexto;
        }
        
        private ContextoBase() { }

        public _Resultado Ejecutar(_ConsultaT_Sql Consulta)
        {
            _Resultado Resultado = new _Resultado();

            try
            {
                Resultado = this.Contexto.Ejecutar(Consulta);
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
