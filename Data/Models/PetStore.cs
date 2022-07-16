using BlazorServerDemo.Data.Infrastructure;

namespace BlazorServerDemo.Data;

[BsonCollectionAttribute("PetStore")]
public class PetStore:IIdentifiable
{
    public string? Id { get;set; }

    public string? StoreName { get; set; }
    public int FoundationYear { get; set; }

    public string? StoreLocationId { get; set; }
}
