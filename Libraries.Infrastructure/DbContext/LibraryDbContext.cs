using Libraries.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Libraries.Infrastructure.Persistence
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        internal DbSet<AuthorEntity> Authors { get; set; }

        internal DbSet<BookEntity> Books { get; set; }

        internal DbSet<LibraryEntity> Libraries { get; set; }

        internal DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorEntity>().HasQueryFilter(author => !author.IsDeleted);
            modelBuilder.Entity<LibraryEntity>().HasQueryFilter(book => !book.IsDeleted);
            modelBuilder.Entity<LibraryEntity>().HasQueryFilter(library => !library.IsDeleted);
            modelBuilder.Entity<UserEntity>().HasQueryFilter(user => !user.IsDeleted);
        }
    }
}