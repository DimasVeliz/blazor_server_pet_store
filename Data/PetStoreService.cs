using BlazorServerDemo.Data.Infrastructure;
namespace BlazorServerDemo.Data;


public class PetStoreService
{
    public PetStoreService(IMongoCRUD<PetStore> PetStoreRepo)
    {
        this.PetStoreRepo = PetStoreRepo;
    }

    public IMongoCRUD<PetStore> PetStoreRepo { get;}

    public async Task<PetStore[]> GetPetStoreAsync()
    {
        var PetStores = await this.PetStoreRepo.GetAll();

        if (PetStores==null || !PetStores.Any())
        {
            List<PetStore> toEnter = new List<PetStore>()
            {
                new PetStore(){StoreName="Tiny Paw", FoundationYear =2021},
                new PetStore(){StoreName="AnimalPlanet", FoundationYear =2022},
                new PetStore(){StoreName="KindTale", FoundationYear =2019},

            };

            foreach (var item in toEnter)
            {
                await this.PetStoreRepo.Create(item);
            }
            PetStores = await this.PetStoreRepo.GetAll();
            
        }
        return PetStores.ToArray();
    }

    public async Task DeletePetStoreAsync(string id)
    {
        await this.PetStoreRepo.Delete(id);
    }

    public async Task SavePetStoreAsync(PetStore entity)
    {
        await this.PetStoreRepo.Create(entity);
    }

    public async Task<PetStore> GetPetStoreById(string id)
    {
        return await this.PetStoreRepo.GetById(id);
    }
}
