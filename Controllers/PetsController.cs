using GeoPet.DTOs;
using GeoPet.Models;
using GeoPet.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GeoPet.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetsController : ControllerBase
{
  private readonly IPetRepository _petRepository;
  private readonly ISitterRepository _sitterRepository;


  public PetsController(IPetRepository petRepository,
                        ISitterRepository sitterRepository)
  {
    _petRepository = petRepository;
    _sitterRepository = sitterRepository;
  }

  [HttpGet("{id:int}", Name = "GetPetById")]
  public async Task<IActionResult> GetPetById(int id)
  {
    try
    {
      Pet? pet = await _petRepository.GetById(id);

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
  public async Task<IActionResult> Create(PetDto pet)
  {
    try
    {
      if (ModelState.IsValid)
      {
        Sitter? sitter = await _sitterRepository.GetById(pet.SitterId);

        if (sitter is null) return NotFound("Sitter not found");

        var newPet = new Pet()
        {
          Id = pet.Id,
          Name = pet.Name,
          Age = pet.Age,
          Size = pet.Size,
          Breed = pet.Breed,
          IsLost = pet.IsLost,
          SitterId = pet.SitterId,
        };

        await _petRepository.Add(newPet);
        return CreatedAtRoute(nameof(GetPetById), new { id = pet.Id }, pet);
      }

      return BadRequest();
    }
    catch (Exception err)
    {
      return this.StatusCode(
        StatusCodes.Status500InternalServerError,
        $"Failed to Create: {err.Message}");
    }
  }
}
