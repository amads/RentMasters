using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentMasters.Models;
using RentMasters.Models.Database;

namespace RentMasters.Controllers
{
    [Produces("application/json")]
    [Route("api/Properties")]
    public class PropertiesController : Controller
    {
        private readonly DatabaseContext _context;

        public PropertiesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Properties
        [HttpGet]
        [Route("get")]
        public IEnumerable<Property> GetProperties()
        {
            return _context.Properties;
        }

        // GET: api/Properties/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProperty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @property = await _context.Properties.SingleOrDefaultAsync(m => m.Id == id);

            if (@property == null)
            {
                return NotFound();
            }

            return Ok(@property);
        }

        // PUT: api/Properties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProperty([FromRoute] int id, [FromBody] Property @property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @property.Id)
            {
                return BadRequest();
            }

            _context.Entry(@property).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Properties
        [HttpPost]
        public async Task<IActionResult> PostProperty([FromBody] Property @property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Properties.Add(@property);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProperty", new { id = @property.Id }, @property);
        }

        // DELETE: api/Properties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @property = await _context.Properties.SingleOrDefaultAsync(m => m.Id == id);
            if (@property == null)
            {
                return NotFound();
            }

            _context.Properties.Remove(@property);
            await _context.SaveChangesAsync();

            return Ok(@property);
        }

        private bool PropertyExists(int id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}