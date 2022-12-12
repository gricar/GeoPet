using GeoPet.Database.Context;
using GeoPet.Models;
using GeoPet.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeoPet.Repository;

public class PetRepository : IPetRepository
{
  private readonly AppDbContext _context;

  public PetRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Pet>> GetAll()
  {
    return await _context.Pets.ToListAsync();
  }

  public async Task<Pet?> GetById(int id)
  {
    return await _context.Pets
            .AsNoTracking()
            .Include(p => p.Sitter)
            .FirstOrDefaultAsync(p => p.Id == id);
  }

  public async Task Add(Pet pet)
  {
    _context.Pets.Add(pet);
    await _context.SaveChangesAsync();
  }

  public async Task Update(Pet pet)
  {
    _context.Pets.Update(pet);
    await _context.SaveChangesAsync();
  }

  public async Task Delete(Pet pet)
  {
    _context.Pets.Remove(pet);
    await _context.SaveChangesAsync();

  }
}