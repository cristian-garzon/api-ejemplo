using System.IO.Enumeration;
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
    
    
    [HttpPut("imagen/{id}")]
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

    [HttpGet("{id}")]
    public ActionResult<Mascota> find(int id)
    {
        Mascota mascota = _mascotaRepository.Find(id);
        if (mascota == null) return NotFound();
        return mascota;
    }


    [HttpGet("vacuna/{id}")]
    public ActionResult<vacuna> FindVacuna(int id)
    {
        vacuna vacuna = _mascotaRepository.FindVacuna(id);
        if (vacuna == null) return NotFound();
        return vacuna;
    }


    [HttpDelete("vacuna/{id}")]
    public ActionResult deleteVacuna(int id)
    {
        vacuna vacuna = _mascotaRepository.FindVacuna(id);
        if (vacuna == null) return NotFound();
        _mascotaRepository.DeleteVacunaById(id);
        return NoContent();
    }

    [HttpGet("vacuna")]
    public ActionResult<List<vacuna>> ListVacunas()
    {
        return _mascotaRepository.ListVacunas();
    }

    [HttpPut("vacuna")]
    public ActionResult<vacuna> UpdateVacuna([FromBody] vacuna vacuna)
    {
        return _mascotaRepository.Update(vacuna);
    }
    
    [HttpPut("vacuna/{id}")]
    public ActionResult<Mascota> AddVacuna([FromBody] List<vacuna> vacunas, int id)
    {
        Mascota? mascota = _mascotaRepository.AddVacuna(vacunas, id);
        if (mascota == null) return NotFound();
        return new ObjectResult(mascota)
            {StatusCode = StatusCodes.Status201Created};
    }


    [HttpPut("album/{id}")]
    public ActionResult<Mascota> AddAlbum([FromBody] Album album, int id)
    {
        Mascota? mascota = _mascotaRepository.Find(id);
        if (mascota == null) return NotFound();
        if (mascota.Album != null) return BadRequest("the album is already");
        Mascota? mascotaAlbum = _mascotaRepository.AddAlbum(album, id);
        return new ObjectResult(mascotaAlbum)
            {StatusCode = StatusCodes.Status201Created};
    }

   
}