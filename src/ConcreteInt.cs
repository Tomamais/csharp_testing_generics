public class ConcreteInt: IBase<int>
{
    public int ID { get; set; }

    public string Name {get; set; }

    public ConcreteInt(int ID, string Name)
    {
        this.ID = ID;
        this.Name = Name;
    }
}