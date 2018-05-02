using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Note.Model;

namespace Note.DAL
{
     class NoteDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public NoteDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Notice> Notices { get; set; } // 되도록 복수형으로
        public DbSet<User> Users { get; set; }
        public DbSet<Board> Boards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DevDb"));
          // optionsBuilder.UseSqlServer("Server=(local);Database=NoteDb;User Id=ksg;Password=ksg1234;"); 
        }
    }
}
