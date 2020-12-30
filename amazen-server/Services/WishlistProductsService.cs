using System;
using System.Collections.Generic;
using amazen_server.Models;
using amazen_server.Repositories;

namespace amazen_server.Services
{
  public class WishlistProductsService
  {

    private readonly WishlistProductsRepository _repo;

    public WishlistProductsService(WishlistProductsRepository repo)
    {
      _repo = repo;
    }

    public WishlistProduct Create(WishlistProduct newWp)
    {
      newWp.Id = _repo.Create(newWp);
      return newWp;
    }

    internal IEnumerable<Product> GetProductsByWishlistId(int wishlistId)
    {
      return _repo.GetProductsByWishlistId(wishlistId);

    }

    internal string Delete(int id, string userId)
    {
      WishlistProduct original = _repo.Get(id);
      if (original == null) { throw new Exception("Bad Id"); }
      if (original.CreatorId != userId)
      {
        throw new Exception("Not the User : Access Denied");
      }
      if (_repo.Remove(id))
      {
        return "deleted succesfully";
      }
      return "did not remove succesfully";
    }
  }
}