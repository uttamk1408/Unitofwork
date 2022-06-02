using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VibrantData.Models;

namespace VibrantCore
{
    public interface IUnitOfWork : IDisposable
    {
        VibrantContext dbContext { get; }        
        bool complete();
        Task completeAsync();
    }
}
