using YourProjectName.Core.Entities;
using YourProjectName.Core.Interfaces;
using YourProjectName.Infrastructure.Persistence;

namespace YourProjectName.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
            }

            var repository = new GenericRepository<TEntity>(_context);

            _repositories.Add(typeof(TEntity), repository);
            return repository;

        }
        public async Task<int> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }
    }
}
