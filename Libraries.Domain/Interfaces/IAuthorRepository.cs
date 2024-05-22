using Libraries.Domain.Entities;

namespace Libraries.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        public Task<AuthorEntity> Add(AuthorEntity entity);

        public Task<AuthorEntity> Delete(AuthorEntity entity);

        public Task<AuthorEntity> Update(AuthorEntity entity);
    }
}