using GeoPet.DTOs;

namespace GeoPet.Services.Interfaces;

public interface IAddressesService
{
  Task<AddressDTO> GetById(int id);
  Task Add(AddressDTO address);
}
