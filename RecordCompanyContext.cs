using Microsoft.EntityFrameworkCore;

namespace RhythmsGonnaGetYou
{
    public class RecordCompanyContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Position> Positions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=RecordCompany");
        }
    }
}
