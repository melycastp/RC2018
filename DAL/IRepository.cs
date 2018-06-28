using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL
{
    public interface IRepository<TEntity>:IDisposable where TEntity:class
    {
        TEntity Create(TEntity toCreate);
        bool Delete(TEntity toDelete);
        bool Update(TEntity toUpate);
        TEntity Retrieve(Expression<Func<TEntity, bool>> criteria);

        List<TEntity> Filter(Expression<Func<TEntity, bool>> criteria);

        List<TEntity> FilterOrder(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, string>> criteria2);
        List<TEntity> FilterOrder(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, decimal>> criteria2);
        List<TEntity> FilterOrder(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, DateTime>> criteria2);
        List<TEntity> FilterOrder(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, int>> criteria2);
        List<TEntity> FilterOrder(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, long>> criteria2);

        List<TEntity> FilterOrderDescending(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, DateTime>> criteria2);
        List<TEntity> FilterOrderTwoCriterias(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, int>> criteria2, Expression<Func<TEntity, DateTime>> criteria3);
        List<TEntity> FilterOrderTwoCriterias(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, string>> criteria2, Expression<Func<TEntity, int>> criteria3);
        List<TEntity> FilterOrderTwoCriterias(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, string>> criteria2, Expression<Func<TEntity, string>> criteria3);
        List<TEntity> FilterOrderTwoCriterias(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, string>> criteria2, Expression<Func<TEntity, DateTime>> criteria3);
        List<TEntity> FilterOrderTwoCriterias(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, int>> criteria2, Expression<Func<TEntity, int>> criteria3);

        List<TEntity> RetrieveAllOrder(Expression<Func<TEntity, string>> criteria);
        List<TEntity> RetrieveAllOrder(Expression<Func<TEntity, int>> criteria);
        List<TEntity> RetrieveOrderTwoCriterias(Expression<Func<TEntity, int>> criteria, Expression<Func<TEntity, string>> criteria2);

        int TotalRegisters(Expression<Func<TEntity, bool>> criteria);
        int TotalRegisters();
        bool Exist(Expression<Func<TEntity, bool>> critera);
    }
}
