using OnionArchitecture.Core.DomainModels.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        void Dispose(bool disposing);
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
  
    }
}
