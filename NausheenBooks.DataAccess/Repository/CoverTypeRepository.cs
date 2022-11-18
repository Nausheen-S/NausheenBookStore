using NausheenBooks.DataAccess.Repository.IRepository; //adding using statements
using NausheenBooks.Models;
using NausheenBookStore.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NausheenBooks.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //implemet removes error
        public void Update(CoverType covertype)
        {
            //throw new NotImplementedException();
            var objFromDb = _db.CoverTypes.FirstOrDefault(s => s.CoverTypeId == covertype.CoverTypeId);
            if (objFromDb != null)
            {
                objFromDb.CoverTypeName = covertype.CoverTypeName;
                /*_db.SaveChanges();*/ //removed after adding void save in unit of work
            }
        }
    }
}
