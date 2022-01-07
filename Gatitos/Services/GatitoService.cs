
using System.Text.Json.Serialization;
using Gatitos.Context;
using Gatitos.Models;

namespace Gatitos.Services;

public class GatitoService : IGatitoService
{

    private readonly IGatitoContext _gatitoContext;


    public GatitoService(IGatitoContext gatitoContext)
    {
        _gatitoContext = gatitoContext;
    }

    public void AddPersona(Persona persona)
    {
        _gatitoContext.Personas.Add(persona);
        _gatitoContext.SaveChanges();
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
        return _gatitoContext.Personas.Where(p => p.PersonaId == personaId).First();
    }

    public Persona Update(Persona persona)
    {
        Persona personaUpdate = _gatitoContext.Personas.Update(persona).Entity;
        _gatitoContext.SaveChanges();
        return personaUpdate;
    }
}