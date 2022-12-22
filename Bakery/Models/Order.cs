using System.Collections.Generic;

namespace Bakery.Models
{
  public class Order
  {
    public string Description { get; set; }
    public string BreadCount { get; set; }
    public string PastryCount { get; set; }
    public string Date { get; set; }
    public int Price { get; set; }
    public int Id { get; }
    private static List<Order> _instances = new List<Order> { };

    public Order(string description = "", string breadCount = "0", string pastryCount = "0", string date = "1/1/1970")
    {
      Description = description;
      BreadCount = breadCount;
      PastryCount = pastryCount;
      Date = date;
      _instances.Add(this);
      Id = _instances.Count;
      Price = Order.OrderPrice(breadCount, pastryCount);
    }

    public static List<Order> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Order Find(int searchId)
    {
      return _instances[searchId-1];
    }
    public static int OrderPrice(string breadCount, string pastryCount)
    {
      int intBreadCount = int.Parse(breadCount);
      int intPastryCount = int.Parse(pastryCount);
      int breadPrice = ((intBreadCount/3) * 10) + (intBreadCount%3)*5;
      int pastryPrice = ((intPastryCount/3) * 5) + (intPastryCount%3)*2;
      return (breadPrice + pastryPrice);
    }
  }
}
