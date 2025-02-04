namespace CatálogoDeProductos.Services;

internal interface IRepositoryService<T>
{
    public T Get(int id);
    public IEnumerable<T> GetAll();
    public void Add(T item);
    public void Delete(T item);
    public void Update(T item);

}
