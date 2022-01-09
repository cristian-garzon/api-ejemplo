using Gatitos.Context;
using Gatitos.Models;
using Gatitos.Request;

namespace Gatitos.Repository;

public interface IGatoRepository
{
    Gato AddGato(GatoRequest gatoRequest);
    void DeletePerson(Gato gato);
    void DeletePersonById(int gatoId);
    List<Gato> ListPersonas();
    Gato Find(int gatoId);
    Gato Update(Gato gato);
}