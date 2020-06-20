using System;
using System.Threading.Tasks;
using Kolokwium2.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Services
{
    public class ArtistUpdateService
    {
        private readonly EventDbContext _dbContext;

        public ArtistUpdateService(EventDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Status> UpdatePerformanceDate(int artistId, int eventId, DateTime newPerformanceDate)
        {
            var @event = await _dbContext.Events.SingleOrDefaultAsync(x => x.IdEvent == eventId);

            if (@event is null)
            {
                return Status.NotFound;
            }
            if (@event.StartDate < DateTime.UtcNow)
            {
                return Status.BadRequest;
            }

            if (@event.StartDate > newPerformanceDate || @event.EndDate < newPerformanceDate)
            {
                return Status.BadRequest;
            }

            var artistEvent =
                await _dbContext.ArtistEvents.SingleOrDefaultAsync(x =>
                    x.Artist.IdArtist == artistId && x.Event.IdEvent == eventId);
            if (artistEvent is null)
            {
                return Status.NotFound;
            }

            artistEvent.PerformanceDate = newPerformanceDate;

            await _dbContext.SaveChangesAsync();
            return Status.NoContent;
        }

        public enum Status
        {
            NoContent,
            NotFound,
            BadRequest
        }
    }
}