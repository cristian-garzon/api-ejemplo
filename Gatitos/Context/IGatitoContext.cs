using Gatitos.Models;
using Microsoft.EntityFrameworkCore;

namespace Gatitos.Context;

public interface IGatitoContext
{
    
    DbSet<Persona> Personas { get; set; }
    public DbSet<Mascota> Mascotas { get; set; }
    
    int SaveChanges();
    
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

}