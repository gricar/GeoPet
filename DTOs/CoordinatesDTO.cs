using System.Text.Json.Serialization;

namespace GeoPet.DTOs;

public class CoordinatesDTO
{
  public string Lat { get; set; } = default!;
  public string Lon { get; set; } = default!;
}

public class AddressLocationDTO
{
  [JsonPropertyName("name")]
  public string Name { get; set; } = default!;

  [JsonPropertyName("address")]
  public CoordinatesDTOAddressDTO Address { get; set; } = default!;
}

public class CoordinatesDTOAddressDTO
{
  [JsonPropertyName("road")]
  public string Street { get; set; } = default!;

  [JsonPropertyName("city")]
  public string City { get; set; } = default!;

  [JsonPropertyName("state")]
  public string State { get; set; } = default!;
}