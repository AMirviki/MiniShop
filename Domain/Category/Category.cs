using Domain.Common;

namespace Domain.Category;

public class Category : AggregateRoot<Guid>
{
    public CategoryName Name { get; private set; }
    private Category()
    {
        
    }

    private Category(CategoryName name , Guid id) : base(id)
    {
        Name = name;
    }

    public static Category Create(CategoryName name)
    {
        return new Category(name , Guid.NewGuid()); 
    }


}
