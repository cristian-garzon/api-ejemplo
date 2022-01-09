using System.Net;
using System.Reflection.Metadata.Ecma335;
using Gatitos.Models;
using Gatitos.Repository;
using System.Web;
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
    public ActionResult<Persona?> Save([FromBody] Persona persona)
    {
        return new ObjectResult(_personaRepository.AddPersona(persona)) {StatusCode = StatusCodes.Status201Created};
    }

    [HttpPost("{id}")]
    public Persona UploadImage(int id, IFormFile? file)
    {
        if (file != null)
        {
            return _personaRepository.UploadFile(id, file);
        }
        return null;
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

    [HttpGet("/image/{id}")]
    public ActionResult ShowImage(int id)
    {
        if (_personaRepository.GetAvatar(id) == null)
        {
            return NoContent();
        }
        return File(_personaRepository.GetAvatar(id), "image/jpg");
    }
}