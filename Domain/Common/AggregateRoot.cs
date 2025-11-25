namespace Domain.Common;

public abstract class AggregateRoot<Tid> : Entity<Tid>
{
    protected AggregateRoot() : base() { }

    protected AggregateRoot(Tid id) : base(id)
    {
        
    }



}
