using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DbLayer.Interfaces {

    public interface IUnitOfWork : IDisposable {
        DbSet<TEntity> Set<TEntity> () where TEntity : class;

        void AddRange<TEntity> (IEnumerable<TEntity> entities) where TEntity : class;
        void RemoveRange<TEntity> (IEnumerable<TEntity> entities) where TEntity : class;

        EntityEntry<TEntity> Entry<TEntity> (TEntity entity) where TEntity : class;
        void MarkAsChanged<TEntity> (TEntity entity) where TEntity : class;

        // object GetShadowPropertyValue (object entity, string propertyName);
        // T GetShadowPropertyValue<T> (object entity, string propertyName) where T : IConvertible;

        // void ExecuteSqlCommand (string query);
        // void ExecuteSqlCommand (string query, params object[] parameters);

        int SaveChanges ();
        int SaveChanges (bool acceptAllChangesOnSuccess);

        Task<int> SaveChangesAsync (CancellationToken cancellationToken = new CancellationToken ());
        Task<int> SaveChangesAsync (bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken ());
    }
}