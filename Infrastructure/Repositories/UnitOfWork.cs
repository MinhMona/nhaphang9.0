using Domain.Entities.DomainEntities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected IAppDbContext _appDbContext;

        public UnitOfWork(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            if (_appDbContext != null)
            {
                _appDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                _appDbContext.ChangeTracker.AutoDetectChangesEnabled = false;
            }
        }
        public async Task<bool> Complete()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public IQueryRepository QueryRepository()
        {
            return new QueryRepository(_appDbContext);
        }

        public IDomainRepository<E> Repository<E>() where E : BaseEntity
        {
            return new DomainRepository<E>(_appDbContext);
        }
    }
}
