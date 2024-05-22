using Libraries.Domain.Entities;

namespace Libraries.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserEntity> Add(UserEntity user);

        public Task<UserEntity> Delete(int id);

        public Task<UserEntity> Update(UserEntity user);
    }
}