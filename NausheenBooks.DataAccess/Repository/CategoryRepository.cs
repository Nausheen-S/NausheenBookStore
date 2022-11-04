using NausheenBooks.DataAccess.Repository.IRepository; //adding using statements
using NausheenBooks.Models;
using NausheenBookStore.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NausheenBooks.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //implemet removes error
        public void Update(Category category)
        {
            //throw new NotImplementedException();
            var objFromDb = _db.Categories.FirstOrDefault(s => s.CategoryId == category.CategoryId);
            if(objFromDb != null)
            {
                objFromDb.CategoryName = category.CategoryName;
                _db.SaveChanges();
            }
        }
    }
}
