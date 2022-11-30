using GeoPet.DTOs;
using GeoPet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeoPet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetsController : ControllerBase
{
  private readonly IPetsService _petsService;

  public PetsController(IPetsService petsService)
  {
    _petsService = petsService;
  }

  [HttpGet("{id:int}", Name = "GetById")]
  public async Task<ActionResult<PetDTO>> GetById(int id)
  {
    try
    {
      PetDTO pet = await _petsService.GetById(id);

      if (pet is null) return NotFound("Pet not found");

      return Ok(pet);
    }
    catch (Exception err)
    {
      return this.StatusCode(
        StatusCodes.Status500InternalServerError,
        $"Failed to Get by Id: {err.Message}");
    }
  }

  [HttpPost]
  public async Task<ActionResult<PetDTO>> Add(PetDTO pet)
  {
    try
    {
      if (ModelState.IsValid)
      {
        await _petsService.Add(pet);

        return CreatedAtRoute(nameof(GetById), new { id = pet.Id }, pet);
      }

      return BadRequest();
    }
    catch (Exception err)
    {
      return this.StatusCode(
        StatusCodes.Status500InternalServerError,
        $"Failed to Get by Id: {err.Message}");
    }
  }
}