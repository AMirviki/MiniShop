using Domain.Common;

namespace Domain.Products;

public class Product : AggregateRoot<Guid>
{
    public Guid CategoryId { get; private set; }
    public ProductPrice Price { get; private set; }
    public ProductName Name { get; private set; }
    public DescriptionProduct Description { get; private set; }

    private Product() { }

    private Product(Guid id, ProductName name, ProductPrice price , DescriptionProduct description, Guid categoryId) : base(id)
    {
        CategoryId = categoryId;
        Name = name;
        Description = description;
        Price = price;
    }


    public static Product Create(ProductName name , ProductPrice price , DescriptionProduct description , Guid categoryId)
    {
        if (categoryId == Guid.Empty)
            throw new ArgumentException("CategoryId Cant Be Empty");

        return new Product(Guid.NewGuid() , name , price , description , categoryId);
    }


    public void ChangePrice(decimal newPrice)
    {
        Price =  ProductPrice.Create(newPrice);
    }

    public void ChangeName(string name)
    {
        Name =  ProductName.Create(name);
    }

    public void ChangeDescription(string description) 
    {
        Description =  DescriptionProduct.Create(description);
    }


}
