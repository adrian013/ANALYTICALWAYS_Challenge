namespace AcmeSchool.Persistence
{
    /// <summary>
    /// Provides a base class for an entity supporting logical deletion.
    /// </summary>
    public class DeletableEntity : Entity, IDeletable
    {
        public bool Deleted { get; set; }
    }
}
