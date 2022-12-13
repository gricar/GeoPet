using AutoMapper;
using GeoPet.DTOs;
using GeoPet.Models;
using GeoPet.Repository.Interfaces;
using GeoPet.Services.Interfaces;

namespace GeoPet.Services;

public class LoginService : ILoginService
{
  private readonly ISitterRepository _sitterRepository;

  private readonly IMapper _mapper;

  public LoginService(ISitterRepository sitterRepository, IMapper mapper)
  {
    _sitterRepository = sitterRepository;
    _mapper = mapper;
  }

  public async Task<string> Authenticate(LoginDTO user)
  {
    Sitter userInfo = _mapper.Map<Sitter>(user);

    Sitter? sitter = await _sitterRepository.GetByEmailAndPwd(userInfo);

    if (sitter is null) throw new ArgumentException("Invalid user email or password");

    TokenGenerator tokenManagement = new();

    return tokenManagement.Generate();
  }
}
