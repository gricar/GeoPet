using GeoPet.Models;
using GeoPet.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GeoPet.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SittersController : ControllerBase
{
  private readonly ISitterRepository _sitterRepository;

  public SittersController(ISitterRepository sitterRepository)
  {
    _sitterRepository = sitterRepository;
  }

  [HttpGet("{id:int}", Name = "GetById")]
  public async Task<IActionResult> GetById(int id)
  {
    try
    {
      Sitter? sitter = await _sitterRepository.GetById(id);

      if (sitter is null) return NotFound();

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
  public async Task<IActionResult> Create(Sitter sitter)
  {
    try
    {
      if (ModelState.IsValid)
      {
        await _sitterRepository.Add(sitter);
        return CreatedAtRoute(nameof(GetById), new { id = sitter.Id }, sitter);
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
  public async Task<IActionResult> Update(int id, Sitter sitter)
  {
    try
    {
      if (id != sitter.Id)
      {
        return BadRequest($"Sitter id conflict");
      }

      Sitter? sitterFound = await _sitterRepository.GetById(id);

      if (sitterFound is null) return NotFound("Sitter not found");

      if (ModelState.IsValid)
      {
        await _sitterRepository.Update(sitter);
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
      Sitter? sitter = await _sitterRepository.GetById(id);

      if (sitter is null) return NotFound("Sitter not found");

      await _sitterRepository.Delete(sitter);
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