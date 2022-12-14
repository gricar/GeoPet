using GeoPet.DTOs;

namespace GeoPet.Services.Interfaces;

public interface ISittersService
{
  Task<SitterDTO> GetById(int id);
  Task<NewSitterDTO> Add(CreateSitterDTO sitter);
  Task Update(SitterDTO sitter);
  Task Delete(SitterDTO sitter);
}
