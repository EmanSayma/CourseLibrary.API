using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CourseLibrary.API.ValidationAttributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CourseLibrary.API.Models
{
  public class CourseForCreationDto : CourseForManipulationDto
  {
  } 
}








 // public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    // {
    //     if(Title == Description)
    //     {
    //       yield return new ValidationResult(
    //         "The provided description should be different from the title.",
    //         new[] { "CourseForCreationDto"}
    //       );
    //     }
    // }