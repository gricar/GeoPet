using GeoPet.Models;

namespace GeoPet.Repository.Interfaces;


public interface IAddressRepository
{
  Task<Address?> GetById(int id);
  Task<int> Add(Address pet);
}