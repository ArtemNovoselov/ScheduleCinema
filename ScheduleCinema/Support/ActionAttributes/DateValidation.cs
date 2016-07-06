using System;
using System.Globalization;
using System.Web.Mvc;

namespace ScheduleCinema.Support.ActionAttributes
{
    public class DateValidation : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var descriptor = context.ActionDescriptor;

            if (descriptor != null && descriptor.ControllerDescriptor.ControllerName == "Home" && descriptor.ActionName == "Index" && descriptor.GetParameters().Length == 1 && descriptor.GetParameters()[0].ParameterType == typeof(string))
            {
                var date = (string) context.ActionParameters[descriptor.GetParameters()[0].ParameterName];
                if (string.IsNullOrEmpty(date))
                {
                    context.ActionParameters[descriptor.GetParameters()[0].ParameterName] = DateTime.Now.ToString(Formats.DateFormat);
                }
                else
                {
                    DateTime formattedDate;
                    if (!DateTime.TryParseExact(date, Formats.DateFormat, null, DateTimeStyles.None, out formattedDate))
                    {
                        context.Controller.ViewData.ModelState.AddModelError("", ErrorMessages.ErrorDateFormatMessage);
                    }
                }
            }
            base.OnActionExecuting(context);
        }
    }
}