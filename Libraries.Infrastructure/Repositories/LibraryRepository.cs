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

        public async Task<List<Library>> GetAll()
        {
            var libraries = await _dbContext.Libraries.ToListAsync();
            return libraries;
        }

        public async Task Add(Library library)
        {
            await _dbContext.AddAsync(library);
            await _dbContext.SaveChangesAsync();
        }
    }
}