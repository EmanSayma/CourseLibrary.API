using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CourseLibrary.API.Profiles
{
  public class CoursesProfile : Profile
  {
      public CoursesProfile()
      {
          CreateMap<Entities.Course, Models.CourseDto>();

          CreateMap<Models.CourseForCreationDto, Entities.Course>();

          CreateMap<Models.CourseForUpdateDto, Entities.Course>();

          CreateMap<Entities.Course, Models.CourseForUpdateDto>();
      }

    
  }
}