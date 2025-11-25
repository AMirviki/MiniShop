using Domain.Common;

public sealed class DescriptionProduct : ValueObject
{
    public string Description { get; private set; }

    private DescriptionProduct(string desc)
    {
        Description = desc;
    }

    public static DescriptionProduct Create(string desc)
    {
       if(string.IsNullOrWhiteSpace(desc))
            throw new ArgumentException(nameof(desc)  , "Cant Be Empty");
        return new DescriptionProduct(desc);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Description;
    }
}
