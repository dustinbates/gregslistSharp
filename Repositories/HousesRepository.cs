namespace gregslistSharp.Repositories
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
  using gregslistSharp.Models;

  public class HousesRepository
    {
        private readonly IDbConnection _db;

        public HousesRepository(IDbConnection db)
        {
            _db = db;
        }

    internal List<House> FindAll()
    {
      string sql = @"
      SELECT
      *
      FROM houses;
      ";
      List<House> houses = _db.Query<House>(sql).ToList();
      return houses;
    }

    internal House FindOne(int id)
    {
      string sql = @"
      SELECT 
      *
      FROM houses
      WHERE id = @id;
      ";
      House house = _db.Query<House>(sql, new { id }).FirstOrDefault();
      return house;
    }

    internal House Create(House houseData)
    {
      string sql = @"
      INSERT INTO houses
      (bedrooms, bathrooms, year, levels, imgUrl, description, price)
      VALUES
      (@bedrooms, @bathrooms, @year, @levels, @imgUrl, @description, @price);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, houseData);
      houseData.Id = id;
      return houseData;
    }

    internal bool Remove(int id)
    {
      string sql = @"
      DELETE FROM houses WHERE id = @id;
      ";
      int rows = _db.Execute(sql, new { id });
      return rows == 1;
    }

    internal int Update(House update)
    {
      string sql = @"
      UPDATE houses
      SET
      bedrooms = @bedrooms,
      bathrooms = @bathrooms,
      year = @year,
      levels = @levels,
      imgUrl = @imgUrl,
      description = @description,
      price = @price
      WHERE id = @id;
      ";
      int rows = _db.Execute(sql, update);
      return rows;
    }
  }
}