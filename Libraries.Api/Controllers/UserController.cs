﻿using Libraries.Application.Commands.User;
using Libraries.Application.Dtos;
using Libraries.Application.Dtos.User;
using Libraries.Application.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Libraries.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(nameof(Add))]
        [ProducesResponseType<UserDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> Add(AddUserDto user)
        {
            return Ok(await _mediator.Send(new AddUserCommand(user)));
        }

        [HttpPatch(nameof(Update))]
        [ProducesResponseType<UserDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> Update(UpdateUserDto user)
        {
            return Ok(await _mediator.Send(new UpdateUserCommand(user)));
        }

        [HttpDelete(nameof(Delete))]
        [ProducesResponseType<UserDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteUserCommand(id)));
        }

        [HttpPut(nameof(AddToLibrary))]
        [ProducesResponseType<UserDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> AddToLibrary(int userId, int libraryId)
        {
            return Ok(await _mediator.Send(new AddUserToLibraryCommand(userId, libraryId)));
        }

        [HttpPut(nameof(RemoveFromLibrary))]
        [ProducesResponseType<UserDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> RemoveFromLibrary(int id)
        {
            return Ok(await _mediator.Send(new RemoveUserFromLibraryCommand(id)));
        }

        [HttpGet(nameof(GetAll))]
        [ProducesResponseType<IEnumerable<UserDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll(int libraryId = 0)
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery(libraryId)));
        }

        [HttpGet(nameof(GetById))]
        [ProducesResponseType<IEnumerable<UserDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetUserByIdQuery(id)));
        }
    }
}