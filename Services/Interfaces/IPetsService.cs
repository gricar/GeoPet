using GeoPet.DTOs;

namespace GeoPet.Services.Interfaces;

public interface IPetsService
{
  Task<IEnumerable<PetDTO>> GetAll();
  Task<PetDTO> GetById(int id);
  Task Add(PetDTO pet);
  Task Update(int id, PetDTO pet);
  Task Delete(PetDTO pet);
  string CreateQrCode(PetDTO pet);
}
