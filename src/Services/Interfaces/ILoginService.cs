using GeoPet.DTOs;

namespace GeoPet.Services.Interfaces;

public interface ILoginService
{
  Task<string> Authenticate(LoginDTO user);
}