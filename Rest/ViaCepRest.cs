using System.Text.Json;
using GeoPet.Models;
using GeoPet.Rest.Interfaces;

namespace GeoPet.Rest;

public class ViaCepRest : IViaCepRest
{
  private readonly HttpClient _client;

  private const string _baseUrl = "https://viacep.com.br/ws/";

  public ViaCepRest(HttpClient client)
  {
    _client = client;
    _client.BaseAddress = new Uri(_baseUrl);
  }


  public async Task<Address?> FindCep(string cep)
  {
    string searchQuery = $"{cep}/json/";

    HttpResponseMessage response = await _client.GetAsync(searchQuery);

    if (!response.IsSuccessStatusCode) return default!;

    var result = await response.Content.ReadAsStringAsync();

    return JsonSerializer.Deserialize<Address>(result);
  }
}