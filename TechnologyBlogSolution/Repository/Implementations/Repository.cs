using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Repository.Contracts;

namespace TechnologyBlogSolution.Repository.Implementations
{
    public class Repository<TEntity> 
        : IRepository<TEntity>
        where TEntity : class
    {
        public TechnologyBlogDbContext DbContext;

        public Repository(TechnologyBlogDbContext technologyBlogDbContext)
        {
            this.DbContext = technologyBlogDbContext;
        }

        private DbSet<TEntity> EntitiesDbSet => this.DbContext.Set<TEntity>();

        public void Add(TEntity entity)
        {
            this.EntitiesDbSet.Add(entity);   
        }

        public void Delete(TEntity entity)
        {
            this.EntitiesDbSet.Remove(entity);
        }

        public void Dispose()
        {
            this.DbContext.Dispose();
        }

        public void Update(TEntity entity)
        {
            this.DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Commit()
        {
            this.DbContext.SaveChanges();
            this.Dispose();
        }
    }
}