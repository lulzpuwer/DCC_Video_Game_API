using ASP_NET_Video_Games_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Video_Games_API.Controllers
{
    // api/games
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllGames()
        {
            var VideoGames = _context.VideoGames.Select(vg => vg).Distinct();

            return Ok(VideoGames);
        }

        [HttpGet("{id}")]
        public IActionResult GetGamesById(int id)
        {
            var VideoGames = _context.VideoGames.Where(vg => vg.Id == id);
            return Ok(VideoGames);
        }
    }
}
