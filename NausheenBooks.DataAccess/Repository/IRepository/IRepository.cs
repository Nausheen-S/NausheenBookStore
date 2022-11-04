using System;
using System.Collections.Generic;
using System.Text;
//add additional dependencies
using System.Linq;
using System.Linq.Expressions;

namespace NausheenBooks.DataAccess.Repository.IRepository
{
    //added information regarding irepository . make sure to keep public to avoid accessibility errors
    public interface IRepository<T> where T : class
    {
        //get category based on id
        T Get(int CategoryId);

        //all categories based on requirements
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
        );

        //get default or first
        T GetFirstOrDefault(
             Expression<Func<T, bool>> filter = null,
             string includeProperties = null
        );

        //add entity
        void Add(T entity);

        //remove object or category
        void Remove(int CategoryId);

        //remove obj
        void Remove(T entity);

        //remove entity range
        void RemoveRange(IQueryable<T> entity);
    }
}
