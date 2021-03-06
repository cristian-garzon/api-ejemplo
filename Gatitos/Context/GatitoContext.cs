using Gatitos.Models;
using Microsoft.EntityFrameworkCore;

namespace Gatitos.Context;

public class GatitoContext : DbContext, IGatitoContext
{
    public GatitoContext(DbContextOptions<GatitoContext> options) : base(options)
    {
    } 
    
    //tables
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Mascota> Mascotas { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<vacuna> Vacunas { get; set; }
    public DbSet<Galeria> Galerias { get; set; }
    
}