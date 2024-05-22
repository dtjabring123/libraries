using Libraries.Domain.Entities;
using Libraries.Domain.Interfaces;
using Libraries.Infrastructure.Persistence;

namespace Libraries.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryDbContext _dbContext;

        public async Task<UserEntity> Add(UserEntity user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        async Task<UserEntity> IUserRepository.Delete(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();
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