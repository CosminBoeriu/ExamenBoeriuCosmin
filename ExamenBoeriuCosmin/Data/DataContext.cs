using ExamenBoeriuCosmin.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamenBoeriuCosmin.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Profesor> Profesori { get; set; }
    
    public DbSet<Materie> Materii { get; set; }
}