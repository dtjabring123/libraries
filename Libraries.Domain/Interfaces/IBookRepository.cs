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

        public Task<ICollection<BookEntity>> GetAll(int libraryId);

        public Task<ICollection<BookEntity>> GetAllCheckedOut(int libraryId);

        public Task<ICollection<BookEntity>> GetAllCheckedOutForUser(int userId);

        public Task<ICollection<BookEntity>> GetAllCheckedOutWithAuthor(int libraryId, int authorId);

        public Task<ICollection<BookEntity>> GetAllReserved(int libraryId);

        public Task<ICollection<BookEntity>> GetAllReservedForUser(int userId);

        public Task<ICollection<BookEntity>> GetAllReservedWithAuthor(int libraryId, int authorId);

        public Task<ICollection<BookEntity>> GetAllWithAuthor(int libraryId, int authorId);

        public Task<BookEntity> GetById(int id);

        public Task<BookEntity> RemoveCheckOut(int id);

        public Task<BookEntity> RemoveFromLibrary(int id);

        public Task<BookEntity> RemoveReserve(int id);

        public Task<BookEntity> Update(BookEntity book);
    }
}