using GeoPet.Models;

namespace GeoPet.Repository.Interfaces;

public interface IAddressRepository
{
  Task<IEnumerable<Address>> GetAll();
  Task<Address?> GetById(int id);
  Task Add(Address address);
  Task Update(Address address);
 Task Delete(Address address);
}