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
    public class ArtistsController : ControllerBase
    {
        private readonly MultiTracksDBContext _context;

        public ArtistsController(MultiTracksDBContext context)
        {
            _context = context;
        }



        // GET: api/Artists/5
        [HttpGet("{title}")]
        public async Task<ActionResult<Artist>> GetArtist(string title)
        {
          if (_context.Artists == null)
          {
              return NotFound();
          }
            var artist = await _context.Artists.FirstOrDefaultAsync(n => n.title == title);

            if (artist == null)
            {
                return NotFound();
            }

            return artist;
        }

       

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist artist)
        {
            if (_context.Artists == null)
              {
                  return Problem("Entity set 'MultiTracksDBContext.Artists'  is null.");
              }
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            return CreatedAtAction("PostArtist", new { id = artist.artistID }, artist);
        }

        

    }
}
