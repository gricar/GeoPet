using GeoPet.DTOs;
using GeoPet.Models;

namespace GeoPet.Rest.Interfaces;

public interface INominatinRest
{
  Task<AddressLocationDTO?> GetAdressByLatLon(string lat, string lon);
}
