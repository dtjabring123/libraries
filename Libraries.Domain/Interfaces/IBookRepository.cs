using Libraries.Domain.Entities;

namespace Libraries.Domain.Interfaces
{
    public interface IBookRepository
    {
        public Task<BookEntity> Add(BookEntity book);

        public Task<BookEntity> AddCheckOut(int bookId, int userId);

        public Task<BookEntity> AddReserve(int bookId, int userId);

        public Task<BookEntity> AddToLibrary(int bookId, int libraryId);

        public Task<BookEntity> Delete(int id);

        public Task<IEnumerable<BookEntity>> GetAll(int libraryId = 0);

        public Task<IEnumerable<BookEntity>> GetAllCheckedOut(int libraryId = 0);

        public Task<IEnumerable<BookEntity>> GetAllCheckedOutForUser(int userId);

        public Task<IEnumerable<BookEntity>> GetAllCheckedOutWithAuthor(int authorId, int libraryId = 0);

        public Task<IEnumerable<BookEntity>> GetAllReserved(int libraryId = 0);

        public Task<IEnumerable<BookEntity>> GetAllReservedForUser(int userId);

        public Task<IEnumerable<BookEntity>> GetAllReservedWithAuthor(int authorId, int libraryId = 0);

        public Task<IEnumerable<BookEntity>> GetAllWithAuthor(int authorId, int libraryId = 0);

        public Task<BookEntity> GetById(int id);

        public Task<BookEntity> RemoveCheckOut(int id);

        public Task<BookEntity> RemoveFromLibrary(int id);

        public Task<BookEntity> RemoveReserve(int id);

        public Task<BookEntity> Update(BookEntity book);
    }
}