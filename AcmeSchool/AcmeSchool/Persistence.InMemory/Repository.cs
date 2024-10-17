using Microsoft.EntityFrameworkCore;

namespace AcmeSchool.Persistence.InMemory
{
    public class Repository<T, TContext> : IRepository<T>, IUnitOfWork
          where T : Entity
          where TContext : DbContext
    {
        private readonly TContext _context;

        public Repository(TContext context)
        {
            _context = context;
        }

        public TContext Context => _context;

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public T GetById(Guid id)
        {
            return _context.Find<T>(id);
        }

        public void Update(T entity)
        {
            _context.Attach(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}