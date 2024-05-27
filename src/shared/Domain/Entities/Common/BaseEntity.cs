namespace shared.Domain.Entities.Common
{
    public abstract class BaseEntity<TId>
    {
        protected BaseEntity()
        {

        }

        protected BaseEntity(TId id)
        {
            Id = id;
        }

        public TId Id { get; private set; }
    }
}


