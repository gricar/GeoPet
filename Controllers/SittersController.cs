using GeoPet.DTOs;
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
  public async Task<ActionResult<Sitter>> GetById(int id)
  {
    try
    {
      Sitter? sitter = await _sitterRepository.GetById(id);

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
  public async Task<ActionResult<Sitter>> Create(SitterDTO sitterRequest)
  {
    try
    {
      if (ModelState.IsValid)
      {
        Sitter sitter = new()
        {
          Id = sitterRequest.Id,
          Name = sitterRequest.Name,
          Email = sitterRequest.Email,
          Password = sitterRequest.Password
        };

        await _sitterRepository.Add(sitter);
        return CreatedAtRoute(nameof(GetById), new { id = sitter.Id }, sitterRequest);
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
  public async Task<IActionResult> Update(int id, SitterDTO sitterRequest)
  {
    try
    {
      if (id != sitterRequest.Id)
      {
        return BadRequest($"Sitter id conflict");
      }

      Sitter? sitterFound = await _sitterRepository.GetById(id);

      if (sitterFound is null) return NotFound("Sitter not found");

      if (ModelState.IsValid)
      {
        Sitter sitter = new()
        {
          Id = sitterRequest.Id,
          Name = sitterRequest.Name,
          Email = sitterRequest.Email,
          Password = sitterRequest.Password
        };

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