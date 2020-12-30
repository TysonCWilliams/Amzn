namespace amazen_server.Models
{
  public class Product
  {
    public string Title { get; set; }
    public string Body { get; set; }
    public string Picture { get; set; }
    public bool IsPublished { get; set; }
    public int Id { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
  }

  public class WishlistProductViewModel : Product
  {
    public int WishlistProductId { get; set; }
  }
}