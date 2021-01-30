using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CourseLibrary.API.ResourceParameters
{
  public class AuthorsResourceParameters
  {
      public string MainCategory { get; set; }
      public string SearchQuery { get; set; }
  }
}