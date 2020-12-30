using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using amazen_server.Models;

namespace amazen_server.Repositories
{
  public class WishlistsRepository
  {
    private readonly IDbConnection _db;
    // private readonly string populateCreator = "SELECT product.*, profile.* FROM products product INNER JOIN profiles profile ON product.creatorId = profile.id ";

    public WishlistsRepository(IDbConnection db)
    {
      _db = db;
    }
    public int Create(Wishlist newWishlist)
    {
      string sql = @"
            INSERT INTO wishlists 
            (name, address)
            VALUES
            (@Name, @Address);
            SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newWishlist);
    }

    public IEnumerable<Wishlist> Get()
    {
      string sql = "SELECT * from wishlists";
      return _db.Query<Wishlist>(sql);
    }
  }
}