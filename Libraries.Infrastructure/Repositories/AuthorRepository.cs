﻿using Libraries.Domain.Entities;
using Libraries.Domain.Interfaces;
using Libraries.Infrastructure.Persistence;

namespace Libraries.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _dbContext;

        public AuthorRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AuthorEntity> Add(AuthorEntity author)
        {
            await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync();
            return author;
        }

        public async Task<AuthorEntity> Delete(int id)
        {
            var author = await _dbContext.Authors.FindAsync(id);
            if (author != null)
            {
                author.IsDeleted = true;
                _dbContext.Authors.Update(author);
                await _dbContext.SaveChangesAsync();
            }
            return author;
        }

        public async Task<AuthorEntity> Update(AuthorEntity author)
        {
            _dbContext.Authors.Update(author);
            await _dbContext.SaveChangesAsync();
            return author;
        }
    }
}