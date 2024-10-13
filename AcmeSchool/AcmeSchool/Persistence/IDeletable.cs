namespace AcmeSchool.Persistence
{
    /// <summary>
    /// Specifies the contract for an entity supporting logical deletion.
    /// </summary>
    public interface IDeletable
    {
        /// <summary>
        /// Indicates whether the entity is deleted or not.
        /// </summary>
        bool Deleted { get; set; }
    }
}
