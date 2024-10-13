namespace AcmeSchool.Persistence.InMemory
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
