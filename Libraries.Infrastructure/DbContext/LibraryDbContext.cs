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

        internal DbSet<LibraryEntity> Libraries { get; set; }
    }
}