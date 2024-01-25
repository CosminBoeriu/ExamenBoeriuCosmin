using ExamenBoeriuCosmin.DTOs;
using ExamenBoeriuCosmin.Entities;
using Microsoft.AspNetCore.Mvc;
using ExamenBoeriuCosmin.Repositories;
namespace ExamenBoeriuCosmin.Controllers;

[ApiController]
[Route("api/[controller]")] // api/students
public class ProfesoriController : ControllerBase
{
    private readonly ProfesoriRepository _profesorRepository;
    public ProfesoriController(ProfesoriRepository profesoriRepository)
    {
        _profesorRepository = profesoriRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Profesor>>> GetProfesori()
    {
        return await _profesorRepository.GetProfesori();
    }

    [HttpPost("add")]
    public async Task<ActionResult<Profesor>> CreateProfesor(ProfesorDto profesorDto)
    {
        var prof = await _profesorRepository.CreateProfesor(profesorDto);
        if (prof.Result == null)
            BadRequest("Tip invalid");
        return prof;
    }

    [HttpPut("addMaterie/{id}")]
    public void UpdateMaterii(int id, MaterieDto materieDto)
    {
        _profesorRepository.UpdateMaterii(id, materieDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Profesor>>DeletProfesor(int id)
    {
        return await _profesorRepository.DeleteProfesor(id);
    }
}