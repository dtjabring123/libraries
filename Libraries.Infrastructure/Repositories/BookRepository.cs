using Libraries.Domain.Entities;
using Libraries.Domain.Interfaces;
using Libraries.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Data;

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

        public async Task<IEnumerable<BookEntity>> GetAll(int libraryId = 0)
        {
            if (libraryId == 0)
            {
                return await _dbContext.Books.ToListAsync();
            }
            else
            {
                return await _dbContext.Books.Where(e => e.LibraryId == libraryId).ToListAsync();
            }
        }

        public async Task<IEnumerable<BookEntity>> GetAllCheckedOut(int libraryId = 0)
        {
            if (libraryId == 0)
            {
                return await _dbContext.Books.Where(e => e.IsCheckedOut == true).ToListAsync();
            }
            else
            {
                return await _dbContext.Books.Where(e => e.LibraryId == libraryId && e.IsCheckedOut == true).ToListAsync();
            }
        }

        public async Task<IEnumerable<BookEntity>> GetAllCheckedOutForUser(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new ArgumentException("user not found");
            }
            return (IEnumerable<BookEntity>)await _dbContext.Users.Where(u => u.Id == userId).Include(e => e.Books.Where(b => b.IsCheckedOut)).ToListAsync();
        }

        public async Task<IEnumerable<BookEntity>> GetAllCheckedOutWithAuthor(int authorId, int libraryId = 0)
        {
            var author = await _dbContext.Books.FindAsync(authorId);
            if (author == null)
            {
                throw new ArgumentException("author not found");
            }
            else
            {
                if (libraryId == 0)
                {
                    return await _dbContext.Books.Where(e => e.IsCheckedOut == true && e.AuthorId == authorId).ToListAsync();
                }
                else
                {
                    return await _dbContext.Books.Where(e => e.LibraryId == libraryId && e.IsCheckedOut == true && e.AuthorId == authorId).ToListAsync();
                }
            }
        }

        public async Task<IEnumerable<BookEntity>> GetAllReserved(int libraryId = 0)
        {
            if (libraryId == 0)
            {
                return await _dbContext.Books.Where(e => e.IsReserved == true).ToListAsync();
            }
            else
            {
                return await _dbContext.Books.Where(e => e.LibraryId == libraryId && e.IsReserved == true).ToListAsync();
            }
        }

        public async Task<IEnumerable<BookEntity>> GetAllReservedForUser(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new ArgumentException("user not found");
            }
            return (IEnumerable<BookEntity>)await _dbContext.Users.Where(u => u.Id == userId).Include(e => e.Books.Where(b => b.IsReserved)).ToListAsync();
        }

        public async Task<IEnumerable<BookEntity>> GetAllReservedWithAuthor(int authorId, int libraryId = 0)
        {
            var author = await _dbContext.Books.FindAsync(authorId);
            if (author == null)
            {
                throw new ArgumentException("author not found");
            }
            else
            {
                if (libraryId == 0)
                {
                    return await _dbContext.Books.Where(e => e.IsReserved == true && e.AuthorId == authorId).ToListAsync();
                }
                else
                {
                    return await _dbContext.Books.Where(e => e.LibraryId == libraryId && e.IsReserved == true && e.AuthorId == authorId).ToListAsync();
                }
            }
        }

        public async Task<IEnumerable<BookEntity>> GetAllWithAuthor(int authorId, int libraryId = 0)
        {
            var author = await _dbContext.Books.FindAsync(authorId);
            if (author == null)
            {
                throw new ArgumentException("author not found");
            }
            else
            {
                if (libraryId == 0)
                {
                    return await _dbContext.Books.Where(e => e.AuthorId == authorId).ToListAsync();
                }
                else
                {
                    return await _dbContext.Books.Where(e => e.LibraryId == libraryId && e.AuthorId == authorId).ToListAsync();
                }
            }
        }

        public async Task<BookEntity> GetById(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book == null)
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