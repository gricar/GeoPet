using GeoPet.Database.Context;
using GeoPet.Repository.Interfaces;
using GeoPet.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoPet.Repository;

public class AddressRepository : IAddressRepository
{
  private readonly AppDbContext _context;
  public AddressRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Address>> GetAll()
  {
    return await _context.Addresses.ToListAsync();
  }

  public async Task<Address?> GetById(int id)
  {
    return await _context.Addresses
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);
  }

  public async Task Add(Address address)
  {
    _context.Addresses.Add(address);
    await _context.SaveChangesAsync();
  }

  public async Task Update(Address address)
  {
    _context.Addresses.Update(address);
    await _context.SaveChangesAsync();
  }

  public async Task Delete(Address address)
  {
      _context.Addresses.Remove(address);
      await _context.SaveChangesAsync();
  }
}
