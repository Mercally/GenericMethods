using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace CGC_GM_FE.WebAppMVC.HtmlExtensions
{
    public static class HtmlExtensions
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
    }
}