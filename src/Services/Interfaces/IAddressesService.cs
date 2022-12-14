using GeoPet.DTOs;

namespace GeoPet.Services.Interfaces;

public interface IAddressesService
{
  Task<IEnumerable<AddressDTO>> GetAll();
  Task<AddressDTO> GetById(int id);
  Task<AddressDTO> Add(CreateAddressDTO address);
  Task Update(int id, AddressDTO address);
  Task Delete(AddressDTO address);
}