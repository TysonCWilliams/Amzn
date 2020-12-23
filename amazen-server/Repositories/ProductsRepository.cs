using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using amazen_server.Models;

namespace amazen_server.Repositories
{
  public class ProductsRepository
  {
    private readonly IDbConnection _db;
    private readonly string populateCreator = "SELECT product.*, profile.* FROM products product INNER JOIN profiles profile ON product.creatorId = profile.id ";

    public ProductsRepository(IDbConnection db)
    {
      _db = db;
    }
    public int Create(Product newProduct)
    {
      string sql = @"
            INSERT INTO products 
            (title, body, picture, isPublished, creatorId)
            VALUES
            (@Title, @Body, @Picture, @isPublished, @CreatorId);
            SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newProduct);
    }

    internal IEnumerable<Product> getProductsByProfile(string profId)
    {
      string sql = @"
        SELECT
        product.*,
        p.*
        FROM products product
        JOIN profiles p ON product.creatorId = p.id
        WHERE product.creatorId = @profId; ";
      return _db.Query<Product, Profile, Product>(sql, (product, profile) => { product.Creator = profile; return product; }, new { profId }, splitOn: "id");
    }

    internal Product GetOne(int id)
    {
      string sql = @"SELECT * from products WHERE id = @id";
      return _db.QueryFirstOrDefault<Product>(sql, new { id });
    }

    internal void Edit(Product editData)
    {
      string sql = @"
        UPDATE products
        SET
        title = @Title,
        body = @Body,
        picture = @Picture,
        isPublished = @IsPublished,
        WHERE id = @Id;";
      _db.Execute(sql, editData);
    }

    public IEnumerable<Product> Get()
    {
      string sql = populateCreator + "WHERE isPublished = 1";
      return _db.Query<Product, Profile, Product>(sql, (product, profile) => { product.Creator = profile; return product; }, splitOn: "id");
    }
  }
}