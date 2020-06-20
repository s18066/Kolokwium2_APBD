using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium2.Infrastructure;
using Kolokwium2.QueryModel;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Services
{
    public class ArtistQuery
    {
        private readonly EventDbContext _dbContext;

        public ArtistQuery(EventDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<ArtistQueryModel>> GetArtist(int artistId)
        {
            var artist = await _dbContext.Artists.SingleOrDefaultAsync(x => x.IdArtist == artistId);
            if (artist is null)
            {
                return Result<ArtistQueryModel>.NotFound<ArtistQueryModel>();
            }

            var events = await _dbContext.ArtistEvents
                .Where(x => x.Artist == artist)
                .Select(x => x.Event)
                .OrderByDescending(x => x.StartDate)
                .ToListAsync();

            var result = new ArtistQueryModel()
            {
                Id = artistId,
                Nickname = artist.Nickname,
                Events = events.Select(x => new EventQueryModel()
                {
                    Id = x.IdEvent,
                    Name = x.Name,
                    EndDate = x.EndDate,
                    StartDate = x.StartDate
                })
            };
            
            return Result<ArtistQueryModel>.Found(result);
        }
    }

    public class Result<T> where T: class
    {
        private Result(T result, bool found)
        {
            Value = result;
            IsFound = found;
        }
        
        public T Value { get; }
        
        public bool IsFound { get; }
        
        public static Result<TIn> Found<TIn>(TIn value) where TIn : class => new Result<TIn>(value, false);
        
        public static Result<TIn> NotFound<TIn>() where TIn : class => new Result<TIn>(null, false);
    }
}