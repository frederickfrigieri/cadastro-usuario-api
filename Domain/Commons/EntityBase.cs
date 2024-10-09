namespace Domain.Commons
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }
        public DateTimeOffset CreatedAt { get; protected set; }
        public DateTimeOffset UpdatedAt { get; protected set; }
        public bool Active { get; protected set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Active = true;
        }

        public void Deactivate()
        {
            Active = false;
            UpdatedAt = DateTime.Now;
        }

        protected static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken()) throw new DomainException(rule.Message);
        }

    }
}
