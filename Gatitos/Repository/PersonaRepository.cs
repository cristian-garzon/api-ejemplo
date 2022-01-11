using System.Reflection.Metadata.Ecma335;
using Gatitos.Context;
using Gatitos.Models;

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
        List<Persona> personas = _gatitoContext.Personas.Select(p => p).ToList();
        foreach (var persna in personas)
        {
            persna.Mascotas = _gatitoContext.Mascotas.Select(m => m)
                .Where(m => m.PersonaId == persna.PersonaId).ToList();
        }

        return personas;
    }

    public Persona Find(int personaId)
    {
        Persona persona = _gatitoContext.Personas.Find(personaId);
        if(persona == null) return null;
        persona.Mascotas = _gatitoContext.Mascotas.Select(m => m)
            .ToList();
        return persona;
    }

    public Persona Update(Persona persona)
    {
        Persona personaUpdate = _gatitoContext.Personas.Update(persona).Entity;
        _gatitoContext.SaveChanges();
        return personaUpdate;
    }

    public Persona UploadFile(int id, IFormFile file)
    {
        Persona persona = Find(id);
        using (var target = new MemoryStream())
        {
            file.CopyTo(target);
            persona.Avatar = target.ToArray();
        }
        return Update(persona); 
    }


    public byte[]? GetAvatar(int personaId)
    {
        Persona persona = Find(personaId);
        if (persona == null) return null;
        return persona.Avatar;
    }
}