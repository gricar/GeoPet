using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GeoPet.Models;

public class Address
{
  public int Id { get; set; }

  [JsonPropertyName("cep")]
  [MaxLength(9)]
  [Required]
  public string Cep { get; set; } = null!;

  [JsonPropertyName("uf")]
  [Required]
  public string State { get; set; } = null!;

  [JsonPropertyName("localidade")]
  [Required]
  public string City { get; set; } = null!;

  [JsonPropertyName("bairro")]
  [Required]
  public string County { get; set; } = null!;

  [JsonPropertyName("logradouro")]
  [Required]
  public string Street { get; set; } = null!;

  public int SitterId { get; set; }
  [JsonIgnore]
  public Sitter Sitter { get; set; } = default!;
}