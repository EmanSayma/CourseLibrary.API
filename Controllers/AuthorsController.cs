using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CourseLibrary.API.Services;
using CourseLibrary.API.Models;
using CourseLibrary.API.ResourceParameters;
using AutoMapper;

namespace CourseLibrary.API.Controlllers
{
  [ApiController]
  [Route("api/authors")]
  //  [Route("api/[controller]")] another option to write route

  public class AuthorsController : ControllerBase
  {
    private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

      public AuthorsController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
      {
        _courseLibraryRepository = courseLibraryRepository ??
                 throw new ArgumentNullException(nameof(courseLibraryRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

    [HttpGet()]
    [HttpHead]
    public ActionResult<IEnumerable<AuthorDto>> GetAuthors([FromQuery] AuthorsResourceParameters authorsResourceParameters)   //optional to add [FormQuery(Name= "))] because we have attribute ApiController above
    {
      var authorsFromRepo = _courseLibraryRepository.GetAuthors(authorsResourceParameters);

      return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
    }

    [HttpGet("{authorId}", Name="GetAuthor")]
    public IActionResult GetAuthor(Guid authorId)
    {
      var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);

      if (authorFromRepo == null) 
      {
        return NotFound();
      }

      return Ok(_mapper.Map<AuthorDto>(authorFromRepo));
    }

    [HttpPost]
    public ActionResult<AuthorDto> createAuthor(AuthorForCreationDto author)
    {
      var authorEntity = _mapper.Map<Entities.Author>(author);
      _courseLibraryRepository.AddAuthor(authorEntity);
      _courseLibraryRepository.Save();

      var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);

      return CreatedAtRoute("GetAuthor",
          new { authorId = authorToReturn.Id},
           authorToReturn
      );
    }

    [HttpOptions]
    public IActionResult GetAuthorOptions()
    {
      Response.Headers.Add("Allow", "GET, OPTIONS, POST");
      return Ok();
    } 
  }
}