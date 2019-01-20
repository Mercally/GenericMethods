using CGC_GM_FE.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CGC_GM_FE.WebAppMVC.ViewModels
{
    public class ActividadViewModel : CommonViewModel
    {
        public ActividadViewModel(TipoFormularioEnum tipoFormularioEnum)
        {
            TipoFormulario = tipoFormularioEnum;
        }

        private ActividadViewModel() { }

        private TipoFormularioEnum TipoFormulario { get; set; }

        public override MvcHtmlString View_TitlePage()
        {
            string Value = string.Empty;
            switch (TipoFormulario)
            {
                case TipoFormularioEnum.Detalle:
                    Value = "Detalle de actividad";
                    break;
                case TipoFormularioEnum.Crear:
                    Value = "Crear una nueva actividad";
                    break;
                case TipoFormularioEnum.Editar:
                    Value = "Modificar actividad";
                    break;
                case TipoFormularioEnum.Eliminar:
                    Value = "Eliminar actividad";
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
                    Value = "Detalle de la actividad actual.";
                    break;
                case TipoFormularioEnum.Crear:
                    Value = "Ingrese la información solicitada para crear una nueva actividad.";
                    break;
                case TipoFormularioEnum.Editar:
                    Value = "Modifique la información solicitada de la actividad actual.";
                    break;
                case TipoFormularioEnum.Eliminar:
                    Value = "Elimine la actividad actual.";
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
            string Value = $"<h4><i class=\"fa fa-{faicon}\"></i>&nbsp;Actividad</h4>";
            switch (TipoFormulario)
            {
                case TipoFormularioEnum.Detalle:
                    Value = Value.Replace(faicon, "check");
                    break;
                case TipoFormularioEnum.Crear:
                    Value = Value.Replace(faicon, "check");
                    break;
                case TipoFormularioEnum.Editar:
                    Value = Value.Replace(faicon, "check");
                    break;
                case TipoFormularioEnum.Eliminar:
                    Value = Value.Replace(faicon, "check");
                    break;
                default:
                    Value = Value = Value.Replace(faicon, "check"); ;
                    break;
            }
            return MvcHtmlString.Create(Value);
        }
    }
}