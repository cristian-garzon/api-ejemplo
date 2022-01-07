using Gatitos.Models;
using Gatitos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Gatitos.Controllers;

[Route("api/persona")]
[ApiController]
public class PersonaController : Controller
{
    private readonly IPersonaRepository _personaRepository;

    public PersonaController(IPersonaRepository personaRepository)
    {
        _personaRepository = personaRepository;
    }

    [HttpPost]
    public Persona Save([FromBody] Persona persona)
    {
        return _personaRepository.AddPersona(persona);
    }

    [HttpGet]
    public List<Persona> ListPersonas()
    {
        return _personaRepository.ListPersonas();
    }

    [HttpGet("{id}")]
    public Persona Find(int id)
    {
        return _personaRepository.Find(id);
    }

    [HttpDelete]
    public void DeletePerson([FromBody] Persona persona)
    {
        _personaRepository.DeletePerson(persona);        
    }
    
    
    [HttpDelete("{id}")]
    public void DeletePersonById(int id)
    {
        _personaRepository.DeletePersonById(id);        
    }

    [HttpPut]
    public Persona Update([FromBody] Persona persona)
    {
        return _personaRepository.Update(persona);
    }
}