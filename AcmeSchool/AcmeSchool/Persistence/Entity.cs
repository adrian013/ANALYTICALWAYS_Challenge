namespace AcmeSchool.Persistence
{
    /// <summary>
    /// Provides a base class for an identifiable entity.
    /// </summary>
    public class Entity : IEntity, IIdentifiable
    {
        public Guid Id { get; set; }
    }
}
