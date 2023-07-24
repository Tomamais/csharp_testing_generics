namespace tests;

public class ConcreteIntRepositoryTests
{
    [Fact]
    public void Should_Create_Instance()
    {
        var repository = new ConcreteIntRepository();
        repository.Should().NotBeNull();
    }

    [Fact]
    public void Should_Create_Instance_With_Empty_Data()
    {
        var repository = new ConcreteIntRepository();
        var data = repository.GetAll();
        data.Should().NotBeNull();
        data.Count().Should().Be(0);
    }

    [Fact]
    public void Should_Add_A_Valid_Instance_Into_Set()
    {
        var repository = new ConcreteIntRepository();
        var toBeAdded = new ConcreteInt(1, nameof(ConcreteInt));
        repository.Add(toBeAdded);
        var data = repository.GetAll();
        data.Count().Should().Be(1);
        data.First().ID.Should().Be(1);
    }

    [Fact]
    public void Should_GetById_Properly() 
    {
        var repository = new ConcreteIntRepository();
        repository.Add(new ConcreteInt(1, "Concrete 1"));
        repository.Add(new ConcreteInt(2, "Concrete 2"));

        var concrete1 = repository.GetById(1);
        concrete1.Should().NotBeNull();
        concrete1.ID.Should().Be(1);

        var concrete2 = repository.GetById(2);
        concrete2.Should().NotBeNull();
        concrete2.ID.Should().Be(2);

        var concrete3 = repository.GetById(3);
        concrete3.Should().BeNull();
    }

    [Fact]
    public void Should_GetAll_Reflect_The_List_State()
    {
        var repository = new ConcreteIntRepository();
        repository.Add(new ConcreteInt(1, "Concrete 1"));
        repository.Add(new ConcreteInt(2, "Concrete 2"));

         var data = repository.GetAll();
        data.Count().Should().Be(2);

        repository.Remove(new ConcreteInt(2, "Concrete 2"));

        data = repository.GetAll();
        data.Count().Should().Be(1);
    }

    [Fact]
    public void Should_Remove_A_Valid_Instance_From_Set()
    {
        var repository = new ConcreteIntRepository();

        repository.Add(new ConcreteInt(1, "Concrete 1"));
        repository.Add(new ConcreteInt(2, "Concrete 2"));
        
        var data = repository.GetAll();
        data.Count().Should().Be(2);

        repository.Add(new ConcreteInt(3, "Concrete 3"));

        data = repository.GetAll();
        data.Count().Should().Be(3);

        repository.Remove(new ConcreteInt(2, "Concrete 2"));

        data = repository.GetAll();
        data.Count().Should().Be(2);

        repository.Remove(new ConcreteInt(1, "Concrete 1"));

        data = repository.GetAll();
        data.Count().Should().Be(1);

        repository.Remove(new ConcreteInt(3, "Concrete 3"));

        data = repository.GetAll();
        data.Count().Should().Be(0);

        repository.Remove(new ConcreteInt(3, "Concrete 3"));

        data = repository.GetAll();
        data.Count().Should().Be(0);
    }

    [Fact]
    public void Should_Not_Remove_NotFound_Instances()
    {
        var repository = new ConcreteIntRepository();

        repository.Add(new ConcreteInt(1, "Concrete 1"));
        repository.Add(new ConcreteInt(2, "Concrete 2"));
        
        var data = repository.GetAll();
        data.Count().Should().Be(2);

        repository.Remove(new ConcreteInt(3, "Concrete 3"));

        data = repository.GetAll();
        data.Count().Should().Be(2);
    }

    [Fact]
    public void Should_Update_Instance_Properly()
    {
        var repository = new ConcreteIntRepository();

        repository.Add(new ConcreteInt(1, "Concrete 1"));
        repository.Add(new ConcreteInt(2, "Concrete 2"));

        var itemBeforeUpdate = repository.GetById(1);
        itemBeforeUpdate.Name.Should().Be("Concrete 1");

        repository.Update(new ConcreteInt(1, "Super Concrete 1"));

        var itemAfterUpdate = repository.GetById(1);
        itemAfterUpdate.Name.Should().Be("Super Concrete 1");
    }
}