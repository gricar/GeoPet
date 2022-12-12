namespace GeoPet.DTOs;

public class CreateAddressDTO
{
  public string Cep { get; set; } = null!;
  public int SitterId { get; set; }
}

public class AddressDTO
{
  public int Id { get; set; }
  public string Cep { get; set; } = null!;
  public string? State { get; set; }
  public string? City { get; set; }
  public string? County { get; set; }
  public string? Street { get; set; }
  public int SitterId { get; set; }
}
