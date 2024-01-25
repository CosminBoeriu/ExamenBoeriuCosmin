using ExamenBoeriuCosmin.Data;
using ExamenBoeriuCosmin.DTOs;
using Microsoft.EntityFrameworkCore;
using ExamenBoeriuCosmin.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ExamenBoeriuCosmin.Repositories;

public class MateriiRepository
{
    private readonly DataContext _context;

    public MateriiRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<ActionResult<IEnumerable<Materie>>> GetMaterii()
    {
        var materii = await _context.Materii.ToListAsync();
        await _context.SaveChangesAsync();
        return materii;
    }
    
    public async Task<ActionResult<Materie>> CreateMaterie(MaterieDto MaterieDto)
    {
        
        var mat = new Materie()
        {
            nume = MaterieDto.nume,
            Profesori = new List<Profesor>(),
        };
        _context.Materii.Add(mat);
        await _context.SaveChangesAsync();
        return mat;
    }

    public async Task<ActionResult<Materie>> DeleteMaterie(int id)
    {
        var mat = await _context.Materii.FindAsync(id);
        _context.Remove(id);
        await _context.SaveChangesAsync();
        return mat;
    }
}