using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CGC_GM_FE.WebAppMVC.Models.Utilities
{
    public class JsonResponse
    {
        /// <summary>
        /// Identificador de la respuesta para recibir los diferentes tipos de respuesta y darle tratamiento especificado
        /// desde la carga ajax.
        /// </summary>
        public string ResponseId { get; private set; }
        /// <summary>
        /// Determina si la transacción se realizó exitosamente
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Determina si se hará una redirección
        /// </summary>
        public bool IsRedirected { get; set; }
        /// <summary>
        /// Url que redireccionará cuando la propiedad IsRedirected es verdadera
        /// </summary>
        public string RedirectTo { get; set; }
        /// <summary>
        /// Cadena de mensaje exitoso/fallo a mostrar
        /// </summary>
        public string Message { get; private set; }
        /// <summary>
        /// Realiza un refrezco completo de la url actual
        /// </summary>
        public bool IsReloaded { get; set; }
        /// <summary>
        /// Objecto modal, proporciona propiedades para manejo de modales
        /// </summary>
        public Modal Modal { get; set; }
        /// <summary>
        /// Opciones para renderizar las vistas parciales
        /// </summary>
        public List<Ajax> ListRenderPartialViews { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Redirects[] ListRedirects { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <param name="ResponseId">Identificador de la respuesta</param>
        /// <param name="Message">Mensaje de éxito</param>
        private JsonResponse(bool isSuccess, string message, Redirects[] redirects)
        {
            Message = message;
            IsSuccess = isSuccess;
            ResponseId = "Common";
            Modal = null;
            ListRenderPartialViews = new List<Ajax>();
            ListRedirects = redirects ?? new Redirects[0];
        }

        public static JsonResponse JResponse(bool isSuccess, string message = null, params Redirects[] redirects)
        {
            if (string.IsNullOrEmpty(message))
                message = isSuccess ? "Los datos se han guardado exitosamente (:" :
                    "Lo sentimos, ocurrió un error al guardar los datos :(";

            return new JsonResponse(isSuccess, message, redirects);
        }
    }
}
