using Gatitos.Models;
using Gatitos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Gatitos.Controllers;

[Route("api/album")]
[ApiController]
public class AlbumController : Controller
{
    private readonly IAlbumRepository _albumRepository;

    public AlbumController(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }

    [HttpGet]
    public ActionResult<List<Album>> ListAlbum()
    { 
        return Ok(_albumRepository.ListAlbum());
    }
}