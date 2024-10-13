namespace AcmeSchool.Persistence
{
    /// <summary>
    /// Specifies the contract for a entity having an unique identifier.
    /// </summary>
    public interface IIdentifiable
    {
        /// <summary>
        /// Unique entity identifier.
        /// </summary>
        Guid Id { get; }
    }
}
