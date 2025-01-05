using Microsoft.EntityFrameworkCore;
using RecordLabelApi.Models;
using Single = RecordLabelApi.Models.Single;

namespace RecordLabelApi.Context
{
    public class RecordLabelContext : DbContext
    {
        public DbSet<Album> Album { get; set; }
        public DbSet<Single> Single { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Platform> Platform { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<SinglePlatform> SinglePlatform { get; set; }


        private readonly string _connectionString;

        public RecordLabelContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DB") ?? throw new NullReferenceException("Connection String");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define composite primary key for the SinglePlatform table
            modelBuilder.Entity<SinglePlatform>()
                .HasKey(sp => new { sp.singleid, sp.platformid });
        }
    }
}
