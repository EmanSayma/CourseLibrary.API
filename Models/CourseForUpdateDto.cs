using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CourseLibrary.API.Models
{
  public class CourseForUpdateDto : CourseForManipulationDto
  {
    [Required(ErrorMessage = "You should fill out a description.")]
    public override string Description { get; set; }
  }
}