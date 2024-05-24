using Libraries.Application.Commands.Book;
using Libraries.Application.Dtos.Book;
using Libraries.Application.Queries.Book;
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

        [HttpGet(nameof(GetAll))]
        [ProducesResponseType<IEnumerable<BookDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAll(int libraryId = 0)
        {
            return Ok(await _mediator.Send(new GetAllBooksQuery(libraryId)));
        }

        [HttpGet(nameof(GetById))]
        [ProducesResponseType<IEnumerable<BookDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookDto>> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetBookByIdQuery(id)));
        }

        [HttpGet(nameof(GetAllCheckedOut))]
        [ProducesResponseType<IEnumerable<BookDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllCheckedOut(int libraryId = 0)
        {
            return Ok(await _mediator.Send(new GetAllBooksCheckedOutQuery(libraryId)));
        }

        [HttpGet(nameof(GetAllReserved))]
        [ProducesResponseType<IEnumerable<BookDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllReserved(int libraryId = 0)
        {
            return Ok(await _mediator.Send(new GetAllBooksReservedQuery(libraryId)));
        }

        [HttpGet(nameof(GetAllCheckedOutForUser))]
        [ProducesResponseType<IEnumerable<BookDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllCheckedOutForUser(int userId)
        {
            return Ok(await _mediator.Send(new GetAllBooksCheckedOutForUserQuery(userId)));
        }

        [HttpGet(nameof(GetAllReservedForUser))]
        [ProducesResponseType<IEnumerable<BookDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllReservedForUser(int userId)
        {
            return Ok(await _mediator.Send(new GetAllBooksReservedForUserQuery(userId)));
        }

        [HttpGet(nameof(GetAllWithAuthor))]
        [ProducesResponseType<IEnumerable<BookDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllWithAuthor(int authorId, int libraryId = 0)
        {
            return Ok(await _mediator.Send(new GetAllBooksWithAuthorQuery(authorId, libraryId)));
        }

        [HttpGet(nameof(GetAllCheckedOutWithAuthor))]
        [ProducesResponseType<IEnumerable<BookDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllCheckedOutWithAuthor(int authorId, int libraryId = 0)
        {
            return Ok(await _mediator.Send(new GetAllBooksCheckedOutWithAuthorQuery(authorId, libraryId)));
        }

        [HttpGet(nameof(GetAllReservedWithAuthor))]
        [ProducesResponseType<IEnumerable<BookDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllReservedWithAuthor(int authorId, int libraryId = 0)
        {
            return Ok(await _mediator.Send(new GetAllBooksReservedWithAuthorQuery(authorId, libraryId)));
        }
    }
}