using LibraryBLL.Abstract;
using LibraryDAL.Abstract;
using LibraryDAL.Concrete;
using LibraryDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Core.StatusEnum;

namespace LibraryBLL.Concrete
{
    public class BookManager : IBookManager<Book>
    {
        IBaseDAL<Book> bookDal = new BookDAL();
        public void Add(Book t)
        {
            List<Book> books = bookDal.GetAll();
            foreach (var item in books)
            {
                if (item.Name == t.Name)
                {
                    item.Status = (int?)Status.Active;
                    bookDal.Update(item);
                    return;
                }

            }
            bookDal.Add(t);
        }

        public void Delete(int id)
        {
            bookDal.Delete(id);
        }

        public List<Book> GetAll(Expression<Func<Book, bool>> filter = null)
        {
            return bookDal.GetAll(filter);
        }

        public List<Book> GetbySearchkey(string search,int statu)
        {
            if (string.IsNullOrEmpty(search))
            {
                return bookDal.GetAll(x => x.Status >= statu);
            }
            else
            {
                search = search.ToLower();
                return bookDal.GetAll(x => x.Name.ToLower().Contains(search)&&x.Status>=statu);
            }
        }
        public Book GetbyId(int id)
        {
            return bookDal.Get(x => x.Identity==id);
        }


        public void Update(Book t)
        {
            bookDal.Update(t);
        }
    }
}
