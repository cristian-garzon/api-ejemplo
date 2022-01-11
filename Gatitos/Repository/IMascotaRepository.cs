using Gatitos.Models;

namespace Gatitos.Repository;

public interface IMascotaRepository
{
    void DeleteMascota(Mascota mascota);
    void DeleteMascotaById(int mascotaId);
    List<Mascota> ListMascotas();
    Mascota Find(int mascotaId);
    Mascota Update(Mascota mascota);
    Mascota UploadFile(int id, IFormFile? file);
    byte[]? GetFoto(int mascotaId);
    void DeleteVacunaById(int VacunaId);
    public vacuna FindVacuna(int id);
    public vacuna Update(vacuna vacuna);
    public List<vacuna> ListVacunas();
    public Mascota? AddVacuna(List<vacuna> vacunas, int mascotaId);
    public Mascota? AddAlbum(Album album, int id);
}