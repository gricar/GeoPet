using GeoPet.Models;

namespace GeoPet.Repository;

public interface ISitterRepository
{
  Task<Sitter?> GetById(int id);
  Task Add(Sitter sitter);
  Task Update(Sitter sitter);
  Task Delete(Sitter sitter);
}