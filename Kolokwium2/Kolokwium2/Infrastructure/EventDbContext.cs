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

            modelBuilder.Entity<Artist>().HasMany(x => x.ArtistEvents).WithOne(x => x.Artist);
            modelBuilder.Entity<Event>().HasMany(x => x.ArtistEvents).WithOne(x => x.Event);
            modelBuilder.Entity<Event>().HasMany(x => x.EventOrganisers).WithOne(x => x.Event);
            modelBuilder.Entity<Organiser>().HasMany(x => x.EventOrganisers).WithOne(x => x.Organiser);

            modelBuilder.Entity<ArtistEvent>().HasKey(x => new {x.ArtistId, x.EventId});
            modelBuilder.Entity<EventOrganiser>().HasKey(x => new {x.EventId, x.OrganiserId});
            modelBuilder.Entity<Artist>().HasKey(x => x.IdArtist);
            modelBuilder.Entity<Event>().HasKey(x => x.IdEvent);
            modelBuilder.Entity<Organiser>().HasKey(x => x.IdOrganiser);

            
            
        }
    }
}