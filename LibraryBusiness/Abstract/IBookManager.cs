using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBLL.Abstract
{
    interface IBookManager<Book>
    {
        List<Book> GetAll(Expression<Func<Book, bool>> filter = null);
        List<Book> GetbySearchkey(string search,int statu=0);
        Book GetbyId(int id);
      
        void Add(Book t);
        void Update(Book t);
        void Delete(int id);
    }
}
