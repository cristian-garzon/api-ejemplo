using Gatitos.Models;

namespace Gatitos.Services;

public interface IGatitoService
{
    void AddPersona(Persona persona);
    void DeletePerson(Persona persona);
    void DeletePersonById(int personaId);
    List<Persona> ListPersonas();
    Persona Find(int personaId);
    Persona Update(Persona persona);
}