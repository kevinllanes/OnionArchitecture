using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using OnionArchitecture.Core.DomainModels.Common;

namespace OnionArchitecture.Data
{
    public interface IEntitiesContext : IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        void SetAsAdded<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void SetAsModified<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void SetAsDeleted<TEntity>(TEntity entity) where TEntity : BaseEntity;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
