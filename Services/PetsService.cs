using AutoMapper;
using GeoPet.DTOs;
using GeoPet.Models;
using GeoPet.Repository.Interfaces;
using GeoPet.Rest;
using GeoPet.Services.Interfaces;
using System.Text.Json;

namespace GeoPet.Services;
public class PetsService : IPetsService
{
  private readonly IPetRepository _petRepository;
  private readonly IMapper _mapper;

  public PetsService(IPetRepository petRepository, IMapper mapper)
  {
    _petRepository = petRepository;
    _mapper = mapper;
  }

  public async Task<IEnumerable<PetDTO>> GetAll()
  {
    var pets = await _petRepository.GetAll();

    return _mapper.Map<IEnumerable<PetDTO>>(pets);
  }
  
  public async Task<PetDTO> GetById(int id)
  {
    Pet? pet = await _petRepository.GetById(id);

    if (pet is null) return null!;

    return _mapper.Map<PetDTO>(pet);
  }

  public async Task Add(CreatePetDTO petRequest)
  {
    Pet pet = _mapper.Map<Pet>(petRequest);

    await _petRepository.Add(pet);
  }

  public async Task Update(CreatePetDTO petRequest)
  {
    Pet pet = _mapper.Map<Pet>(petRequest);

    await _petRepository.Update(pet);
  }

  public async Task Delete(PetDTO petRequest)
  {
    Pet pet = _mapper.Map<Pet>(petRequest);

    await _petRepository.Delete(pet);
  }

  public string CreateQrCode(PetDTO pet)
  {
    string petInfo = JsonSerializer.Serialize(pet);

    string petQrCode = QrCodeGenerator.GenerateByteArray(petInfo);

    return petQrCode;
  }

}
