using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using VibrantData.Models;
using System.Linq.Expressions;
using Syncfusion.EJ2.Base;

namespace VibrantCore
{
    public class Repository<T>: IRepository<T> where T : class
    {
        private VibrantContext _dbContext;
        internal DbSet<T> _dbSet;

        public Repository(VibrantContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = _dbContext.Set<T>();
        }

        public T getSingleData(Expression<Func<T, bool>> whereCondition)
        {
            try
            {
                return _dbSet.Where(whereCondition).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<T> getAllData()
        {
            try
            {
                return _dbSet.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IQueryable<T> getQueryableAllData()
        {
            try
            {
                return _dbSet.AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IQueryable<T> getQueryableData(Expression<Func<T, bool>> whereCondition)
        {
            try
            {
                return _dbSet.Where(whereCondition).AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<T> findData(Expression<Func<T, bool>> whereCondition)
        {
            try
            {
                return _dbSet.Where(whereCondition).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool create(T dataObj)
        {
            try
            {
                _dbSet.Add(dataObj);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        public bool update(T dataObj)
        {
            try
            {
                _dbSet.Update(dataObj);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        public bool delete(T dataObj)
        {
            try
            {
                _dbSet.Remove(dataObj);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        public bool deleteRange(IList<T> dataObj)
        {
            try
            {
                _dbSet.RemoveRange(dataObj);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Exists(Expression<Func<T, bool>> whereCondition)
        {
            try
            {
                return _dbSet.Any(whereCondition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
