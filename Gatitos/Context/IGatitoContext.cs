using Gatitos.Models;
using Microsoft.EntityFrameworkCore;

namespace Gatitos.Context;

public interface IGatitoContext
{
    
    DbSet<Persona> Personas { get; set; }
    public DbSet<Mascota> Mascotas { get; set; }
    public DbSet<vacuna> Vacunas { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Galeria> Galerias { get; set; }
    
    int SaveChanges();
    
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

}