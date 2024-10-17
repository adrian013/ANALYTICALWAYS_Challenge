namespace AcmeSchool.Persistence
{
    /// <summary>
    /// Specifies the contract for a generic repository providing basic get by id, add,
    /// update and delete methods.
    /// </summary>
    /// <typeparam name="T">The entity type for the repository.</typeparam>
    public interface IRepository<T> where T : IEntity, IIdentifiable
    {
        /// <summary>
        /// Fetches and returns the entity identified by <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the entity to retrieve.</param>
        /// <returns>The entity identified by id, null if it does not exist.</returns>
        T GetById(Guid id);

        /// <summary>
        /// Adds an entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        void Add(T entity);

        /// <summary>
        /// Updates an entity and marks it as modified.
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
    }
}
