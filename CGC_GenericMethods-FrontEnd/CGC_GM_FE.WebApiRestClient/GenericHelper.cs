using CGC_GM_FE.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_FE.WebApiRestClient
{
    /// <summary>
    /// Proporciona los métodos genéricos para recuperar información
    /// desde los Apis
    /// </summary>
    internal class GenericHelper
    {
        /// <summary>
        /// Envía una petición a la url especificada con las opciones
        /// de configuración requerida
        /// </summary>
        /// <typeparam name="T">Tipo de dato a esperado</typeparam>
        /// <param name="Url">Url destino</param>
        /// <param name="Method">Tipo de método de la petición</param>
        /// <param name="Data">Objeto a enviar en la petición</param>
        /// <param name="TimeOut">Tiempo de espera en minutos</param>
        /// <returns></returns>
        internal static _Resultado<T> Request<T>(string Url, HttpMethodEnum Method, object Data = null, int TimeOut = 1)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.Timeout = TimeSpan.FromMinutes(TimeOut);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = null;

                    switch (Method)
                    {
                        case HttpMethodEnum.HttpGet:
                            response = client.GetAsync(Url).Result;
                            break;
                        case HttpMethodEnum.HttpPost_Json:
                            response = client.PostAsJsonAsync(Url, Data).Result;
                            break;
                        case HttpMethodEnum.HttpPut_Json:
                            response = client.PutAsJsonAsync(Url, Data).Result;
                            break;
                        case HttpMethodEnum.HttpDelete:
                            response = client.DeleteAsync(Url).Result;
                            break;
                        default:
                            break;
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        _Resultado<T> result = response.Content.ReadAsAsync<_Resultado<T>>().Result;
                        return result;
                    }
                    else
                    {
                        return default(_Resultado<T>);
                    }
                }
                catch (Exception ex)
                {
                    // Excepciones
                    return new _Resultado<T>(ex);
                }
            }
        }

    }
}
