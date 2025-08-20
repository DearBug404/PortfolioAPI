using AutoMapper;
using System;
using System.Globalization;

namespace Portfolio.Application.Mappings
{
    public class DateTimeToStringConverter : IValueConverter<DateTime?, string>
    {
        public string Convert(DateTime? sourceMember, ResolutionContext context)
        {
            return sourceMember.HasValue
                ? sourceMember.Value.ToString("yyyy-MM-dd HH:mm tt", CultureInfo.InvariantCulture)
                : "N/A";
        }
    }

}
