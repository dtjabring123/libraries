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
    }
}