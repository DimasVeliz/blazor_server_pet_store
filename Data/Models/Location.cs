using BlazorServerDemo.Data.Infrastructure;

namespace BlazorServerDemo.Data;

[BsonCollectionAttribute("Location")]
public class Location:IIdentifiable
{
    public string? Id { get;set; }

    public int StreetNumber { get; set; }

    public string? StreetName { get; set; }
}
