using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoPet.Models;

public class Sitter
{
  public int Id { get; set; }

  [Required]
  public string Name { get; set; } = default!;

  [Required]
  [EmailAddress]
  public string Email { get; set; } = default!;

  [Required]
  public string Password { get; set; } = default!;

  [ForeignKey("AddressId")]
  public Address? Address { get; set; }
}
