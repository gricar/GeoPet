using GeoPet.Database.Context;
using GeoPet.Repository.Interfaces;
using GeoPet.Models;

namespace GeoPet.Repository;

public class AddressRepository : IAddressRepository
{
  private readonly AppDbContext _context;
  public AddressRepository(AppDbContext context)
  {
    _context = context;
  }
}
