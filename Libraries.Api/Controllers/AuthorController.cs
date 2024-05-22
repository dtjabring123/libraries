﻿using Libraries.Application.Commands.Author;
using Libraries.Application.Dtos;
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

        [HttpPost(nameof(Delete))]
        [ProducesResponseType<AuthorDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthorDto>> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteAuthorCommand(id)));
        }

        [HttpPost(nameof(Update))]
        [ProducesResponseType<AuthorDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthorDto>> Update(AuthorDto author)
        {
            return Ok(await _mediator.Send(new UpdateAuthorCommand(author)));
        }
    }
}