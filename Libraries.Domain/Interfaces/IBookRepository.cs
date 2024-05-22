using Libraries.Domain.Entities;

namespace Libraries.Domain.Interfaces
{
    public interface IBookRepository
    {
        public Task<BookEntity> Add(BookEntity book);

        public Task<BookEntity> Delete(int id);

        public Task<BookEntity> Update(BookEntity book);
    }
}