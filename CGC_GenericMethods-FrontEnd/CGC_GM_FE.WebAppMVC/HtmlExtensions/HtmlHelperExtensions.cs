using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CGC_GM_FE.WebAppMVC.HtmlExtensions
{
    public static class HtmlHelperExtensions
    {
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null)
        {
            string cssClass = "active";
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }

        public static string PageClass(this HtmlHelper html)
        {
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            return currentAction;
        }

        /// <summary>
        /// Return options represnting the True and False titles of a 
        /// boolean field.
        /// </summary>
        /// <returns>A list with the false title at position 0, 
        /// and true title at position 1.</returns>
        public static IList<SelectListItem> OptionsForBoolean<TModel,
                                                              TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression,
                                                          htmlHelper.ViewData);
            object trueTitle;
            metaData.AdditionalValues.TryGetValue(
                BooleanDisplayValuesAttribute.TrueTitleAdditionalValueName,
                out trueTitle);
            trueTitle = trueTitle ?? "Si";

            object falseTitle;
            metaData.AdditionalValues.TryGetValue(
                BooleanDisplayValuesAttribute.FalseTitleAdditionalValueName,
                out falseTitle);
            falseTitle = falseTitle ?? "No";

            var options = new[]
                                {
                            new SelectListItem {Text = (string) falseTitle,
                                                Value = Boolean.FalseString},
                            new SelectListItem {Text = (string) trueTitle,
                                                Value = Boolean.TrueString},
                        };
            return options;
        }


        public static MvcHtmlString ButtonSaveChanges<TModel, TProperty>
        (this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, bool EsNuevo = true)
        {
            ModelMetadata Metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string DisplayName = Metadata.DisplayName.ToLower();
            string IdElement = $"btn-savechanges-{ DisplayName.Replace(" ", "_") }";
            string NameElement = $"btn-savechanges-{ DisplayName.Replace(" ", "_") }";
            string Value = $"value=\"{ (EsNuevo ? "Guardar nuevo" : "Guardar") } { (string.IsNullOrEmpty(Metadata.DisplayName) ? "" : Metadata.DisplayName) }\"";

            string StringHTml = $"<input type=\"submit\" { NameElement } { IdElement } { Value } class=\"btn btn-success\" />";

            return MvcHtmlString.Create(StringHTml);
        }

        public static MvcHtmlString EditorForCgc<TModel, TProperty>
        (this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            //var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            // <input ->name="" class=""
            var sad = htmlHelper.EditorFor(expression);
            var sad2 = htmlHelper.ValidationMessageFor(expression, "", new { @class = "text-danger" });

            var _stringHTml = sad.ToHtmlString();

            if (string.IsNullOrEmpty(metadata.Watermark))
            {
                return MvcHtmlString.Create(_stringHTml);
            }
            else
            {
                _stringHTml = $"<input placeholder=\"{metadata.Watermark}\"" + _stringHTml.Substring(6, _stringHTml.Length - 6);

                return MvcHtmlString.Create(_stringHTml);
            }
        }
    }
}