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
    
}