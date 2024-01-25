using ExamenBoeriuCosmin.Data;
using ExamenBoeriuCosmin.DTOs;
using Microsoft.EntityFrameworkCore;
using ExamenBoeriuCosmin.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ExamenBoeriuCosmin.Repositories;

public class ProfesoriRepository
{
    private readonly DataContext _context;

    public ProfesoriRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<ActionResult<IEnumerable<Profesor>>> GetProfesori()
    {
        var profesori = await _context.Profesori.ToListAsync();
        await _context.SaveChangesAsync();
        return profesori;
    }
    
    public async Task<ActionResult<Profesor>> CreateProfesor(ProfesorDto profesorDto)
    {
        if (profesorDto.Tip != "standard" && profesorDto.Tip != "laborant")
            return null;
        var prof = new Profesor()
        {
            nume = profesorDto.Nume,
            prenume = profesorDto.Prenume,
            tip = profesorDto.Tip,
            Materii = new List<Materie>()
        };
        _context.Profesori.Add(prof);
        await _context.SaveChangesAsync();
        return prof;
    }

    public async Task<ActionResult<Profesor>> DeleteProfesor(int id)
    {
        var prof = await _context.Profesori.FindAsync(id);
        if (prof != null)
        {
            _context.Remove(prof);
            await _context.SaveChangesAsync();
            return prof;
        }

        return null;
    }
    
    public async void UpdateMaterii(int id, MaterieDto materieDto)
    {
        Materie materie = await _context.Materii.FindAsync(materieDto.Id);
        if(materie == null)
            return;
        Profesor prof = await _context.Profesori.FindAsync(id);
        if (prof == null)
            return;
        _context.Profesori.Remove(prof);
        await _context.SaveChangesAsync();
        if (prof.Materii == null)
            prof.Materii = new List<Materie>();
        prof.Materii.Add(materie);
        _context.Profesori.Add(prof);
        await _context.SaveChangesAsync();

    }
}