using DemoCleanArchitecture.ApplicationCore.Interfaces.Services;
using DemoCleanArchitecture.Domain.Exceptions;
using DemoCleanArchitecture.Domain.Modeles;
using DemoCleanArchitecture.Presentation.WebAPI.Dto.Input;
using DemoCleanArchitecture.Presentation.WebAPI.Dto.Output;
using DemoCleanArchitecture.Presentation.WebAPI.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoCleanArchitecture.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AuthorOutputDTO>))]
        public IActionResult GetAll(int page = 1, int nbElement = 10)
        {
            IEnumerable<Author> authors = _authorService.GetAll(page, nbElement);

            return Ok(authors.Select(a => a.ToDTO()));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorDetailOutputDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById([FromRoute] long id)
        {
            try
            {
                Author author = _authorService.GetById(id);
                return Ok(author.ToDetailDTO());
            }
            catch (AuthorNotFoundException ex)
            {
                return NotFound(new { message = ex.Message, });
            }
        }
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AuthorDetailOutputDTO))]
        public IActionResult Create([FromBody] AuthorInputDTO data)
        {
            Author authorCreated = _authorService.Create(data.ToModel());
            return CreatedAtAction(nameof(GetById), new { id = authorCreated.Id }, authorCreated.ToDetailDTO());
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorDetailOutputDTO))]
        public IActionResult Update([FromRoute] long id, [FromBody] AuthorInputDTO data)
        {
            try
            {
                Author authorToUpdate = data.ToModel();
                authorToUpdate.Id = id;
                Author authorUpdated = _authorService.Update(authorToUpdate);
                return Ok(authorUpdated.ToDetailDTO());
            }
            catch (AuthorNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

    }
}
