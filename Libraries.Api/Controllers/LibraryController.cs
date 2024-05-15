using Libraries.Application.Commands;
using Libraries.Application.Dtos;
using Libraries.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Libraries.Api.Controllers
{
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LibraryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(nameof(GetAll))]
        [ProducesResponseType<IEnumerable<LibraryDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<LibraryDto>>> GetAll()
        {
            var query = new GetAllLibrariesQuery();
            var results = await _mediator.Send(query);
            return Ok(results);
        }

        [HttpPost(nameof(Add))]
        [ProducesResponseType<LibraryDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LibraryDto>> Add(LibraryDto library)
        {
            var command = new AddLibraryCommand(library);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}