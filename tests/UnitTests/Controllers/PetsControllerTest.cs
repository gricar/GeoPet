using System.Net;
using GeoPet.Controllers;
using GeoPet.DTOs;
using GeoPet.Enums;
using GeoPet.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTests.Controllers;

public class PetsControllerTest
{
  [Fact]
  public async void Given_Called_When_Valid_Then_Get_List_Pets_Sucess()
  {
    //arrange
    PetDTO pet = new()
    {
      Name = "Totó",
      Age = 3,
      Size = PetSizesEnum.Medium,
      Breed = PetBreedsEnum.Bulldog,
    };
    List<PetDTO> pets = new()
    {
      pet
    };

    Mock<IPetsService> mock = new();
    mock.Setup(x => x.GetAll()).Returns(Task.FromResult(pets.AsEnumerable()));
    PetsController petsController = new(mock.Object);

    //act
    var petsResponses = await petsController.GetAll();

    //assert
    mock.Verify(x => x.GetAll(), Times.Once);
    petsResponses.As<ObjectResult>().Value.As<List<PetDTO>>().Should().HaveCount(1);
    petsResponses.As<ObjectResult>().StatusCode.Should().Be((int)HttpStatusCode.OK);
  }

  [Theory]
  [InlineData(2)]
  public async void Given_Called_When_Valid_Then_Get_Pet_Sucess(int id)
  {
    //arrange
    var pet = new PetDTO();
    Mock<IPetsService> mock = new();
    mock.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(pet));
    var petsController = new PetsController(mock.Object);
    //act
    var petResponse = await petsController.GetById(id);
    //assert
    mock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
    petResponse.As<ObjectResult>().Value.As<PetDTO>().Should().Be(pet);
  }

  [Fact]
  public async void Given_Called_When_Valid_Then_Get_Add_Pet_Sucess()
  {
    //arrange
    var createPetDTO = new CreatePetDTO();
    Mock<IPetsService> mock = new();
    mock.Setup(x => x.Add(createPetDTO)).Returns(Task.CompletedTask);
    var petsController = new PetsController(mock.Object);
    //act
    var actionResult = await petsController.Add(createPetDTO);
    var okResult = actionResult.As<OkResult>();
    //assert
    mock.Verify(x => x.Add(createPetDTO), Times.Once);
    okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
  }

  [Fact]
  public async void Given_Called_When_Valid_Then_Get_Update_Pet_Sucess()
  {
    //arrange
    CreatePetDTO createPetDTO = new();
    Mock<IPetsService> mock = new();
    mock.Setup(x => x.Update(createPetDTO)).Returns(Task.CompletedTask);
    var petsController = new PetsController(mock.Object);

    //act
    var actionResult = await petsController.Add(createPetDTO);
    var okResult = actionResult.As<OkResult>();

    //assert
    mock.Verify(x => x.Update(createPetDTO), Times.Once);
    okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
  }
}