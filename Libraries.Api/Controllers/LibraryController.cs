using Libraries.Application.Services.Interfaces;
using Libraries.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Libraries.Api.Controllers
{
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<ActionResult<IList<Library>>> GetAll()
        {
            return Ok(await _libraryService.GetAll());
        }

        [HttpPost(nameof(Add))]
        public async Task Add(Library library)
        {
            await _libraryService.Add(library);
        }
    }
}