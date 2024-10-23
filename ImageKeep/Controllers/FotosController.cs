using ImageKeep.Data.DataContext;
using ImageKeep.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImageKeep.Controllers
{
    

[Route("api/[controller]")]
[ApiController]
public class FotosController : ControllerBase
{
    private readonly DataContext _context;

    public FotosController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Foto>>> GetFotos()
    {
        return await _context.Fotos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Foto>> GetFoto(int id)
    {
        var foto = await _context.Fotos.FindAsync(id);

        if (foto == null)
        {
            return NotFound();
        }

        return foto;
    }

    [HttpPost]
    public async Task<ActionResult<Foto>> PostFoto(Foto foto)
    {
        _context.Fotos.Add(foto);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetFoto), new { id = foto.Id }, foto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutFoto(int id, Foto foto)
    {
        if (id != foto.Id)
        {
            return BadRequest();
        }

        _context.Entry(foto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Fotos.Any(e => e.Id == id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFoto(int id)
    {
        var foto = await _context.Fotos.FindAsync(id);
        if (foto == null)
        {
            return NotFound();
        }

        _context.Fotos.Remove(foto);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

}