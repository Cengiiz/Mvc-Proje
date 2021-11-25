using LibraryDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBLL.Abstract
{
    interface IAuthorManager<Author>
    {
        List<Author> GetAll(Expression<Func<Author, bool>> filter = null);
        List<Author> GetbySearchkey(string search,int statu=0);
        List<Book> GetbyBook(int id);
        Author GetbyId(int id);
        void Add(Author t);
        void Update(Author t);
        void Delete(int id);
    }
}
