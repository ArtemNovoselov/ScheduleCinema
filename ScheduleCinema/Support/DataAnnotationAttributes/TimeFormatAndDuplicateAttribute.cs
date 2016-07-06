using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ScheduleCinema.Support.DataAnnotationAttributes
{
    public class TimeFormatAndDuplicateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] times;
            var unformattedValue = value as string;
            if (unformattedValue == null)
            {
                return new ValidationResult("Необходимо передать строку");
            }
            else
            {
                times = unformattedValue.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var time in times)
            {
                TimeSpan outTimeSpan;
                if (!TimeSpan.TryParseExact(time, Formats.TimeFormat, null, out outTimeSpan))
                {
                    return new ValidationResult("Проверьте правильность введенного формата времени");
                }
                if (times.GroupBy(t => t).Any(t => t.Count() > 1))
                {
                    return new ValidationResult("Несколько одинаковых сеансов");
                }
            }
            return ValidationResult.Success;
        }
    }
}