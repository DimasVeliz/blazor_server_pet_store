using BlazorServerDemo.Data.Infrastructure;

namespace BlazorServerDemo.Data;

[BsonCollectionAttribute("ImageTest")]
public class ImageTest:IIdentifiable
{
    public string? Id { get;set; }
    public string? ImageDescription { get; set; }
    public string? Base64img { get; set; }
}