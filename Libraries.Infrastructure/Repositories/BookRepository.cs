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
                book.Author = author;
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
                if (await _dbContext.Users.AnyAsync(u => u.Id == userId))
                {
                    book.UserId = userId;
                    book.IsCheckedOut = true;
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
                if (await _dbContext.Users.AnyAsync(u => u.Id == userId))
                {
                    book.UserId = userId;
                    book.IsReserved = true;
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
                if (await _dbContext.Libraries.AnyAsync(l => l.Id == libraryId))
                {
                    book.LibraryId = libraryId;
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
                return await _dbContext.Books.AsNoTracking().ToListAsync();
            }
            else
            {
                return await _dbContext.Books.AsNoTracking().Where(e => e.LibraryId == libraryId).ToListAsync();
            }
        }

        public async Task<IEnumerable<BookEntity>> GetAllCheckedOut(int libraryId = 0)
        {
            if (libraryId == 0)
            {
                return await _dbContext.Books.AsNoTracking().Where(e => e.IsCheckedOut == true).ToListAsync();
            }
            else
            {
                return await _dbContext.Books.AsNoTracking().Where(e => e.LibraryId == libraryId && e.IsCheckedOut == true).ToListAsync();
            }
        }

        public async Task<IEnumerable<BookEntity>> GetAllCheckedOutForUser(int userId)
        {
            if (!await _dbContext.Users.AnyAsync(u => u.Id == userId))
            {
                throw new ArgumentException("user not found");
            }
            return (IEnumerable<BookEntity>)await _dbContext.Users.AsNoTracking().Where(u => u.Id == userId).Include(e => e.Books.Where(b => b.IsCheckedOut)).ToListAsync();
        }

        public async Task<IEnumerable<BookEntity>> GetAllCheckedOutWithAuthor(int authorId, int libraryId = 0)
        {
            if (await _dbContext.Authors.AnyAsync(a => a.Id == authorId))
            {
                if (libraryId == 0)
                {
                    return await _dbContext.Books.AsNoTracking().Where(e => e.IsCheckedOut == true && e.AuthorId == authorId).ToListAsync();
                }
                else
                {
                    return await _dbContext.Books.AsNoTracking().Where(e => e.LibraryId == libraryId && e.IsCheckedOut == true && e.AuthorId == authorId).ToListAsync();
                }
            }
            else
            {
                throw new ArgumentException("author not found");
            }
        }

        public async Task<IEnumerable<BookEntity>> GetAllReserved(int libraryId = 0)
        {
            if (libraryId == 0)
            {
                return await _dbContext.Books.AsNoTracking().Where(e => e.IsReserved == true).ToListAsync();
            }
            else
            {
                return await _dbContext.Books.AsNoTracking().Where(e => e.LibraryId == libraryId && e.IsReserved == true).ToListAsync();
            }
        }

        public async Task<IEnumerable<BookEntity>> GetAllReservedForUser(int userId)
        {
            if (!await _dbContext.Users.AnyAsync(u => u.Id == userId))
            {
                throw new ArgumentException("user not found");
            }
            return (IEnumerable<BookEntity>)await _dbContext.Users.AsNoTracking().Where(u => u.Id == userId).Include(e => e.Books.Where(b => b.IsReserved)).ToListAsync();
        }

        public async Task<IEnumerable<BookEntity>> GetAllReservedWithAuthor(int authorId, int libraryId = 0)
        {
            if (await _dbContext.Authors.AnyAsync(a => a.Id == authorId))
            {
                if (libraryId == 0)
                {
                    return await _dbContext.Books.AsNoTracking().Where(e => e.IsReserved == true && e.AuthorId == authorId).ToListAsync();
                }
                else
                {
                    return await _dbContext.Books.AsNoTracking().Where(e => e.LibraryId == libraryId && e.IsReserved == true && e.AuthorId == authorId).ToListAsync();
                }
            }
            else
            {
                throw new ArgumentException("author not found");
            }
        }

        public async Task<IEnumerable<BookEntity>> GetAllWithAuthor(int authorId, int libraryId = 0)
        {
            if (await _dbContext.Authors.AnyAsync(a => a.Id == authorId))
            {
                if (libraryId == 0)
                {
                    return await _dbContext.Books.AsNoTracking().Where(e => e.AuthorId == authorId).ToListAsync();
                }
                else
                {
                    return await _dbContext.Books.AsNoTracking().Where(e => e.LibraryId == libraryId && e.AuthorId == authorId).ToListAsync();
                }
            }
            else
            {
                throw new ArgumentException("author not found");
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
            if (await _dbContext.Books.AnyAsync(b => b.Id == book.Id))
            {
                if (await _dbContext.Authors.AnyAsync(a => a.Id == book.AuthorId))
                {
                    _dbContext.Books.Update(book);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException("author not found");
                }
            }
            else
            {
                throw new ArgumentException("book not found");
            }
            return book;
        }
    }
}