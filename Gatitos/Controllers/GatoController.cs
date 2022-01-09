using Gatitos.Models;
using Gatitos.Repository;
using Gatitos.Request;
using Microsoft.AspNetCore.Mvc;

namespace Gatitos.Controllers;

[Route("api/gato")]
[ApiController]
public class GatoController : Controller
{
    private readonly IGatoRepository _gatoRepository;

    public GatoController(IGatoRepository gatoRepository)
    {
        _gatoRepository = gatoRepository;
    }

    [HttpPost]
    public Gato Save([FromBody] GatoRequest gatoRequest)
    {
        return _gatoRepository.AddGato(gatoRequest);
    }

    [HttpGet]
    public List<Gato> ListPersonas()
    {
        return _gatoRepository.ListPersonas();
    }

    [HttpGet("{id}")]
    public Gato Find(int id)
    {
        return _gatoRepository.Find(id);
    }

    [HttpDelete]
    public void DeletePerson([FromBody] Gato gato)
    {
        _gatoRepository.DeletePerson(gato);
    }


    [HttpDelete("{id}")]
    public void DeletePersonById(int id)
    {
        _gatoRepository.DeletePersonById(id);
    }

    [HttpPut]
    public Gato Update([FromBody] Gato gato)
    {
        return _gatoRepository.Update(gato);
    }
}