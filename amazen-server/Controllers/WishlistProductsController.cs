using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using amazen_server.Models;
using amazen_server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace amazen_server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WishlistProductsController : ControllerBase
  {
    private readonly WishlistProductsService _wps;

    public WishlistProductsController(WishlistProductsService wps)
    {
      _wps = wps;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<WishlistProduct>> Post([FromBody] WishlistProduct newWp)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newWp.CreatorId = userInfo.Id;
        return Ok(_wps.Create(newWp));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_wps.Delete(id, userInfo.Id));
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);

      }
    }

  }
}