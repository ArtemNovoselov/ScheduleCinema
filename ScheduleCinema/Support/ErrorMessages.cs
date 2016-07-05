using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleCinema.Support
{
    public class ErrorMessages
    {
        public const string ErrorDateFormatMessage = @"Ошибка формата даты. Должен быть: dd.MM.yyyy";
        public const string ErrorDateSessionsMessage = @"Расписания за выбранную дату не найдены";
    }
}