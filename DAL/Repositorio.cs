using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Repositorio<TEntity> : IRepository<TEntity> where TEntity : class
    {
        RCasillasDBEntities Context = null;
        private DbSet<TEntity> EntitySet
        {
            get
            {
                return Context.Set<TEntity>();
            }
        }

        public Repositorio()
        {
            Context = new RCasillasDBEntities();
            Context.Configuration.ProxyCreationEnabled = false;
        }

        public TEntity Create(TEntity toCreate)
        {
            TEntity Result = null;
            try
            {
                EntitySet.Add(toCreate);
                Context.SaveChanges();
                Result = toCreate;
            }
            catch
            {
                throw;
            }
            return Result;
        }

        public bool CreateRange(IEnumerable<TEntity> entities)
        {
            bool Result = false;
            try
            {
                EntitySet.AddRange(entities);
                Context.SaveChanges();
                Result = true;
            }
            catch
            {
                throw;
            }
            return Result;
        }

        public bool Delete(TEntity toDelete)
        {
            bool Result = false;
            try
            {
                //Adjunta la entidad determinada al contexto que subyace al conjunto. Es decir, 
                //la entidad se coloca en el contexto en estado Unchanged, como si se hubiera leído de la base de datos
                EntitySet.Attach(toDelete);
                EntitySet.Remove(toDelete);
                Result = Context.SaveChanges() > 0;

            }
            catch
            {
                throw;
            }
            return Result;
        }

        public bool Update(TEntity toUpate)
        {
            bool Result = false;
            try
            {
                EntitySet.Attach(toUpate);
                Context.Entry<TEntity>(toUpate).State = EntityState.Modified;
                Result = Context.SaveChanges() > 0;
            }
            catch
            {
                throw;
            }
            return Result;
        }

        public TEntity Retrieve(Expression<Func<TEntity, bool>> critera)
        {
            TEntity Result = null;
            try
            {
                Result = EntitySet.FirstOrDefault(critera);
            }
            catch
            {
                throw;
            }
            return Result;
        }

        public List<TEntity> Filter(Expression<Func<TEntity, bool>> criteria)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.Where(criteria).ToList();
            }
            catch
            {
                throw;
            }
            return Result;

        }


        public List<TEntity> FilterOrder(Expression<Func<TEntity, bool>> criteria,
            Expression<Func<TEntity, string>> criteria2)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.Where(criteria).OrderBy(criteria2).ToList();
            }
            catch
            {
                throw;
            }
            return Result;

        }

        public List<TEntity> FilterOrder(Expression<Func<TEntity, bool>> criteria,
            Expression<Func<TEntity, decimal>> criteria2)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.Where(criteria).OrderBy(criteria2).ToList();
            }
            catch
            {
                throw;
            }
            return Result;

        }

        public List<TEntity> FilterOrder(Expression<Func<TEntity, bool>> criteria,
            Expression<Func<TEntity, DateTime>> criteria2)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.Where(criteria).OrderBy(criteria2).ToList();
            }
            catch
            {
                throw;
            }
            return Result;

        }

        public List<TEntity> FilterOrderDescending(Expression<Func<TEntity, bool>> criteria,
            Expression<Func<TEntity, DateTime>> criteria2)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.Where(criteria).OrderByDescending(criteria2).ToList();
            }
            catch
            {
                throw;
            }
            return Result;

        }

        public List<TEntity> FilterOrderDescending(Expression<Func<TEntity, bool>> criteria,
            Expression<Func<TEntity, string>> criteria2)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.Where(criteria).OrderByDescending(criteria2).ToList();
            }
            catch
            {
                throw;
            }
            return Result;

        }

        public List<TEntity> FilterOrderTwoCriterias(Expression<Func<TEntity, bool>> criteria,
            Expression<Func<TEntity, int>> criteria2,
            Expression<Func<TEntity, DateTime>> criteria3)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.Where(criteria).OrderBy(criteria2).ThenBy(criteria3).ToList();
            }
            catch
            {
                throw;
            }
            return Result;

        }

        public List<TEntity> FilterOrderTwoCriterias(Expression<Func<TEntity, bool>> criteria,
            Expression<Func<TEntity, string>> criteria2,
            Expression<Func<TEntity, int>> criteria3)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.Where(criteria).OrderBy(criteria2).ThenBy(criteria3).ToList();
            }
            catch
            {
                throw;
            }
            return Result;

        }



        public List<TEntity> FilterOrderTwoCriterias(Expression<Func<TEntity, bool>> criteria,
           Expression<Func<TEntity, string>> criteria2,
           Expression<Func<TEntity, string>> criteria3)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.Where(criteria).OrderBy(criteria2).ThenBy(criteria3).ToList();
            }
            catch
            {
                throw;
            }
            return Result;

        }

        public List<TEntity> FilterOrder(Expression<Func<TEntity, bool>> criteria,
            Expression<Func<TEntity, int>> criteria2)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.Where(criteria).OrderBy(criteria2).ToList();
            }
            catch
            {
                throw;
            }
            return Result;

        }

        public List<TEntity> FilterOrder(Expression<Func<TEntity, bool>> criteria,
            Expression<Func<TEntity, long>> criteria2)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.Where(criteria).OrderBy(criteria2).ToList();
            }
            catch
            {
                throw;
            }
            return Result;

        }


        public List<TEntity> FilterOrderTwoCriterias(Expression<Func<TEntity, bool>> criteria,
            Expression<Func<TEntity, string>> criteria2,
            Expression<Func<TEntity, DateTime>> criteria3)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.Where(criteria).OrderBy(criteria2).ThenBy(criteria3).ToList();
            }
            catch
            {
                throw;
            }
            return Result;

        }

        public List<TEntity> FilterOrderTwoCriterias(Expression<Func<TEntity, bool>> criteria,
            Expression<Func<TEntity, int>> criteria2, Expression<Func<TEntity, int>> criteria3)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.Where(criteria).OrderBy(criteria2).ThenBy(criteria3).ToList();
            }
            catch
            {
                throw;
            }
            return Result;

        }

        public List<TEntity> RetrieveAll()
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.ToList();
            }
            catch
            {
                throw;
            }
            return Result;
        }

        public List<TEntity> RetrieveAllOrder(Expression<Func<TEntity, string>> criteria)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.OrderBy(criteria).ToList();
            }
            catch
            {
                throw;
            }
            return Result;
        }

        public List<TEntity> RetrieveAllOrderDescending(Expression<Func<TEntity, string>> criteria)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.OrderByDescending(criteria).ToList();
            }
            catch
            {
                throw;
            }
            return Result;
        }

        public List<TEntity> RetrieveAllOrderDescending(Expression<Func<TEntity, DateTime>> criteria)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.OrderByDescending(criteria).ToList();
            }
            catch
            {
                throw;
            }
            return Result;
        }

        public List<TEntity> RetrieveAllOrder(Expression<Func<TEntity, int>> criteria)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.OrderBy(criteria).ToList();
            }
            catch
            {
                throw;
            }
            return Result;
        }

        public List<TEntity> RetrieveOrderTwoCriterias(
            Expression<Func<TEntity, int>> criteria,
            Expression<Func<TEntity, string>> criteria2
            )
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.OrderBy(criteria).ThenBy(criteria2).ToList();
            }
            catch
            {
                throw;
            }
            return Result;

        }


        public int TotalRegisters(Expression<Func<TEntity, bool>> criteria)
        {
            int Result = 0;
            try
            {
                Result = EntitySet.Count(criteria);
            }
            catch
            {
                throw;
            }
            return Result;

        }

        public int TotalRegisters()
        {
            int Result = 0;
            try
            {
                Result = EntitySet.Count();
            }
            catch
            {
                throw;
            }
            return Result;

        }


        public bool Exist(Expression<Func<TEntity, bool>> critera)
        {
            TEntity entity = null;
            bool Result = false;
            try
            {
                entity = EntitySet.FirstOrDefault(critera);
                if (entity != null)
                {
                    Result = true;
                }
            }
            catch
            {
                throw;
            }
            return Result;
        }
        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }

    }
}
