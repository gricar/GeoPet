using AutoMapper;
using GeoPet.DTOs;
using GeoPet.Models;
using GeoPet.Repository.Interfaces;
using GeoPet.Rest.Interfaces;
using GeoPet.Services.Interfaces;

namespace GeoPet.Services;
public class AddressesService : IAddressesService
{
  private readonly IAddressRepository _addressRepository;

  private readonly IViaCepRest _viaCepApi;

  private readonly IMapper _mapper;

  public AddressesService(IAddressRepository addressRepository, IViaCepRest viaCepApi, IMapper mapper)
  {
    _addressRepository = addressRepository;
    _viaCepApi = viaCepApi;
    _mapper = mapper;
  }

  public async Task<AddressDTO> GetById(int id)
  {
    Address? address = await _addressRepository.GetById(id);

    if (address is null) return null!;

    return _mapper.Map<AddressDTO>(address);
  }

  public async Task<AddressDTO> Add(CreateAddressDTO addressRequest)
  {
    var cepIsValid = await _viaCepApi.FindCep(addressRequest.Cep);

    if (cepIsValid is null)
    {
      throw new ArgumentException("Invalid CEP");
    }

    cepIsValid.SitterId = addressRequest.SitterId;

    Address address = _mapper.Map<Address>(cepIsValid);

    await _addressRepository.Add(address);

    return _mapper.Map<AddressDTO>(address);
  }

}
