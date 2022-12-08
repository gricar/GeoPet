namespace GeoPet.DTOs;

public class AddressDTO
{
  public int Id { get; set; }
  public string Cep { get; set; } = null!;
  public string State { get; set; } = null!;
  public string City { get; set; } = null!;
  public string County { get; set; } = null!;
  public string Street { get; set; } = null!;
  public int SitterId { get; set; }
}