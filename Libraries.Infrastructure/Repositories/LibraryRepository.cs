using Libraries.Application.Interfaces;

using Libraries.Domain.Entities;
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

        public async Task<List<LibraryEntity>> GetAll()
        {
            return await _dbContext.Libraries.ToListAsync();
        }

        public async Task<LibraryEntity> Add(LibraryEntity library)
        {
            await _dbContext.AddAsync(library);
            await _dbContext.SaveChangesAsync();
            return library;
        }

        public async Task<LibraryEntity> Delete(int id)
        {
            var library = await _dbContext.Libraries.FirstOrDefaultAsync(_ => _.Id == id);
            if (library != null)
            {
                library.IsDeleted = true;
                _dbContext.Update(library);
                await _dbContext.SaveChangesAsync();
                return library;
            }
            else
            {
                return null;
            }
        }

        public async Task<LibraryEntity> GetById(int id)
        {
            var library = await _dbContext.Libraries.FirstOrDefaultAsync(_ => _.Id == id);
            if (library != null && !library.IsDeleted)
            {
                return library;
            }
            else
            {
                return null;
            }
        }
    }
}