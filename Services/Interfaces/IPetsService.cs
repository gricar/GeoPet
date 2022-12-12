using GeoPet.DTOs;

namespace GeoPet.Services.Interfaces;

public interface IPetsService
{
  Task<IEnumerable<PetDTO>> GetAll();
  Task<PetDTO> GetById(int id);
  Task Add(CreatePetDTO pet);
  Task Update(CreatePetDTO pet);
  Task Delete(PetDTO pet);
}
