using Libraries.Domain.Entities;

namespace Libraries.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserEntity> Add(UserEntity user);

        public Task<UserEntity> AddToLibrary(int userId, int libraryId);

        public Task<UserEntity> Delete(int id);

        public Task<UserEntity> RemoveFromLibrary(int id);

        public Task<UserEntity> Update(UserEntity user);
    }
}