using GeoPet.DTOs;
using GeoPet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeoPet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SittersController : ControllerBase
{
  private readonly ISittersService _sittersService;

  public SittersController(ISittersService sittersService)
  {
    _sittersService = sittersService;
  }

  [HttpGet("{id:int}", Name = "GetSitterById")]
  public async Task<ActionResult<SitterDTO>> GetSitterById(int id)
  {
    try
    {
      SitterDTO sitter = await _sittersService.GetById(id);

      if (sitter is null) return NotFound("Sitter not found");

      return Ok(sitter);
    }
    catch (Exception err)
    {
      return this.StatusCode(
        StatusCodes.Status500InternalServerError,
        $"Failed to Get by Id: {err.Message}");
    }
  }

  [HttpPost]
  public async Task<ActionResult<SitterDTO>> Create(SitterDTO sitter)
  {
    try
    {
      if (ModelState.IsValid)
      {
        await _sittersService.Add(sitter);
        return CreatedAtRoute(nameof(GetSitterById), new { id = sitter.Id }, sitter);
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

  [HttpPut("{id:int}")]
  public async Task<IActionResult> Update(int id, SitterDTO sitter)
  {
    try
    {
      if (id != sitter.Id)
      {
        return BadRequest($"Sitter id conflict");
      }

      SitterDTO? sitterFound = await _sittersService.GetById(id);

      if (sitterFound is null) return NotFound("Sitter not found");

      if (ModelState.IsValid)
      {
        await _sittersService.Update(id, sitter);
        return Ok($"Sitter id {id} succesfully updated");
      }

      return BadRequest();
    }
    catch (Exception err)
    {
      return this.StatusCode(
        StatusCodes.Status500InternalServerError,
        $"Failed to update: {err.Message}");
    }
  }

  [HttpDelete("{id:int}")]
  public async Task<IActionResult> Delete(int id)
  {
    try
    {
      SitterDTO? sitter = await _sittersService.GetById(id);

      if (sitter is null) return NotFound("Sitter not found");

      await _sittersService.Delete(sitter);
      return Ok($"Sitter succesfully deleted");
    }
    catch (Exception err)
    {
      return this.StatusCode(
        StatusCodes.Status500InternalServerError,
        $"Failed to Remove: {err.Message}");
    }
  }
}
