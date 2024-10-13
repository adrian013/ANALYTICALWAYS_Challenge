namespace AcmeSchool.Persistence
{
    /// <summary>
    /// Provides a base class for an auditable entity, providing fields to track
    /// who and when created and updated an entity.
    /// </summary>
    public class AuditableEntity : Entity, IAuditable
    {
        public Guid CreatedBy { get; protected set; }
        public DateTimeOffset CreatedOn { get; protected set; }
        public Guid? UpdatedBy { get; protected set; }
        public DateTimeOffset? UpdatedOn { get; protected set; }
    }
}
