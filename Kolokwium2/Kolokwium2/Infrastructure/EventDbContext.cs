using Kolokwium2.Model;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Infrastructure
{
    public class EventDbContext : DbContext
    {
        public EventDbContext()
        {
                
        }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
                
        }
        
        public virtual DbSet<Artist> Artists { get; set; }
        
        public virtual DbSet<ArtistEvent> ArtistEvents { get; set; }
        
        public virtual DbSet<Event> Events { get; set; }
        
        public virtual DbSet<EventOrganiser> EventOrganisers { get; set; }
        
        public virtual DbSet<Organiser> Organisers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().Property(x => x.Nickname).HasMaxLength(30);
            modelBuilder.Entity<Event>().Property(x => x.Name).HasMaxLength(100);
            modelBuilder.Entity<Organiser>().Property(x => x.Name).HasMaxLength(30);

            modelBuilder.Entity<ArtistEvent>().HasKey(x => new {x.Artist, x.Event});
            modelBuilder.Entity<EventOrganiser>().HasKey(x => new {x.Event, x.Organiser});
            modelBuilder.Entity<Artist>().HasKey(x => x.IdArtist);
            modelBuilder.Entity<Event>().HasKey(x => x.IdEvent);
            modelBuilder.Entity<Organiser>().HasKey(x => x.IdOrganiser);

            
            
        }
    }
}