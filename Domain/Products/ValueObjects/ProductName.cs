using Domain.Common;

public sealed class ProductName : ValueObject
{
    public string Name { get; private set; }

    private ProductName(string name)
    {
        Name = name;
    }

    public static ProductName Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name Cant Be Empty");

        return new ProductName(name);

    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }
}
