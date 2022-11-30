using GeoPet.DTOs;

namespace GeoPet.Services.Interfaces;

public interface ISittersService
{
  Task<SitterDTO> GetById(int id);
  Task Add(SitterDTO sitter);
  Task Update(int id, SitterDTO sitter);
  Task Delete(SitterDTO sitter);
}
