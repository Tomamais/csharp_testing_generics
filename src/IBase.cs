public interface IBase<PKType> 
{
    PKType ID { get; }

    string Name { get; }
}