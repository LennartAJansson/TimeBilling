namespace TimeBilling.Domain.Abstract;

using System.Linq.Expressions;

using TimeBilling.Model;

public interface IGenericRepository<TEntity> where TEntity: Entity
{
    IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                string includeProperties = "");

    TEntity GetById(object id);
    void Insert(TEntity entity);
    void Update(TEntity entity);
    int DeleteById(object id);
    void Delete(TEntity entity);
}
