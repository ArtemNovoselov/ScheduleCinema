using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using ScheduleCinema.Models;

namespace ScheduleCinema.Support.HtmlHelpers
{
    public static class SessionsTable
    {
        public static MvcHtmlString SessionsTableFor<TModel, TValue>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            var data = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var table = new TagBuilder("table");
            var tHead = new TagBuilder("thead");
            var tHeadTr = new TagBuilder("tr");
            /*foreach (string item in items)
            {
                TagBuilder li = new TagBuilder("li");
                li.SetInnerText(item);
                ul.InnerHtml += li.ToString();
            }*/
            return new MvcHtmlString(table.ToString());
        }
    }
}