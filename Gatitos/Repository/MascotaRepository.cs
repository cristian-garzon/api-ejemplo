using Gatitos.Context;
using Gatitos.Models;
using Microsoft.EntityFrameworkCore;

namespace Gatitos.Repository;

public class MascotaRepository : IMascotaRepository
{

    private readonly IGatitoContext _gatitoContext;


    public MascotaRepository(IGatitoContext gatitoContext)
    {
        _gatitoContext = gatitoContext;
    }

    public Mascota AddMascota(Mascota mascota)
    {
        Persona persona = _gatitoContext.Personas.Find(mascota.PersonaId);
        if (persona == null) return null;
        mascota.Persona = persona;
        Mascota mascotaCreated = _gatitoContext.Mascotas.Add(mascota).Entity; 
        _gatitoContext.SaveChanges();
        return mascotaCreated;
    }

    public void DeleteMascota(Mascota mascota)
    {
        _gatitoContext.Mascotas.Remove(mascota);
        _gatitoContext.SaveChanges();
    }

    public void DeleteMascotaById(int mascotaId)
    {
        Mascota mascota = Find(mascotaId);
        _gatitoContext.Mascotas.Remove(mascota);
        _gatitoContext.SaveChanges();
    }

    public List<Mascota> ListMascotas()
    {
        return _gatitoContext.Mascotas.Select(m => m).ToList();
    }

    public Mascota Find(int mascotaId)
    {
        return _gatitoContext.Mascotas.Find(mascotaId);
    }

    public Mascota Update(Mascota mascota)
    {
        Mascota mascotaUpdate = _gatitoContext.Mascotas.Update(mascota).Entity; 
        _gatitoContext.SaveChanges();
        return mascotaUpdate;
    }

    public Mascota UploadFile(int id, IFormFile? file)
    {
        Mascota mascota =  Find(id);
        using (var target = new MemoryStream())
        {
            file.CopyTo(target);
            mascota.Foto = target.ToArray();
        }
        return Update(mascota);
    }

    public byte[]? GetFoto(int mascotaId)
    {
        Mascota mascota = Find(mascotaId);
        if (mascota == null) return null;
        return mascota.Foto;
    }
}