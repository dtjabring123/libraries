using Libraries.Domain.Entities;

namespace Libraries.Application.Interfaces
{
    public interface ILibraryRepository
    {
        public Task<List<Library>> GetAll();

        public Task Add(Library library);
    }
}