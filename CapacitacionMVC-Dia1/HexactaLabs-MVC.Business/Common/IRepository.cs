using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HexactaLabs_MVC.Business.Common
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        void Save(T entity);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> Where(Expression<Func<T, bool>> predicate);

        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

        T First(Expression<Func<T, bool>> predicate);

        T Find(params object[] keyValues);

        void Detach(T entity);
    }
}
