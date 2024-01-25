using System.ComponentModel.DataAnnotations;
using ExamenBoeriuCosmin.Entities;


namespace ExamenBoeriuCosmin.DTOs;

public class MaterieDto
{

    [Required]
    public int Id { get; set; }
    
    [Required]
    public string nume { get; set; }
}
