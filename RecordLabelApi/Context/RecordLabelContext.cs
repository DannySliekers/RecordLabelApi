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
        
        private readonly string _connectionString;

        public RecordLabelContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DB") ?? throw new NullReferenceException("Connection String");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}
