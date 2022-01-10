using System.Net;
using Gatitos.Models;
using Gatitos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Gatitos.Controllers;

[Route("api/mascota")]
[ApiController]
public class MascotaController : Controller
{
    private readonly IMascotaRepository _mascotaRepository;

    public MascotaController(IMascotaRepository mascotaRepository)
    {
        _mascotaRepository = mascotaRepository;
    }
    
    
    [HttpPost("{id}")]
    public ActionResult<Persona> UploadImage(int id, IFormFile file)
    {
        if(file.Length < 0) return BadRequest();
        if (_mascotaRepository.Find(id) == null) return NotFound();
        Mascota mascota =_mascotaRepository.UploadFile(id, file);
        return new ObjectResult(mascota)
            {StatusCode = StatusCodes.Status201Created};
    }
    
    [HttpGet]
    public ActionResult<List<Mascota>> ListPersonas()
    {
        return Ok(_mascotaRepository.ListMascotas());
    }
    
    
    [HttpDelete]
    public ActionResult<HttpStatusCode> DeletePerson([FromBody] Mascota mascota)
    {
        _mascotaRepository.DeleteMascota(mascota); 
        return NoContent(); 
    }
    
    
    [HttpDelete("{id}")]
    public ActionResult<HttpStatusCode> DeletePersonById(int id)
    {
        if (_mascotaRepository.Find(id) == null) return NotFound();
        _mascotaRepository.DeleteMascotaById(id);
        return NoContent(); 
    }
    
     
    [HttpPut]
    public ActionResult<Mascota> Update([FromBody] Mascota mascota)
    {
        return _mascotaRepository.Update(mascota);
    }
    
    [HttpGet("imagen/{id}")]
    public ActionResult ShowImage(int id)
    {
        Mascota image = _mascotaRepository.Find(id);
        if (image == null) return NotFound();
        if (image.FotoHashCode == 0) return NoContent();
        return File(image.Foto, "image/jpg");
    }
}