using GeoPet.Models;

namespace GeoPet.Repository.Contracts;


public interface IPetRepository
{
  Task<Pet?> GetById(int id);
  Task Add(Pet pet);
}