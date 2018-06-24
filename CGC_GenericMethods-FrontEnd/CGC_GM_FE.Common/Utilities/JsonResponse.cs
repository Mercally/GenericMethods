using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_FE.Common.Utilities
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
        /// Cadena de mensaje exitoso a mostrar
        /// </summary>
        public string MessageSuccess { get; private set; }
        /// <summary>
        /// Cadena de mensaje de error a mostrar
        /// </summary>
        public string MessageError { get; private set; }
        /// <summary>
        /// Url que redireccionará cuando la propiedad IsRedirected es verdadera
        /// </summary>
        public string RedirectTo { get; set; }
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
        /// Constructor por defecto
        /// </summary>
        /// <param name="ResponseId">Identificador de la respuesta</param>
        /// <param name="MessageSuccess">Mensaje de éxito</param>
        /// <param name="MessageError">Mensaje de error</param>
        public JsonResponse(string ResponseId = "Common", string MessageSuccess = null, string MessageError = null)
        {
            this.MessageSuccess = MessageSuccess ?? "Datos guardados exitosamente!";
            this.MessageError = MessageError ?? "Error al guardar los datos!";

            this.ResponseId = ResponseId;
            this.Modal = null;
            this.ListRenderPartialViews = new List<Ajax>();
        }
    }
}
