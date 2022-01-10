using Gatitos.Models;

namespace Gatitos.Repository;

public interface IPersonaRepository
{
    Persona AddPersona(Persona persona);
    void DeletePerson(Persona persona);
    void DeletePersonById(int personaId);
    List<Persona> ListPersonas();
    Persona Find(int personaId);
    Persona Update(Persona persona);
    Persona UploadFile(int id, IFormFile? file);
    byte[]? GetAvatar(int personaId);
}