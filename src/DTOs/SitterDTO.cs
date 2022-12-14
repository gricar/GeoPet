using System.ComponentModel.DataAnnotations;

namespace GeoPet.DTOs;
public class SitterDTO
{
  public int Id { get; set; }

  [Required]
  public string Name { get; set; } = default!;

  [Required]
  [EmailAddress]
  public string Email { get; set; } = default!;

  [Required]
  public string Password { get; set; } = default!;
}

public class CreateSitterDTO
{
  [Required]
  public string Name { get; set; } = default!;

  [Required]
  [EmailAddress]
  public string Email { get; set; } = default!;

  [Required]
  public string Password { get; set; } = default!;
}
public class NewSitterDTO
{
  public int Id { get; set; }
  public string Name { get; set; } = default!;
  public string Email { get; set; } = default!;
}