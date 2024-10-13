namespace AcmeSchool.Persistence
{
    /// <summary>
    /// Specifies the contract for an auditable entity, providing fields to track
    /// who and when created and updated an entity.
    /// </summary>
    public interface IAuditable
    {
        /// <summary>
        /// User id that created the entity.
        /// </summary>
        Guid CreatedBy { get; }

        /// <summary>
        /// Date and time the entity was created.
        /// </summary>
        DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// User id that last updated the entity.
        /// </summary>
        Guid? UpdatedBy { get; }

        /// <summary>
        /// Date and time the entity was last updated.
        /// </summary>
        DateTimeOffset? UpdatedOn { get; }
    }
}
