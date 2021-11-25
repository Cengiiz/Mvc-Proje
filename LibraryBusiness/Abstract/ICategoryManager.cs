using LibraryDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBLL.Abstract
{
    interface ICategoryManager<Category>
    {
        List<Category> GetAll(Expression<Func<Category, bool>> filter = null);
        List<Category> GetbySearchkey(string search,int statu=0);
        List<Book> GetbyBook(int id);
        Category GetbyId(int id);
        void Add(Category t);
        void Update(Category t);
        void Delete(int id);
    }
}
