using Libraries.Application.Commands.Book;
using Libraries.Application.Dtos.Book;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Libraries.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(nameof(Add))]
        [ProducesResponseType<BookDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookDto>> Add(AddBookDto book)
        {
            return Ok(await _mediator.Send(new AddBookCommand(book)));
        }

        [HttpPost(nameof(Delete))]
        [ProducesResponseType<BookDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookDto>> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteBookCommand(id)));
        }

        [HttpPost(nameof(Update))]
        [ProducesResponseType<BookDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookDto>> Update(UpdateBookDto book)
        {
            return Ok(await _mediator.Send(new UpdateBookCommand(book)));
        }
    }
}