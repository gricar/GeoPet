using GeoPet.Enums;

namespace GeoPet.DTOs;

public class PetDTO
{
  public int Id { get; set; }
  public string Name { get; set; } = default!;
  public int Age { get; set; } = default!;
  public PetSizesEnum Size { get; set; } = default!;
  public PetBreedsEnum Breed { get; set; } = default!;
  public bool IsLost { get; set; } = false;
  public string SitterName { get; set; } = default!;
}

public class CreatePetDTO
{
  public int Id { get; set; }
  public string Name { get; set; } = default!;
  public int Age { get; set; } = default!;
  public PetSizesEnum Size { get; set; } = default!;
  public PetBreedsEnum Breed { get; set; } = default!;
  public int SitterId { get; set; }
}