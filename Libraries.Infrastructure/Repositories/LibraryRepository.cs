using Libraries.Domain.Entities;
using Libraries.Domain.Interfaces;
using Libraries.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Libraries.Infrastructure.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly LibraryDbContext _dbContext;

        public LibraryRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LibraryEntity> Add(LibraryEntity library)
        {
            await _dbContext.Libraries.AddAsync(library);
            await _dbContext.SaveChangesAsync();
            return library;
        }

        public async Task<LibraryEntity> Delete(int id)
        {
            var library = await _dbContext.Libraries.FindAsync(id);
            if (library != null)
            {
                library.IsDeleted = true;
                _dbContext.Libraries.Update(library);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("library not found");
            }
            return library;
        }

        public async Task<IEnumerable<LibraryEntity>> GetAll()
        {
            return await _dbContext.Libraries.ToListAsync();
        }

        public async Task<LibraryEntity> GetById(int id)
        {
            var library = await _dbContext.Libraries.FindAsync(id);
            if (library == null)
            {
                throw new ArgumentException("library not found");
            }
            return library;
        }

        public async Task<LibraryEntity> Update(LibraryEntity library)
        {
            _dbContext.Libraries.Update(library);
            await _dbContext.SaveChangesAsync();
            return library;
        }
    }
}