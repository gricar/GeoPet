using GeoPet.DTOs;
using GeoPet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeoPet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
  private readonly ILoginService _loginService;

  public LoginController(ILoginService loginService)
  {
    _loginService = loginService;
  }

  [HttpPost]
  public async Task<ActionResult<string>> Login(LoginDTO user)
  {
    try
    {
      if (ModelState.IsValid)
      {
        string token = await _loginService.Authenticate(user);

        return Ok(new { token });
      }

      return BadRequest();
    }
    catch (ArgumentException err)
    {
      return BadRequest($"Failed to login: {err.Message}");
    }
    catch (Exception err)
    {
      return this.StatusCode(
        StatusCodes.Status500InternalServerError,
        $"Error: {err.Message}");
    }
  }
}
