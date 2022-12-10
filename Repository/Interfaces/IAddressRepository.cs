using GeoPet.Models;

namespace GeoPet;

public interface IAddressRepository
{
  public Task<IEnumerable<Address>> GetAll();
  public Task<Address> GetById(int id);
  public Task<Address> Add(Address address);
  public Task<Address> Update(Address address);
  public Task<Address> Delete(Address address);
} 