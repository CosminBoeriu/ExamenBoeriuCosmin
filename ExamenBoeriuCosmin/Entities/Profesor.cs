using ExamenBoeriuCosmin.Entities;

namespace ExamenBoeriuCosmin.Entities;

public class Profesor
{
    public int id { get; set; }
    public string nume { get; set; }
    public string prenume { get; set; }
    public string tip { get; set; }

    public ICollection<Materie> Materii { get; set; }
}