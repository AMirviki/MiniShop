using Domain.Common;

public class CategoryName : ValueObject
{
    public string Name { get; private set; }

    private CategoryName()
    {
        
    }

    private CategoryName(string name)
    {
        Name = name;
    }

    public static CategoryName Create(string name)
    {
        if(string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name Cant Be Empty");

        return new CategoryName(name);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }
}
