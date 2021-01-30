using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CourseLibrary.API.Helpers
{
    public static class DateTimeOffsetExtentions
    {
        public static int GetCurrentAge(this DateTimeOffset dateTimeOffset)
        {
          var currentDate = DateTime.UtcNow;
          int age = currentDate.Year - dateTimeOffset.Year;

          if(currentDate < dateTimeOffset.AddYears(age))
          {
              age--;
          }

          return age;
        }
    }
}