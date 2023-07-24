public class ConcreteIntRepository: IRepository<ConcreteInt, int>
{
    private IList<ConcreteInt> data;

    public ConcreteIntRepository()
    {
        this.data = new List<ConcreteInt>();
    }

    public void Add(ConcreteInt entity)
    {
        if (entity != null && this.GetById(entity.ID) == null)
        {
            this.data.Add(entity);
        }
    }

    public void Remove(ConcreteInt entity)
    {   
        if (entity == null) return;

        var toBeRemoved = this.GetById(entity.ID);

        if (toBeRemoved != null)
        {
            this.data.Remove(toBeRemoved);
        }
    }

    public void Update (ConcreteInt entity)
    {
        if (entity == null) return;

        var toBeUpdated = this.GetById(entity.ID);

        if (toBeUpdated != null)
        {
            this.Remove(toBeUpdated);
            this.Add(entity);
        }
    }

    public IList<ConcreteInt> GetAll()
    {
        return this.data;
    }

    public ConcreteInt? GetById(int ID)
    {
        return this.data.FirstOrDefault(x => x.ID == ID);
    }
}