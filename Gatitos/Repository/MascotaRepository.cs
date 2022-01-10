using System.Reflection.Metadata.Ecma335;
using Gatitos.Context;
using Gatitos.Models;

namespace Gatitos.Repository;

public class MascotaRepository : IMascotaRepository
{
    private readonly IGatitoContext _gatitoContext;


    public MascotaRepository(IGatitoContext gatitoContext)
    {
        _gatitoContext = gatitoContext;
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
        List<Mascota> mascotas = _gatitoContext.Mascotas.Select(m => m).ToList();
        foreach (var mascota in mascotas)
        {
            mascota.Vacunas = _gatitoContext.Vacunas.Select(v => v)
                .Where(m => m.MascotaId == mascota.MascotaId).ToList();
        }

        return mascotas;
    }

    public Mascota Find(int mascotaId)
    {
        Mascota? mascota = _gatitoContext.Mascotas.Find(mascotaId);
        if (mascota == null) return null;
        mascota.Vacunas = _gatitoContext.Vacunas.Select(v => v)
            .Where(m => m.MascotaId == mascota.MascotaId).ToList();
        return mascota;
    }

    public Mascota Update(Mascota mascota)
    {
        Mascota mascotaUpdate = _gatitoContext.Mascotas.Update(mascota).Entity;
        _gatitoContext.SaveChanges();
        return mascotaUpdate;
    }

    public Mascota UploadFile(int id, IFormFile? file)
    {
        Mascota mascota = Find(id);
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

    public void DeleteVacunaById(int vacunaId)
    {
        vacuna vacuna = FindVacuna(vacunaId);
        _gatitoContext.Vacunas.Remove(vacuna);
        _gatitoContext.SaveChanges();
    }

    public vacuna FindVacuna(int id)
    {
        return _gatitoContext.Vacunas.Find(id);
    }

    public vacuna Update(vacuna vacunaRequest)
    {
        vacuna vacunaUpdate = _gatitoContext.Vacunas.Update(vacunaRequest).Entity;
        _gatitoContext.SaveChanges();
        return vacunaUpdate;
    }

    public List<vacuna> ListVacunas()
    {
        return _gatitoContext.Vacunas.Select(v => v).ToList();
    }

    public Mascota? AddVacuna(List<vacuna> vacunas, int mascotaId)
    {
        Mascota mascota = Find(mascotaId);
        if (mascota == null) return null;
        foreach (var vacuna in vacunas)
        {
            mascota.Vacunas.Add(vacuna);
        }

        return Update(mascota);
    }
}