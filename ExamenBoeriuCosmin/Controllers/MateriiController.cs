using ExamenBoeriuCosmin.DTOs;
using ExamenBoeriuCosmin.Entities;
using Microsoft.AspNetCore.Mvc;
using ExamenBoeriuCosmin.Repositories;
namespace ExamenBoeriuCosmin.Controllers;

[ApiController]
[Route("api/[controller]")] // api/materii
public class MateriiController : ControllerBase
{
    private readonly MateriiRepository _materiiRepository;
    public MateriiController(MateriiRepository matRepository)
    {
        _materiiRepository = matRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Materie>>> GetMaterii()
    {
        return await _materiiRepository.GetMaterii();
    }

    [HttpPost("add")]
    public async Task<ActionResult<Materie>> CreateMaterie(MaterieDto materieDto)
    {
        var materie = await _materiiRepository.CreateMaterie(materieDto);
        if (materie.Result == null)
            BadRequest("Tip invalid");
        return materie;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Materie>>DeletMaterie(int id)
    {
        return await _materiiRepository.DeleteMaterie(id);
    }
}