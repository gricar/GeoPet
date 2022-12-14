using GeoPet.Models;

namespace GeoPet.Repository.Interfaces;


public interface IPetRepository
{
  Task<IEnumerable<Pet>> GetAll();
  Task<Pet?> GetById(int id);
  Task Add(Pet pet);
  Task Update(Pet pet);
  Task Delete(Pet pet);
}