using CGC_GM_BE.Common.Entities.Constantes;
using CGC_GM_BE.DataAccess.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_BE.Common.Entities
{
    public class _Resultado<T>
    {
        public _Resultado()
        {

        }

        public _Resultado(Exception exception)
        {
            if (exception == null)
            {
                ListaErrores = new List<Exception>();
            }
            else
            {
                ListaErrores = new List<Exception>() { exception };
            }
        }

        public _Resultado(_ResultadoDB resultadoDB)
        {
            Resultado = default(T);

            switch (resultadoDB.TipoConsulta)
            {
                case TipoConsulta.Insert:
                    Resultado = (T)Convert.ChangeType(resultadoDB.ResultadoTipoInsert, typeof(T));
                    break;
                case TipoConsulta.Update:
                    Resultado = (T)Convert.ChangeType(resultadoDB.ResultadoTipoDelete, typeof(T));
                    break;
                case TipoConsulta.Query:
                    Resultado = resultadoDB.ConvertirResultado<T>();
                    break;
                default:
                    break;
            }

            EsCorrecto = resultadoDB.EsCorrecto;

            if (resultadoDB.ListaExcepciones == null)
            {
                ListaErrores = new List<Exception>();
            }
            else
            {
                ListaErrores = new List<Exception>(resultadoDB.ListaExcepciones);
            }
        }

        public List<Exception> ListaErrores { get; set; }
        public bool EsCorrecto { get; set; }
        public T Resultado { get; set; }
    }
}
