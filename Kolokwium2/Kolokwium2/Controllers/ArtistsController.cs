using System.Threading.Tasks;
using Kolokwium2.QueryModel;
using Kolokwium2.RequestModel;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers
{
    [ApiController]
    [Route("api/artists")]
    public class ArtistsController : ControllerBase
    {
        private readonly ArtistQuery _artistQuery;
        private readonly ArtistUpdateService _updateService;

        public ArtistsController(ArtistQuery artistQuery, ArtistUpdateService updateService)
        {
            _artistQuery = artistQuery;
            _updateService = updateService;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistQueryModel>> Get(int id)
        {
            var result = await _artistQuery.GetArtist(id);

            if (result.IsFound)
                return result.Value;

            return NotFound();
        }

        [HttpPut("{artistId}/events/{eventId}")]
        public async Task<ActionResult> UpdateEventPerformanceDate(int artistId, int eventId, [FromBody] ChangePerformanceDate body)
        {
            var result = await _updateService.UpdatePerformanceDate(artistId, eventId, body.PerformanceDate);

            return result switch
            {
                ArtistUpdateService.Status.NotFound => NotFound(),
                ArtistUpdateService.Status.BadRequest => BadRequest(),
                _ => NoContent()
            };
        }
        
    }
}