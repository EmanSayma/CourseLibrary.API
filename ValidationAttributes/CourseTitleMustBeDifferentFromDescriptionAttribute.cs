using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CourseLibrary.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CourseLibrary.API.ValidationAttributes
{
  public class CourseTitleMustBeDifferentFromDescriptionAttribute : ValidationAttribute
  {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var course = (CourseForManipulationDto)validationContext.ObjectInstance;
            if(course.Title == course.Description) 
            {
                return new ValidationResult(ErrorMessage,
                    new[] { nameof(CourseForManipulationDto)}
                );
            }

            return ValidationResult.Success;
        }
  }
}