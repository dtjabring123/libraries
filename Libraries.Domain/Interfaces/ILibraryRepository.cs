using Libraries.Domain.Entities;

namespace Libraries.Domain.Interfaces
{
    public interface ILibraryRepository
    {
        public Task<LibraryEntity> Add(LibraryEntity library);

        public Task<LibraryEntity> Update(LibraryEntity library);

        public Task<LibraryEntity> Delete(int id);

        public Task<LibraryEntity> GetById(int id);

        public Task<List<LibraryEntity>> GetAll();
    }
}