using BlazorServerDemo.Data.Infrastructure;
namespace BlazorServerDemo.Data;


public class LocationService
{
    public LocationService(IMongoCRUD<Location> locationRepo)
    {
        LocationRepo = locationRepo;
    }

    public IMongoCRUD<Location> LocationRepo { get; }

    public async Task<Location[]> GetLocationAsync()
    {
        var locations = await this.LocationRepo.GetAll();

        if (locations==null || !locations.Any())
        {
            List<Location> toEnter = new List<Location>()
            {
                new Location(){StreetName="Besos", StreetNumber =17},
                new Location(){StreetName="Besos", StreetNumber =17},
                new Location(){StreetName="Reyes", StreetNumber =287},

            };

            foreach (var item in toEnter)
            {
                await this.LocationRepo.Create(item);
            }
            locations = await this.LocationRepo.GetAll();
            
        }
        return locations.ToArray();
    }

    public async Task DeleteLocationAsync(string id)
    {
        await this.LocationRepo.Delete(id);
    }

    public async Task SaveLocationAsync(Location entity)
    {
        await this.LocationRepo.Create(entity);
    }

    public async Task<Location> GetLocationById(string id)
    {
        return await this.LocationRepo.GetById(id);
    }
}
