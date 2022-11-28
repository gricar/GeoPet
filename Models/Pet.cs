using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeoPet.Enums;

namespace GeoPet.Models;

public class Pet
{
  public int Id { get; set; }

  [Required]
  public string Name { get; set; } = default!;

  [Required]
  public int Age { get; set; } = default!;

  [Required]
  public PetSizesEnum Size { get; set; } = default!;

  [Required]
  public PetBreedsEnum Breed { get; set; } = default!;

  [Required]
  public bool IsLost { get; set; } = false;

  [ForeignKey("SitterId")]
  public Sitters Sitter { get; set; } = default!;
}