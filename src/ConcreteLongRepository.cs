public class ConcreteLongRepository : IRepository<ConcreteLong, long>
{
    private IList<ConcreteLong> data;

    public ConcreteLongRepository()
    {
        this.data = new List<ConcreteLong>();
    }

    public void Add(ConcreteLong entity)
    {
        if (entity != null && this.GetById(entity.ID) == null)
        {
            this.data.Add(entity);
        }
    }

    public void Remove(ConcreteLong entity)
    {   
        if (entity == null) return;

        var toBeRemoved = this.GetById(entity.ID);

        if (toBeRemoved != null)
        {
            this.data.Remove(toBeRemoved);
        }
    }

    public void Update (ConcreteLong entity)
    {
        if (entity == null) return;

        var toBeUpdated = this.GetById(entity.ID);

        if (toBeUpdated != null)
        {
            this.Remove(toBeUpdated);
            this.Add(entity);
        }
    }

    public IList<ConcreteLong> GetAll()
    {
        return this.data;
    }

    public ConcreteLong? GetById(long ID)
    {
        return this.data.FirstOrDefault(x => x.ID == ID);
    }
}