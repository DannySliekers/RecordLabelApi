using Microsoft.EntityFrameworkCore;
using RecordLabelApi.Models;
using Single = RecordLabelApi.Models.Single;

namespace RecordLabelApi.Context
{
    public class RecordLabelContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Single> Singles { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        
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
