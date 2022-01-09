using System.Net;
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
    public ActionResult<Persona> Save([FromBody] Persona persona)
    {
        return new ObjectResult(_personaRepository.AddPersona(persona)) {StatusCode = StatusCodes.Status201Created};
    }

    [HttpPost("{id}")]
    public ActionResult<Persona> UploadImage(int id, IFormFile? file)
    {
        if (file is {Length: > 0})
        {
            return new ObjectResult(_personaRepository.UploadFile(id, file))
                {StatusCode = StatusCodes.Status201Created};
        }
        Dictionary<String, Object> errors = new Dictionary<string, object>();
        
        return BadRequest("fie3 cam't be null");
    }

    [HttpGet]
    public ActionResult<List<Persona>> ListPersonas()
    {
        return Ok(_personaRepository.ListPersonas());
    }

    [HttpGet("{id}")]
    public ActionResult<Persona> Find(int id)
    { 
        Persona persona = _personaRepository.Find(id);
        if (persona != null) return Ok(persona);
        return NotFound("the person was not found");
    }

    [HttpDelete]
    public ActionResult<HttpStatusCode> DeletePerson([FromBody] Persona persona)
    {
        _personaRepository.DeletePerson(persona);
        return NoContent(); 
    }


    [HttpDelete("{id}")]
    public ActionResult<HttpStatusCode> DeletePersonById(int id)
    {
        _personaRepository.DeletePersonById(id);
        return NoContent(); 
    }

    [HttpPut]
    public ActionResult<Persona> Update([FromBody] Persona persona)
    {
        return _personaRepository.Update(persona);
    }

    [HttpGet("imagen/{id}")]
    public ActionResult ShowImage(int id)
    {
        if (_personaRepository.GetAvatar(id) == null)
        {
            return NoContent();
        }
        return File(_personaRepository.GetAvatar(id), "image/jpg");
    }
}