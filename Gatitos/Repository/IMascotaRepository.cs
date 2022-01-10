using Gatitos.Models;

namespace Gatitos.Repository;

public interface IMascotaRepository
{
    Mascota AddMascota(Mascota mascota);
    void DeleteMascota(Mascota mascota);
    void DeleteMascotaById(int mascotaId);
    List<Mascota> ListMascotas();
    Mascota Find(int mascotaId);
    Mascota Update(Mascota mascota);
    Mascota UploadFile(int id, IFormFile? file);
    byte[]? GetFoto(int mascotaId);
}