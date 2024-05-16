using Libraries.Domain.Entities;

namespace Libraries.Application.Interfaces
{
    public interface ILibraryRepository
    {
        public Task<List<LibraryEntity>> GetAll();

        public Task<LibraryEntity> Add(LibraryEntity library);

        public Task<LibraryEntity> Delete(int id);
    }
}