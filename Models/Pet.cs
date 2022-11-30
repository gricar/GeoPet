using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
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
  [JsonIgnore]
  public Sitter Sitter { get; set; } = default!;
}