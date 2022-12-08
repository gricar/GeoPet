using AutoMapper;
using GeoPet.DTOs;
using GeoPet.Models;

namespace GeoPet.Helpers;

public class GeoPetProfile : Profile
{
  public GeoPetProfile()
  {
    CreateMap<Sitter, SitterDTO>().ReverseMap();
    CreateMap<Pet, PetDTO>().ReverseMap();
  }
}
