using GeoPet.Database.Context;
using GeoPet.Repository.Interfaces;
using GeoPet.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoPet.Repository;

public class SitterRepository : ISitterRepository
{
  private readonly AppDbContext _context;

  public SitterRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<Sitter?> GetById(int id)
  {
    return await _context.Sitters
            .AsNoTracking()
            .Include(s => s.Pets)
            .FirstOrDefaultAsync(s => s.Id == id);
  }

  public async Task Add(Sitter sitter)
  {
    _context.Sitters.Add(sitter);
    await _context.SaveChangesAsync();
  }

  public async Task Update(Sitter sitter)
  {
    _context.Entry(sitter).State = EntityState.Modified;
    await _context.SaveChangesAsync();
  }

  public async Task Delete(Sitter sitter)
  {
    _context.Sitters.Remove(sitter);
    await _context.SaveChangesAsync();
  }
}