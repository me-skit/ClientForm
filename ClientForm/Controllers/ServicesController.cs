using ClientForm.Data;
using ClientForm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ClientForm.Controllers
{
    [Route("controlador")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET controlador/{id}
        [HttpGet("detalles/{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }


        // POST controlador/crear
        [HttpPost("crear")]
        public async Task<IActionResult> Create(Client client)
        {
            client.CreationDate = DateTime.Now;
            _context.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtRoute(nameof(GetById), new { client.Id }, client);
        }

        // DELETE controlador/eliminar/{id}
        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
