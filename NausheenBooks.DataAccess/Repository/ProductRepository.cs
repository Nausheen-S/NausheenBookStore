using NausheenBooks.DataAccess.Repository.IRepository; //adding using statements
using NausheenBooks.Models;
using NausheenBookStore.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NausheenBooks.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //implemet removes error
        public void Update(Product product)
        {
            //throw new NotImplementedException();
            var objFromDb = _db.Products.FirstOrDefault(s => s.ProductId == product.ProductId);
            if (objFromDb != null)
            {
                if(product.ImageUrl != null)
                {
                    objFromDb.ImageUrl = product.ImageUrl;
                }
                objFromDb.Title = product.Title;
                objFromDb.Description = product.Description;
                objFromDb.ISBN = product.ISBN;
                objFromDb.Author = product.Author;
                objFromDb.ListPrice = product.ListPrice;
                objFromDb.CategoryId = product.CategoryId;
                objFromDb.CoverTypeId = product.CoverTypeId;
                /*_db.SaveChanges();*/ //removed after adding void save in unit of work
            }
        }
    }
}
