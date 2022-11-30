using GeoPet.Models;

namespace GeoPet.Repository.Interfaces;


public interface IPetRepository
{
  Task<Pet?> GetById(int id);
  Task<int> Add(Pet pet);
}