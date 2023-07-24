public class ConcreteLong: IBase<long>
{
    public long ID { get; set; }

    public string Name {get; set; }

    public ConcreteLong(long ID, string Name)
    {
        this.ID = ID;
        this.Name = Name;
    }
}