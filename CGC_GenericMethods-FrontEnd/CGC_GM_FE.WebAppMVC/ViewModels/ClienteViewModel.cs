using CGC_GM_FE.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CGC_GM_FE.WebAppMVC.ViewModels
{
    public class ClienteViewModel : CommonViewModel
    {
        public ClienteViewModel(TipoFormularioEnum tipoFormularioEnum)
        {
            TipoFormulario = tipoFormularioEnum;
        }

        private ClienteViewModel() { }

        private TipoFormularioEnum TipoFormulario { get; set; }

        public override MvcHtmlString Card_TitlePage()
        {
            string Value = string.Empty;
            switch (TipoFormulario)
            {
                case TipoFormularioEnum.Detalle:
                    Value = "Detalle de cliente";
                    break;
                case TipoFormularioEnum.Crear:
                    Value = "Crear un nuevo cliente";
                    break;
                case TipoFormularioEnum.Editar:
                    Value = "Modificar cliente";
                    break;
                case TipoFormularioEnum.Eliminar:
                    Value = "Eliminar cliente";
                    break;
                default:
                    Value = "";
                    break;
            }
            Value = HtmlConstantes.HTitlePage.Replace("_TEXT_", Value);
            return MvcHtmlString.Create(Value);
        }

        public override MvcHtmlString Card_SubTitlePage()
        {
            string Value = string.Empty;
            switch (TipoFormulario)
            {
                case TipoFormularioEnum.Detalle:
                    Value = "Detalle del cliente actual.";
                    break;
                case TipoFormularioEnum.Crear:
                    Value = "Ingrese la información solicitada para crear un nuevo cliente.";
                    break;
                case TipoFormularioEnum.Editar:
                    Value = "Modifique la información solicitada del cliente actual.";
                    break;
                case TipoFormularioEnum.Eliminar:
                    Value = "Elimine el cliente actual.";
                    break;
                default:
                    Value = "";
                    break;
            }
            Value = HtmlConstantes.HSubTitlePage.Replace("_TEXT_", Value);
            return MvcHtmlString.Create(Value);
        }

        public override MvcHtmlString Card_Image()
        {
            return MvcHtmlString.Create($"<h4><i class=\"fa fa-user-plus\"></i>&nbsp;Cliente</h4>");
        }
    }
}