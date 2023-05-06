using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multi_Tracks_API.Models;

namespace Multi_Tracks_API.Controllers
{
    [Route("api.multitracks.com/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly MultiTracksDBContext _context;

        public SongsController(MultiTracksDBContext context)
        {
            _context = context;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs([FromQuery] PaginationParams @params)
        {
          if (_context.Songs == null)
          {
              return NotFound();
          }
            return await _context.Songs.Skip((@params.Page-1) * @params.ItemsPerPage).Take(@params.ItemsPerPage).ToListAsync();
        }

    }
}
