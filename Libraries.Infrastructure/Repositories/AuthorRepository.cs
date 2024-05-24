using Libraries.Domain.Entities;
using Libraries.Domain.Interfaces;
using Libraries.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Libraries.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _dbContext;

        public AuthorRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AuthorEntity> Add(AuthorEntity author)
        {
            await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync();
            return author;
        }

        public async Task<AuthorEntity> Delete(int id)
        {
            var author = await _dbContext.Authors.FindAsync(id);
            if (author != null)
            {
                author.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("author not found");
            }
            return author;
        }

        public async Task<IEnumerable<AuthorEntity>> GetAll()
        {
            return await _dbContext.Authors.AsNoTracking().ToListAsync();
        }

        public async Task<AuthorEntity> GetById(int id)
        {
            var author = await _dbContext.Authors.FindAsync(id);
            if (author == null)
            {
                throw new ArgumentException("author not found");
            }
            return author;
        }

        public async Task<AuthorEntity> Update(AuthorEntity author)
        {
            if (await _dbContext.Authors.AnyAsync(a => a.Id == author.Id))
            {
                _dbContext.Authors.Update(author);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("author not found");
            }

            return author;
        }
    }
}