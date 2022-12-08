using GeoPet.DTOs;
using GeoPet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeoPet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressesController : ControllerBase
{
  private readonly IAddressesService _addressesService;

  public AddressesController(IAddressesService addressesService)
  {
    _addressesService = addressesService;
  }

  [HttpGet("{id:int}", Name = "GetAddressById")]
  public async Task<ActionResult<AddressDTO>> GetAddressById(int id)
  {
    try
    {
      AddressDTO address = await _addressesService.GetById(id);

      if (address is null) return NotFound("Address not found");

      return Ok(address);
    }
    catch (Exception err)
    {
      return this.StatusCode(
        StatusCodes.Status500InternalServerError,
        $"Failed to Get by Id: {err.Message}");
    }
  }

  [HttpPost]
  public async Task<ActionResult<AddressDTO>> Add(AddressDTO address)
  {
    try
    {
      if (ModelState.IsValid)
      {
        await _addressesService.Add(address);

        return CreatedAtRoute(nameof(GetAddressById), new { id = address.Id }, address);
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