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

        public Task<BookEntity> RemoveCheckOut(int id);

        public Task<BookEntity> RemoveFromLibrary(int id);

        public Task<BookEntity> RemoveReserve(int id);

        public Task<BookEntity> Update(BookEntity book);
    }
}