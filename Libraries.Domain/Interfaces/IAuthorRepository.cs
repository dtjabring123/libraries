using Libraries.Domain.Entities;

namespace Libraries.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        public Task<AuthorEntity> Add(AuthorEntity entity);

        public Task<AuthorEntity> Delete(int id);

        public Task<AuthorEntity> Update(AuthorEntity entity);
    }
}