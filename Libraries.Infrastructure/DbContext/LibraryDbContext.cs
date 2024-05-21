using Libraries.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Libraries.Infrastructure.Persistence
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibraryEntity>().HasQueryFilter(library => !library.IsDeleted);
        }

        internal DbSet<LibraryEntity> Libraries { get; set; }
    }
}