using System.ComponentModel.DataAnnotations;

namespace ExamenBoeriuCosmin.DTOs;

public class ProfesorDto
{
    [Required]
    public string Nume { get; set; }
    
    [Required]
    public string Prenume { get; set; }
    
    [Required]
    public string Tip { get; set; }
}