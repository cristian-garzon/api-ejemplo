using Gatitos.Context;
using Gatitos.Models;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Gatitos.Repository;

public class PersonaRepository : IPersonaRepository
{
    private readonly IGatitoContext _gatitoContext;
    

    public PersonaRepository(IGatitoContext gatitoContext)
    {
        _gatitoContext = gatitoContext;
    }

    public Persona AddPersona(Persona persona)
    {
       Persona personaAgregada = _gatitoContext.Personas.Add(persona).Entity;
        _gatitoContext.SaveChanges();
        return personaAgregada;
    }

    public void DeletePerson(Persona persona)
    {
        _gatitoContext.Personas.Remove(persona);
        _gatitoContext.SaveChanges();
    }

    public void DeletePersonById(int personaId)
    {
        Persona persona = Find(personaId);
        DeletePerson(persona);
        _gatitoContext.SaveChanges();
    }

    public List<Persona> ListPersonas()
    {
        return _gatitoContext.Personas.Select(p => p).ToList();
    }

    public Persona Find(int personaId)
    {
        return _gatitoContext.Personas.Where(p => p.PersonaId == personaId).FirstOrDefault();
    }

    public Persona Update(Persona persona)
    {
        Persona personaUpdate = _gatitoContext.Personas.Update(persona).Entity;
        _gatitoContext.SaveChanges();
        return personaUpdate;
    }

    public Persona UploadFile(int id, IFormFile? file)
    {
        Persona persona = Find(id);
        using (var target = new MemoryStream())
        {
            file.CopyTo(target);
            persona.Avatar = target.ToArray();
        }
        Update(persona);
        return persona;
    }


    public byte[]? GetAvatar(int personaId)
    {
        Persona persona = Find(personaId);
        return persona.Avatar;
    }
}