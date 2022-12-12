using GeoPet.Models;

namespace GeoPet.Rest.Interfaces;

public interface IViaCepRest
{
  Task<Address?> FindCep(string cep);
}
