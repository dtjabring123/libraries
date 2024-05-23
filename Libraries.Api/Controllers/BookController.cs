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

        [HttpPatch(nameof(Update))]
        [ProducesResponseType<BookDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookDto>> Update(UpdateBookDto book)
        {
            return Ok(await _mediator.Send(new UpdateBookCommand(book)));
        }

        [HttpDelete(nameof(Delete))]
        [ProducesResponseType<BookDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookDto>> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteBookCommand(id)));
        }

        [HttpPut(nameof(AddCheckOut))]
        [ProducesResponseType<BookDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookDto>> AddCheckOut(int bookId, int userId)
        {
            return Ok(await _mediator.Send(new AddCheckOutToBookCommand(bookId, userId)));
        }

        [HttpPut(nameof(RemoveCheckOut))]
        [ProducesResponseType<BookDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookDto>> RemoveCheckOut(int id)
        {
            return Ok(await _mediator.Send(new RemoveCheckOutFromBookCommand(id)));
        }

        [HttpPut(nameof(AddReserve))]
        [ProducesResponseType<BookDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookDto>> AddReserve(int bookId, int userId)
        {
            return Ok(await _mediator.Send(new AddReserveToBookCommand(bookId, userId)));
        }

        [HttpPut(nameof(RemoveReserve))]
        [ProducesResponseType<BookDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookDto>> RemoveReserve(int id)
        {
            return Ok(await _mediator.Send(new RemoveReserveFromBookCommand(id)));
        }

        [HttpPut(nameof(AddToLibrary))]
        [ProducesResponseType<BookDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookDto>> AddToLibrary(int bookId, int libraryId)
        {
            return Ok(await _mediator.Send(new AddBookToLibraryCommand(bookId, libraryId)));
        }

        [HttpPut(nameof(RemoveFromLibrary))]
        [ProducesResponseType<BookDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookDto>> RemoveFromLibrary(int id)
        {
            return Ok(await _mediator.Send(new RemoveBookFromLibraryCommand(id)));
        }
    }
}