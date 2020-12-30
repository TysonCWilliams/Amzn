using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using amazen_server.Models;
using amazen_server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace amazen_server_Wishlistgr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WishlistsController : ControllerBase
  {
    private readonly WishlistsService _ws;
    private readonly WishlistProductsService _wps;
    public WishlistsController(WishlistsService ws, WishlistProductsService wps)
    {
      _ws = ws;
      _wps = wps;
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Wishlist> Create([FromBody] Wishlist newWishlist)
    {
      try
      {
        Wishlist created = _ws.Create(newWishlist);
        return Ok(created);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Wishlist>> Get()
    {
      try
      {
        return Ok(_ws.Get());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{wishlistId}/wishlistproducts")]
    public ActionResult<IEnumerable<Product>> Get(int wishlistId)
    {
      try
      {
        return Ok(_wps.GetProductsByWishlistId(wishlistId));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}