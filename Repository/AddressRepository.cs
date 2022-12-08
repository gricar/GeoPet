using GeoPet.Database.Context;
using GeoPet.Models;
using GeoPet.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeoPet.Repository;

public class AddressRepository : IAddressRepository
{
  private readonly AppDbContext _context;

  public AddressRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<Address?> GetById(int id)
  {
    return await _context.Addresses
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
  }

  public async Task<int> Add(Address address)
  {
    _context.Addresses.Add(address);
    return await _context.SaveChangesAsync();
  }
}
