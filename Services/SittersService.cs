using AutoMapper;
using GeoPet.DTOs;
using GeoPet.Models;
using GeoPet.Repository.Interfaces;
using GeoPet.Services.Interfaces;

namespace GeoPet.Services;

public class SittersService : ISittersService
{
  private readonly ISitterRepository _sitterRepository;

  private readonly IMapper _mapper;

  public SittersService(ISitterRepository sitterRepository, IMapper mapper)
  {
    _sitterRepository = sitterRepository;
    _mapper = mapper;
  }

  public async Task<SitterDTO> GetById(int id)
  {
    Sitter? sitter = await _sitterRepository.GetById(id);

    if (sitter is null) return null!;

    return _mapper.Map<SitterDTO>(sitter);
  }

  public async Task Add(SitterDTO sitterRequest)
  {
    Sitter sitter = _mapper.Map<Sitter>(sitterRequest);

    await _sitterRepository.Add(sitter);
  }

  public async Task Update(int id, SitterDTO sitterRequest)
  {
    Sitter sitter = _mapper.Map<Sitter>(sitterRequest);

    await _sitterRepository.Update(sitter);
  }

  public async Task Delete(SitterDTO sitterRequest)
  {
    Sitter sitter = _mapper.Map<Sitter>(sitterRequest);

    await _sitterRepository.Delete(sitter);
  }
}
