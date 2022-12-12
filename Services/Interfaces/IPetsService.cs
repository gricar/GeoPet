using GeoPet.DTOs;

namespace GeoPet.Services.Interfaces;

public interface IPetsService
{
  Task<PetDTO> GetById(int id);
  Task Add(PetDTO pet);
  string CreateQrCode(PetDTO pet);
}
