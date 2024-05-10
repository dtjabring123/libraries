using Libraries.Application.Interfaces;
using Libraries.Application.Services.Interfaces;
using Libraries.Domain.Entities;

namespace Libraries.Application.Services
{
    public class LibraryService : ILibraryService
    {
        public readonly ILibraryRepository libraryRepository;

        public LibraryService(ILibraryRepository libraryRepository)
        {
            this.libraryRepository = libraryRepository;
        }

        public async Task<List<Library>> GetAll()
        {
            var libraries = await libraryRepository.GetAll();
            return libraries;
        }

        public async Task Add(Library library)
        {
            await libraryRepository.Add(library);
        }
    }
}