using CGC_GM_FE.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CGC_GM_FE.WebAppMVC.ViewModels
{
    public class BoletaViewModel : CommonViewModel
    {
        public BoletaViewModel(TipoFormularioEnum tipoFormularioEnum)
        {
            TipoFormulario = tipoFormularioEnum;
        }

        private BoletaViewModel() { }

        private TipoFormularioEnum TipoFormulario { get; set; }

        public override MvcHtmlString View_TitlePage()
        {
            string Value = string.Empty;
            switch (TipoFormulario)
            {
                case TipoFormularioEnum.Detalle:
                    Value = "Detalle de boleta";
                    break;
                case TipoFormularioEnum.Crear:
                    Value = "Crear una nueva boleta";
                    break;
                case TipoFormularioEnum.Editar:
                    Value = "Modificar boleta";
                    break;
                case TipoFormularioEnum.Eliminar:
                    Value = "Eliminar boleta";
                    break;
                default:
                    Value = "";
                    break;
            }
            return MvcHtmlString.Create(Value);
        }

        public override MvcHtmlString Card_TitlePage()
        {
            string Value = this.View_TitlePage().ToHtmlString();
            Value = HtmlConstantes.HTitlePage.Replace("_TEXT_", Value);
            return MvcHtmlString.Create(Value);
        }

        public override MvcHtmlString Card_SubTitlePage()
        {
            string Value = string.Empty;
            switch (TipoFormulario)
            {
                case TipoFormularioEnum.Detalle:
                    Value = "Detalle de la boleta actual.";
                    break;
                case TipoFormularioEnum.Crear:
                    Value = "Ingrese la información solicitada para crear una nueva boleta.";
                    break;
                case TipoFormularioEnum.Editar:
                    Value = "Modifique la información solicitada de la boleta actual.";
                    break;
                case TipoFormularioEnum.Eliminar:
                    Value = "Elimine la boleta actual.";
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
            const string faicon = "_FAICON_";
            string Value = $"<h4><i class=\"fa fa-{faicon}\"></i>&nbsp;Boleta</h4>";
            switch (TipoFormulario)
            {
                case TipoFormularioEnum.Detalle:
                    Value = Value.Replace(faicon, "calendar-day");
                    break;
                case TipoFormularioEnum.Crear:
                    Value = Value.Replace(faicon, "calendar-plus");
                    break;
                case TipoFormularioEnum.Editar:
                    Value = Value.Replace(faicon, "calendar-check");
                    break;
                case TipoFormularioEnum.Eliminar:
                    Value = Value.Replace(faicon, "calendar-minus");
                    break;
                default:
                    Value = Value = Value.Replace(faicon, "calendar"); ;
                    break;
            }
            return MvcHtmlString.Create(Value);
        }
    }
}