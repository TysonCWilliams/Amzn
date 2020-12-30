using System;
using System.Collections;
using System.Collections.Generic;
using amazen_server.Models;
using amazen_server.Repositories;

namespace amazen_server.Services
{
  public class WishlistsService
  {
    private readonly WishlistsRepository _repo;

    public WishlistsService(WishlistsRepository repo)
    {
      _repo = repo;
    }

    public Wishlist Create(Wishlist newWishlist)
    {
      newWishlist.Id = _repo.Create(newWishlist);
      return newWishlist;
    }

    public IEnumerable<Wishlist> Get()
    {
      return _repo.Get();
    }
  }
}