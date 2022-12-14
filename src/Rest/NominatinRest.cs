using System.Globalization;
using System.Text.Json;
using GeoPet.DTOs;
using GeoPet.Models;
using GeoPet.Rest.Interfaces;

namespace GeoPet.Rest;

public class NominatinRest : INominatinRest
{
  private readonly HttpClient _client;

  private const string _baseUrl = "https://nominatim.openstreetmap.org/";
  public NominatinRest(HttpClient client)
  {
    _client = client;
    _client.BaseAddress = new Uri(_baseUrl);
    _client.DefaultRequestHeaders.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
    _client.DefaultRequestHeaders.Add("Referer", "http://www.microsoft.com");
  }


  public async Task<AddressLocationDTO?> GetAdressByLatLon(string lat, string lon)
  {
    string searchQuery = $"reverse?lat={lat}&lon={lon}&format=jsonv2";

    var response = await _client.GetAsync(searchQuery);

    if (!response.IsSuccessStatusCode) return default!;

    var result = await response.Content.ReadAsStringAsync();

    return JsonSerializer.Deserialize<AddressLocationDTO>(result);
  }
}