using LibraryDAL.Entities.Repository.EF.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Abstract
{
    public interface IBaseDAL<T>
    {
        
        IQueryable<T> GetQueryable();
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
        void Add(T t);
        void Update(T t);
        void Delete(int id); 
    }
}
