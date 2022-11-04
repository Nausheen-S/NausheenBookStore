using NausheenBooks.Models; //added using statement
using System;
using System.Collections.Generic;
using System.Text;

namespace NausheenBooks.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}
