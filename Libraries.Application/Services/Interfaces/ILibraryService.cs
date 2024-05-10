using Libraries.Domain.Entities;

namespace Libraries.Application.Services.Interfaces
{
    public interface ILibraryService
    {
        public Task<List<Library>> GetAll();

        public Task Add(Library library);
    }
}