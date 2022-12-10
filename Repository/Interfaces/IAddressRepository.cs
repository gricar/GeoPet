using GeoPet.Models;

namespace GeoPet.Repository.Interfaces;

public interface IAddressRepository
{
  public Task<IEnumerable<Address>> GetAll();
  public Task<Address> GetById(int id);
  public Task Add(Address address);
  public Task Update(Address address);
  public Task Delete(Address address);
} 