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

    [HttpPut("imagen/{id}")]
    public ActionResult<Persona> UploadImage(int id, IFormFile? file)
    {
        if (file == null || file.Length < 0) return BadRequest("error uploading the file");
        Persona persona = _personaRepository.Find(id); 
        if (persona == null) return NotFound();
        Persona personaCreada = _personaRepository.UploadFile(id, file);
        return new ObjectResult(personaCreada)
            {StatusCode = StatusCodes.Status201Created};
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
        return NotFound();
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
        if (_personaRepository.Find(id) == null) return NotFound();
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
        Persona image = _personaRepository.Find(id);
        if (image == null) return NotFound();
        if (image.AvatarHashCode == 0) return NoContent();
        return File(image.Avatar, "image/jpg");
    }


    [HttpPut("mascota/{id}")]
    public ActionResult AddMascotas([FromBody] List<Mascota> mascotas, int id)
    {
        Persona persona = _personaRepository.Find(id);
        if (persona == null) return NotFound();
        if (persona.Mascotas == null || persona.Mascotas.Count < 0) persona.Mascotas = new List<Mascota>();
        foreach (var mascota in mascotas)
        {
           persona.Mascotas.Add(mascota); 
        }
        Persona personaCreada = _personaRepository.Update(persona);
        return new ObjectResult(personaCreada)
            {StatusCode = StatusCodes.Status201Created};
    }

}