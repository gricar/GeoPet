using System.ComponentModel.DataAnnotations;

namespace GeoPet.Models;

public class Address
{
  public int Id { get; set; }

  [MaxLength(9)]
  [Required]
  public string Cep { get; set; } = null!;

  [Required]
  public string State { get; set; } = null!;

  [Required]
  public string City { get; set; } = null!;

  [Required]
  public string County { get; set; } = null!;

  [Required]
  public string Street { get; set; } = null!;
}