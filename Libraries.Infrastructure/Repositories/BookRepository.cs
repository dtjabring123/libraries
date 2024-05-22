using Libraries.Domain.Entities;
using Libraries.Domain.Interfaces;
using Libraries.Infrastructure.Persistence;

namespace Libraries.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _dbContext;

        public BookRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookEntity> Add(BookEntity book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<BookEntity> Delete(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book != null)
            {
                book.IsDeleted = true;
                _dbContext.Books.Update(book);
                await _dbContext.SaveChangesAsync();
            }
            return book;
        }

        public async Task<BookEntity> Update(BookEntity book)
        {
            _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }
    }
}