using System;
using System.Collections.Generic;
using System.Text;

namespace NausheenBooks.DataAccess.Repository.IRepository
{
    //base class is IDisposable
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }

        ISP_Call SP_Call { get; }
    }
}
