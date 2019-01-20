using CGC_GM_FE.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CGC_GM_FE.WebAppMVC.ViewModels
{
    public class ProyectoViewModel : CommonViewModel
    {
        public ProyectoViewModel(TipoFormularioEnum tipoFormularioEnum)
        {
            TipoFormulario = tipoFormularioEnum;
        }

        private ProyectoViewModel() { }

        private TipoFormularioEnum TipoFormulario { get; set; }

        public override MvcHtmlString View_TitlePage()
        {
            string Value = string.Empty;
            switch (TipoFormulario)
            {
                case TipoFormularioEnum.Detalle:
                    Value = "Detalle de proyecto";
                    break;
                case TipoFormularioEnum.Crear:
                    Value = "Crear un nuevo proyecto";
                    break;
                case TipoFormularioEnum.Editar:
                    Value = "Modificar proyecto";
                    break;
                case TipoFormularioEnum.Eliminar:
                    Value = "Eliminar proyecto";
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
                    Value = "Detalle del proyecto actual.";
                    break;
                case TipoFormularioEnum.Crear:
                    Value = "Ingrese la información solicitada para crear un nuevo proyecto.";
                    break;
                case TipoFormularioEnum.Editar:
                    Value = "Modifique la información solicitada del proyecto actual.";
                    break;
                case TipoFormularioEnum.Eliminar:
                    Value = "Elimine el proyecto actual.";
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
            string Value = $"<h4><i class=\"fa fa-{faicon}\"></i>&nbsp;Proyecto</h4>";
            switch (TipoFormulario)
            {
                case TipoFormularioEnum.Detalle:
                    Value = Value.Replace(faicon, "project-diagram");
                    break;
                case TipoFormularioEnum.Crear:
                    Value = Value.Replace(faicon, "project-diagram");
                    break;
                case TipoFormularioEnum.Editar:
                    Value = Value.Replace(faicon, "project-diagram");
                    break;
                case TipoFormularioEnum.Eliminar:
                    Value = Value.Replace(faicon, "project-diagram");
                    break;
                default:
                    Value = Value = Value.Replace(faicon, "project-diagram"); ;
                    break;
            }
            return MvcHtmlString.Create(Value);
        }
    }
}