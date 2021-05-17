using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Repositories;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController:ControllerBase
    {
        private readonly AppDbContext _context;

        public PerfilController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
       
        public async Task<ActionResult<IEnumerable<Perfil>>> GetPerfis()
        {
            return await _context.Perfis.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Perfil>> GetPerfis(int id)
        {
            var perfil = await _context.Perfis.FindAsync(id);

            if (perfil == null) return NotFound();

            return perfil;

        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> PutPerfil(int id, Perfil perfil)
        {
            if (id != perfil.Id) return BadRequest();

            _context.Entry(perfil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!perfilExists(id))
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

        [HttpPost]
        //[Authorize(Roles = "employee,manager")]
        public async Task<ActionResult<Perfil>> PostFuncioanrio(Perfil perfil)
        {
            _context.Perfis.Add(perfil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerfil", new { id = perfil.Id }, perfil); ;
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "manager")]
        public async Task<IActionResult> DeletePerfil(int id)
        {
            var perfil = await _context.Perfis.FindAsync(id);
            if (perfil == null) return NotFound();

            _context.Perfis.Remove(perfil);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool perfilExists(int id)
        {
            return _context.Perfis.Any(e => e.Id == id);
        }
    }
}
