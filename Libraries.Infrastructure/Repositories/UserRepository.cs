using Libraries.Domain.Entities;
using Libraries.Domain.Interfaces;
using Libraries.Infrastructure.Persistence;

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
                var library = await _dbContext.Libraries.FindAsync(libraryId);
                if (library != null)
                {
                    user.LibraryId = libraryId;
                    _dbContext.Users.Update(user);
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
                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();
            }
            else
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
                _dbContext.Users.Update(user);
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
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}