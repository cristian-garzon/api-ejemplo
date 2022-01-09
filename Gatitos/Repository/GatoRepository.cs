
using Gatitos.Context;
using Gatitos.Models;
using Gatitos.Request;

namespace Gatitos.Repository;

public class GatoRepository : IGatoRepository
{
    
    private readonly IGatitoContext _gatitoContext;


    public GatoRepository(IGatitoContext gatitoContext)
    {
        _gatitoContext = gatitoContext;
    }

    
    public Gato AddGato(GatoRequest gatoRequest)
    {
        Gato gato = new Gato();
        gato.Años = gatoRequest.Años;
        gato.Raza = gatoRequest.Raza;
        Gato gatoCreado = _gatitoContext.Gatos.Add(gato).Entity;
        _gatitoContext.SaveChanges();
        return gatoCreado;
    }

    public void DeletePerson(Gato gato)
    {
        _gatitoContext.Gatos.Remove(gato);
        _gatitoContext.SaveChanges();
    }

    public void DeletePersonById(int gatoId)
    {
        Gato gato = Find(gatoId);
        DeletePerson(gato);
        _gatitoContext.SaveChanges();
    }

    public List<Gato> ListPersonas()
    {
        return _gatitoContext.Gatos.Select(g => g).ToList();
    }

    public Gato Find(int gatoId)
    {
        return _gatitoContext.Gatos.Where(g => g.GatoId == gatoId).First();
    }

    public Gato Update(Gato gato)
    {
        Gato gatoCreado = _gatitoContext.Gatos.Add(gato).Entity;
        _gatitoContext.SaveChanges();
        return gatoCreado;
    }
}