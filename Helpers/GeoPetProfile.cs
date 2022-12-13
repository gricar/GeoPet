using AutoMapper;
using GeoPet.DTOs;
using GeoPet.Models;

namespace GeoPet.Helpers;

public class GeoPetProfile : Profile
{
  public GeoPetProfile()
  {
    CreateMap<Address, AddressDTO>().ReverseMap();
    CreateMap<Pet, PetDTO>().ReverseMap();
    CreateMap<Pet, CreatePetDTO>().ReverseMap();
    CreateMap<Sitter, SitterDTO>().ReverseMap();
    CreateMap<Sitter, LoginDTO>().ReverseMap();
  }
}
