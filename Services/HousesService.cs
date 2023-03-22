using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gregslistSharp.Services
{
  public class HousesService
  {

    private readonly HousesRepository _repo;

    public HousesService(HousesRepository repo)
    {
        _repo = repo;
    }
    internal List<House> Find()
    {
      List<House> houses = _repo.FindAll();
      return houses;
    }

    internal House Find(int id)
    {
      House house = _repo.FindOne(id);
      if(house == null) throw new Exception($"No house at id: {id}");
      return house;
    }

    internal House Create(House houseData)
    {
        House house = _repo.Create(houseData);
        return house;
    }

    internal string Remove(int id)
    {
      House house = this.Find(id);
      bool result = _repo.Remove(id);
      if (!result) throw new Exception($"removing this house  at id {house.Id} did not work");
      return "removed house";
    }

    internal House Update(House updateData)
    {
      House original = this.Find(updateData.Id);
      original.Bedrooms = updateData.Bedrooms != 0 ? updateData.Bedrooms : original.Bedrooms;
      original.Bathrooms = updateData.Bathrooms != 0 ? updateData.Bathrooms : original.Bathrooms;
      original.Year = updateData.Year != 0 ? updateData.Year : original.Year;
      original.Levels = updateData.Levels != 0 ? updateData.Levels : original.Levels;
      original.ImgUrl = updateData.ImgUrl != null ? updateData.ImgUrl : original.ImgUrl;
      original.Description = updateData.Description != null ? updateData.Description : original.Description;
      original.Price = updateData.Price != 0 ? updateData.Price : original.Price;
      int rowsAffected = _repo.Update(original);
      if (rowsAffected == 0) throw new Exception($"Could not modify house at id: {updateData.Id}");
      if (rowsAffected > 1) throw new Exception("You really broke it now dawg");
      return original;
    }
  }
}