using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using ScheduleCinema.Models;

namespace ScheduleCinema.Support.HtmlHelpers
{
    public static class StringJoiner
    {
        public static MvcHtmlString Join(this HtmlHelper helper, IEnumerable<string> strings)
        {
            var str = string.Join(",", strings);
            return new MvcHtmlString(str);
        }
    }
}