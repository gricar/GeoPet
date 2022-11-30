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

  public async Task<Pet?> GetById(int id)
  {
    return await _context.Pets
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);
  }

  public async Task<int> Add(Pet pet)
  {
    _context.Pets.Add(pet);
    return await _context.SaveChangesAsync();
  }
}
