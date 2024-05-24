using Libraries.Domain.Entities;
using Libraries.Domain.Interfaces;
using Libraries.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Libraries.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryDbContext _dbContext;

        public UserRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserEntity> Add(UserEntity user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserEntity> AddToLibrary(int userId, int libraryId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user != null)
            {
                var library = await _dbContext.Libraries.AnyAsync(l => l.Id == libraryId);
                if (library)
                {
                    user.LibraryId = libraryId;
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException("library not found");
                }
            }
            else
            {
                throw new ArgumentException("user not found");
            }
            return user;
        }

        public async Task<UserEntity> Delete(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("user not found");
            }
            return user;
        }

        public async Task<IEnumerable<UserEntity>> GetAll(int libraryId = 0)
        {
            if (libraryId == 0)
            {
                return await _dbContext.Users.ToListAsync();
            }
            else
            {
                return await _dbContext.Users.AsNoTracking().Where(e => e.LibraryId == libraryId).ToListAsync();
            }
        }

        public async Task<UserEntity> GetById(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                throw new ArgumentException("user not found");
            }
            return user;
        }

        public async Task<UserEntity> RemoveFromLibrary(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user != null)
            {
                user.LibraryId = null;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("user not found");
            }
            return user;
        }

        public async Task<UserEntity> Update(UserEntity user)
        {
            if (await _dbContext.Users.AnyAsync(u => u.Id == user.Id))
            {
                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("user not found");
            }

            return user;
        }
    }
}