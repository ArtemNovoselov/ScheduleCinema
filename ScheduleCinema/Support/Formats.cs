using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleCinema.Support
{
    public static class Formats
    {
        public const string DateFormat = @"dd.MM.yyyy";
        public const string DateFormatAttribute = @"{0:dd.MM.yyyy}";
        public const string TimeFormat = @"hh\:mm";
        public const string TimeFormatHtml = @"hh\:mm";

        public const string ErrorDateFormatMessage = @"Ошибка формата даты. Должен быть: dd.MM.yyyy";
    }
}