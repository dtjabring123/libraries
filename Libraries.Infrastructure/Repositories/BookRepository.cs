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
            var author = await _dbContext.Authors.FindAsync(book.AuthorId);
            if (author != null)
            {
                await _dbContext.Books.AddAsync(book);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("author not found");
            }
            return book;
        }

        public async Task<BookEntity> AddCheckOut(int bookId, int userId)
        {
            var book = await _dbContext.Books.FindAsync(bookId);
            if (book != null)
            {
                var user = await _dbContext.Users.FindAsync(userId);
                if (user != null)
                {
                    book.UserId = userId;
                    book.IsCheckedOut = true;
                    _dbContext.Books.Update(book);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException("user not found");
                }
            }
            else
            {
                throw new ArgumentException("book not found");
            }
            return book;
        }

        public async Task<BookEntity> AddReserve(int bookId, int userId)
        {
            var book = await _dbContext.Books.FindAsync(bookId);
            if (book != null)
            {
                var user = await _dbContext.Users.FindAsync(userId);
                if (user != null)
                {
                    book.UserId = userId;
                    book.IsReserved = true;
                    _dbContext.Books.Update(book);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException("user not found");
                }
            }
            else
            {
                throw new ArgumentException("book not found");
            }
            return book;
        }

        public async Task<BookEntity> AddToLibrary(int bookId, int libraryId)
        {
            var book = await _dbContext.Books.FindAsync(bookId);
            if (book != null)
            {
                var library = await _dbContext.Libraries.FindAsync(libraryId);
                if (library != null)
                {
                    book.LibraryId = libraryId;
                    _dbContext.Books.Update(book);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException("library not found");
                }
            }
            else
            {
                throw new ArgumentException("book not found");
            }
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
            else
            {
                throw new ArgumentException("book not found");
            }
            return book;
        }

        public async Task<BookEntity> RemoveCheckOut(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book != null)
            {
                book.UserId = null;
                book.IsCheckedOut = false;
                _dbContext.Books.Update(book);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("book not found");
            }
            return book;
        }

        public async Task<BookEntity> RemoveFromLibrary(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book != null)
            {
                book.LibraryId = null;
                _dbContext.Books.Update(book);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("book not found");
            }
            return book;
        }

        public async Task<BookEntity> RemoveReserve(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book != null)
            {
                book.UserId = null;
                book.IsReserved = false;
                _dbContext.Books.Update(book);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("book not found");
            }
            return book;
        }

        public async Task<BookEntity> Update(BookEntity book)
        {
            var author = await _dbContext.Authors.FindAsync(book.AuthorId);
            if (author != null)
            {
                _dbContext.Books.Update(book);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("author not found");
            }
            return book;
        }
    }
}