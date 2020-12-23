using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using amazen_server.Models;
using amazen_server.Repositories;

namespace amazen_server.Services
{
  public class ProductsService
  {
    private readonly ProductsRepository _repo;

    public ProductsService(ProductsRepository repo)
    {
      _repo = repo;
    }
    public Product Create(Product newProduct)
    {
      newProduct.Id = _repo.Create(newProduct);
      return newProduct;
    }

    public IEnumerable<Product> Get()
    {
      return _repo.Get();
    }

    internal IEnumerable<Product> GetProductsByProfile(string profId, string userId)
    {
      return _repo.getProductsByProfile(profId).ToList().FindAll(p => p.CreatorId == userId || p.IsPublished);
    }

    internal Product Edit(Product editData, string userId)
    {
      Product original = _repo.GetOne(editData.Id);
      if (original == null) { throw new Exception("Bad Id"); }
      if (original.CreatorId != userId)
      {
        throw new Exception("Not the User : Access Denied");
      }
      _repo.Edit(editData);

      return _repo.GetOne(editData.Id);

    }
  }
}