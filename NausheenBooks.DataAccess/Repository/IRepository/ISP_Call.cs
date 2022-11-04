using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NausheenBooks.DataAccess.Repository.IRepository
{
    public interface ISP_Call : IDisposable
    {
        //first col, first row
        T Single<T>(string procedurename, DynamicParameters param = null);
        //execute only. no retrieving
        void Execute(string procedurename, DynamicParameters param = null);
        //one row
        T OneRecord<T>(string procedurename, DynamicParameters param = null);
        //all rows
        IEnumerable<T> List<T>(string procedurename, DynamicParameters param = null);
        //2 tables
        Tuple<IEnumerable<T1>,IEnumerable<T2>> List<T1, T2>(string procedurename, DynamicParameters param = null);
    }
}
