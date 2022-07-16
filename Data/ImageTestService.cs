using BlazorServerDemo.Data.Infrastructure;
namespace BlazorServerDemo.Data;


public class ImageTestService
{
    public ImageTestService(IMongoCRUD<ImageTest> locationRepo)
    {
        ImageTestRepo = locationRepo;
    }

    public IMongoCRUD<ImageTest> ImageTestRepo { get; }

    public async Task<ImageTest[]> GetImageTestAsync()
    {
        var locations = await this.ImageTestRepo.GetAll();

        if (locations==null || !locations.Any())
        {
            List<ImageTest> toEnter = new List<ImageTest>()
            {
                new ImageTest(){ImageDescription="Code", Base64img =LoadImageFromDisk(1)},
                new ImageTest(){ImageDescription="Google", Base64img =LoadImageFromDisk(2)},
                new ImageTest(){ImageDescription="Waterfall", Base64img =LoadImageFromDisk(3)},

            };

            foreach (var item in toEnter)
            {
                await this.ImageTestRepo.Create(item);
            }
            locations = await this.ImageTestRepo.GetAll();
            
        }
        return locations.ToArray();
    }

    private string LoadImageFromDisk(int id)
    {
        string static_dir = @"/wwwroot/images";
        string imageDirectory = $"{Directory.GetCurrentDirectory()}{static_dir}";
        var files = Directory.GetFiles(imageDirectory);
        List<string> imagesPath = new List<string>();
        


        foreach(var imgPath in files)
        {
            imagesPath.Add(imgPath);
        }

        string? selected = imagesPath.FirstOrDefault(im =>im.Contains(id.ToString()));

        Byte[] bytes = File.ReadAllBytes(selected);
        String fileb64 = Convert.ToBase64String(bytes);
        return fileb64;
    }

    public async Task DeleteImageTestAsync(string id)
    {
        await this.ImageTestRepo.Delete(id);
    }

    public async Task SaveImageTestAsync(ImageTest entity)
    {
        await this.ImageTestRepo.Create(entity);
    }

    public async Task<ImageTest> GetImageTestById(string id)
    {
        return await this.ImageTestRepo.GetById(id);
    }

    public async Task UpdateImageTestAsync(string id, ImageTest entity)
    {
        await this.ImageTestRepo.Update(id,entity);
    }
}
