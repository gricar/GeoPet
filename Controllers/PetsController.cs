using GeoPet.DTOs;
using GeoPet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeoPet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetsController : Controller
{
  private readonly IPetsService _petsService;

  public PetsController(IPetsService petsService)
  {
    _petsService = petsService;
  }
  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var pets = await _petsService.GetAll();
    return Ok(pets);
  }


  [HttpGet("{id:int}", Name = "GetById")]
  public async Task<IActionResult> GetById(int id)
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
  public async Task<ActionResult<PetDTO>> Add(CreatePetDTO pet)
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

  [HttpPut("{id:int}")]
  public async Task<ActionResult<PetDTO>> Update(int id, CreatePetDTO pet)
  {
    try
    {
      PetDTO petById = await _petsService.GetById(id);

      if (petById is null) return NotFound("Pet not found");

      await _petsService.Update(pet);

      return Ok($"Pet id {id} succesfully updated");
    }
    catch (Exception err)
    {
      return this.StatusCode(
        StatusCodes.Status500InternalServerError,
        $"Failed to Get by Id: {err.Message}");
    }
  }

  [HttpDelete("{id:int}")]
  public async Task<ActionResult<PetDTO>> Delete(int id)
  {
    try
    {
      PetDTO pet = await _petsService.GetById(id);

      if (pet is null) return NotFound("Pet not found");

      await _petsService.Delete(pet);

      return Ok($"Pet id {id} succesfully deleted");
    }
    catch (Exception err)
    {
      return this.StatusCode(
        StatusCodes.Status500InternalServerError,
        $"Failed to Get by Id: {err.Message}");
    }
  }
  
  [HttpGet]
  [Route("qrcode/{id}")]
  public async Task<IActionResult> QrCode(int id)
  {
    PetDTO pet = await _petsService.GetById(id);

    if (pet is null) return NotFound("Pet not found");

    string petQrCode = _petsService.CreateQrCode(pet);

    ViewBag.QrCodeImage = petQrCode;
    ViewBag.PetName = pet.Name;

    return View();
  }
}