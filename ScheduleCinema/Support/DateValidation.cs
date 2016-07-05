using System;
using System.Globalization;
using System.Web.Mvc;

namespace ScheduleCinema.Support
{
    public class DateValidation : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var descriptor = context.ActionDescriptor;

            if (descriptor != null && descriptor.ActionName == "Index" && descriptor.GetParameters().Length == 1)
            {
                var date = (string) context.ActionParameters["scheduleDate"];
                if (string.IsNullOrEmpty(date))
                {
                    context.ActionParameters["scheduleDate"] = DateTime.Now.ToString(Formats.DateFormat);
                }
                else
                {
                    DateTime formattedDate;
                    if (!DateTime.TryParseExact(date, Formats.DateFormat, null, DateTimeStyles.None, out formattedDate))
                    {
                        context.Controller.ViewData.ModelState.AddModelError("", ErrorMessages.ErrorDateFormatMessage);
                    }
                    else
                    {
                        context.ActionParameters["scheduleDate"] = formattedDate.Date;
                    }
                }
            }
            base.OnActionExecuting(context);
        }
    }
}