using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologyBlogSolution.Repository.Contracts
{
    interface IRepository<TEntity> : IDisposable
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        void Commit();
    }
}
