using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace VibrantCore
{
    public interface IRepository<T> where T : class
    {        
        T getSingleData(Expression<Func<T, bool>> whereCondition);
        IList<T> getAllData();
        IQueryable<T> getQueryableAllData();
        IQueryable<T> getQueryableData(Expression<Func<T, bool>> whereCondition);
        IList<T> findData(Expression<Func<T, bool>> whereCondition);
        bool create(T dataObj);
        bool update(T dataObj);
        bool delete(T dataObj);
        bool deleteRange(IList<T> dataObj);
        bool Exists(Expression<Func<T, bool>> whereCondition);        
    }
}
