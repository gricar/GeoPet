using AutoMapper;
using GeoPet.DTOs;
using GeoPet.Models;
using GeoPet.Repository.Interfaces;
using GeoPet.Services.Interfaces;

namespace GeoPet.Services;
public class AddressesService : IAddressesService
{
  private readonly IAddressRepository _addressRepository;
  private readonly IMapper _mapper;

  public AddressesService(IAddressRepository addressRepository, IMapper mapper)
  {
    _addressRepository = addressRepository;
    _mapper = mapper;
  }

  public async Task<AddressDTO> GetById(int id)
  {
    Address? address = await _addressRepository.GetById(id);

    if (address is null) return null!;

    return _mapper.Map<AddressDTO>(address);
  }

  public async Task Add(AddressDTO addressRequest)
  {
    Address address = _mapper.Map<Address>(addressRequest);

    await _addressRepository.Add(address);
  }

}
