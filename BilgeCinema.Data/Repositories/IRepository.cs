using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BilgeCinema.Data.Repositories
{
    public interface IRepository<TEntity>
       where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        TEntity GetById(int id);

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        // ^ Bir sql sorgusu'nu parametre olarak göndereceksek

        // = null diyerek, bir parametre verilmesi zorunluluğunu ortadan kaldırıyorum.

        TEntity Get(Expression<Func<TEntity, bool>> predicate);

    }
}
