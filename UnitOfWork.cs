using System;
using System.Collections.Generic;
using System.Text;

using VibrantData.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace VibrantCore
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly VibrantContext _dbContext;

        public UnitOfWork(IConfiguration config)
        {
            this._dbContext = new VibrantContext(config);
        }

        public VibrantContext dbContext
        {
            get { return _dbContext; }
        }

        public bool complete()
        {
            using (var objTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.SaveChanges();
                    objTransaction.Commit();
                    return true;
                }
                catch(Exception ex)
                {
                    objTransaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task completeAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            this.Dispose();
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }
    }
}
