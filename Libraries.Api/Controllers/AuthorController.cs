using Libraries.Application.Commands.Author;
using Libraries.Application.Dtos;
using Libraries.Application.Dtos.Author;
using Libraries.Application.Dtos.Library;
using Libraries.Application.Queries.Author;
using Libraries.Application.Queries.Library;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Libraries.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(nameof(Add))]
        [ProducesResponseType<AuthorDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthorDto>> Add(AddAuthorDto author)
        {
            return Ok(await _mediator.Send(new AddAuthorCommand(author)));
        }

        [HttpPatch(nameof(Update))]
        [ProducesResponseType<AuthorDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthorDto>> Update(UpdateAuthorDto author)
        {
            return Ok(await _mediator.Send(new UpdateAuthorCommand(author)));
        }

        [HttpDelete(nameof(Delete))]
        [ProducesResponseType<AuthorDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthorDto>> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteAuthorCommand(id)));
        }

        [HttpGet(nameof(GetAll))]
        [ProducesResponseType<IEnumerable<AuthorDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllAuthorsQuery()));
        }

        [HttpGet(nameof(GetById))]
        [ProducesResponseType<IEnumerable<AuthorDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthorDto>> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetAuthorByIdQuery(id)));
        }
    }
}