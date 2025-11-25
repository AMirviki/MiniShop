using Domain.Common;

public sealed class ProductPrice : ValueObject
{
    public decimal  Value { get; private set; }

    private ProductPrice(decimal value)
    {
        Value = value;  
    }

    public static ProductPrice Create(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("Cant Be Under 0");
        return new ProductPrice(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
