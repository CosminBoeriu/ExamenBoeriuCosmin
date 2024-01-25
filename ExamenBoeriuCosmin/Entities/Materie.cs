namespace ExamenBoeriuCosmin.Entities;

public class Materie
{
    public int id { get; set; }
    
    public string nume { get; set; }
    
    public ICollection<Profesor> Profesori { get; set; }
}