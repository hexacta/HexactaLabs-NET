using HexactaLabs_MVC.Business.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HexactaLabs_MVC.Persistence.Common
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MoviesContext Context;

        public Repository(MoviesContext context)
        {
            this.Context = context;
        }

        protected IDbSet<T> Entities
        {
            get
            {
                return this.Context.Set<T>();
            }
        }

        public virtual void Save(T entity)
        {
            this.Entities.Add(entity);

            this.Context.SaveChanges();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return this.Entities.Where(predicate).ToList();
        }

        public virtual IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return this.Entities.Where(predicate);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.Entities.ToList();
        }

        public virtual T First(Expression<Func<T, bool>> predicate)
        {
            return this.Entities.Where(predicate).FirstOrDefault();
        }

        public virtual T Find(params object[] keyValues)
        {
            return this.Entities.Find(keyValues);
        }

        public virtual void Update(T entity)
        {
            this.Context.Entry(entity).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            this.Context.Entry(entity).State = EntityState.Deleted;
            this.Context.SaveChanges();
        }

        public virtual void Detach(T entity)
        {
            this.Context.Entry(entity).State = EntityState.Detached;
        }
    }

}
