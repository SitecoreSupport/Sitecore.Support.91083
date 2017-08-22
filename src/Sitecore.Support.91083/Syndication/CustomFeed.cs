namespace Sitecore.Support.Syndication
{
  using Sitecore.Data.Items;
  using Sitecore.Syndication;
  using System.Collections.Generic;
  using System.Linq;
  public class CustomFeed : PublicFeed
  {
    // Methods
    public override IEnumerable<Item> GetSourceItems()
    {
      List<Item> list = base.GetSourceItems().ToList<Item>();
      List<Item> list2 = new List<Item>();
      foreach (Item item in list)
      {
        Item item2 = Context.Database.GetItem(item.ID, Context.Language);
        if ((item2 == null) || (item2.Versions.Count == 0))
        {
          list2.Add(item);
        }
      }
      foreach (Item item in list2)
      {
        list.Remove(item);
      }
      return list;
    }
  }


}