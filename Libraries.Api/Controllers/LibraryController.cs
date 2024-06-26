﻿using Libraries.Application.Commands.Library;
using Libraries.Application.Dtos.Library;
using Libraries.Application.Queries.Library;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Libraries.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LibraryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(nameof(Add))]
        [ProducesResponseType<LibraryDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LibraryDto>> Add(AddLibraryDto library)
        {
            return Ok(await _mediator.Send(new AddLibraryCommand(library)));
        }

        [HttpPatch(nameof(Update))]
        [ProducesResponseType<LibraryDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LibraryDto>> Update(UpdateLibraryDto library)
        {
            return Ok(await _mediator.Send(new UpdateLibraryCommand(library)));
        }

        [HttpDelete(nameof(Delete))]
        [ProducesResponseType<LibraryDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LibraryDto>> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteLibraryCommand(id)));
        }

        [HttpGet(nameof(GetAll))]
        [ProducesResponseType<IEnumerable<LibraryDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<LibraryDto>>> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllLibrariesQuery()));
        }

        [HttpGet(nameof(GetById))]
        [ProducesResponseType<IEnumerable<LibraryDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LibraryDto>> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetLibraryByIdQuery(id)));
        }
    }
}