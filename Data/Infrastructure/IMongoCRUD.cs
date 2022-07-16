namespace BlazorServerDemo.Data.Infrastructure;

public interface IMongoCRUD<T> where T: IIdentifiable
{
    Task<IEnumerable<T>> GetAll();

    Task<T> GetById(string id);

    Task Create(T entity);

    Task Update(string id, T entity);
    Task Delete(string id);

       
}