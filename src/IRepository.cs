public interface IRepository<T, PKType> where T: IBase<PKType>
{
    void Add(T entity);

    void Remove(T entity);

    void Update (T entity);

    IList<T> GetAll();

    T? GetById(PKType ID);
}