using NausheenBooks.DataAccess.Repository.IRepository;//get repo
using NausheenBookStore.DataAccess.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore; //for db
using Microsoft.Data.SqlClient; //for sql connection

namespace NausheenBooks.DataAccess.Repository
{
    public class SP_Call : ISP_Call
    {
        private readonly ApplicationDbContext _db;
        private static string ConnectionString = ""; //to call stored procedure

        //constructor to open sql connection
        public SP_Call(ApplicationDbContext db) 
        {
            _db = db;
            ConnectionString = db.Database.GetDbConnection().ConnectionString;
        }
        public void Dispose()
        {
            /*throw new NotImplementedException();*/
            _db.Dispose();
        }

        public void Execute(string procedurename, DynamicParameters param = null)
        {
           using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                sqlCon.Execute(procedurename, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T> List<T>(string procedurename, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procedurename, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedurename, DynamicParameters param = null)
        {
            throw new NotImplementedException();
        }

        public T OneRecord<T>(string procedurename, DynamicParameters param = null)
        {
            throw new NotImplementedException();
        }

        public T Single<T>(string procedurename, DynamicParameters param = null)
        {
            throw new NotImplementedException();
        }
    }
}
