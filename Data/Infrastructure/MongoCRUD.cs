using MongoDB.Bson;
using MongoDB.Driver;

namespace BlazorServerDemo.Data.Infrastructure;

public class MongoCRUD<T> : IMongoCRUD<T> where T : IIdentifiable
{
    public IMongoCollection<T> collection { get; set; }

    public MongoCRUD(IMongoSettings settings)
    {
        var connectionString = settings.BuildConnectionString();
        var client = new MongoClient(connectionString);
        var dataBase = client.GetDatabase(settings.DataBaseName);
        this.collection = dataBase.GetCollection<T>(GetCollectionName(typeof(T)));
    }

    private string? GetCollectionName(Type documentType)
    {
        BsonCollectionAttribute? result = (BsonCollectionAttribute)documentType
                            .GetCustomAttributes(typeof(BsonCollectionAttribute), true)
                            .First();

        return !string.IsNullOrEmpty(result?.CollectionName) ? result?.CollectionName : throw new Exception("Class without Table annotation");
    }

    public async Task Delete(string id)
    {
        var filter = Builders<T>.Filter.Eq(doc => doc.Id, id);

        try
        {
            await collection.FindOneAndDeleteAsync(filter);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        var result = await collection.FindAsync(new BsonDocument());

        return await result.ToListAsync();
    }

    public async Task<T> GetById(string id)
    {
        var filter = Builders<T>.Filter.Eq(doc => doc.Id, id);
        return await collection.Find(filter).SingleOrDefaultAsync();
    }

    public async Task Create(T entity)
    {
        try
        {
            entity.Id = entity.Id == null ? Guid.NewGuid().ToString() : entity.Id;
            await collection.InsertOneAsync(entity);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task Update(string id, T replacement)
    {
        var filter = Builders<T>.Filter.Eq(doc => doc.Id, replacement.Id);
        try
        {
            await collection.FindOneAndReplaceAsync(filter, replacement);

        }
        catch (Exception)
        {
            throw;
        }
    }
}
