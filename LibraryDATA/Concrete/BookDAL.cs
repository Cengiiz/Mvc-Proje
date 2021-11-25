using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LibraryDAL.Abstract;
using LibraryDAL.Entities;
using LibraryDAL.Entities.Repository.EF.MSSQL;
using static Core.StatusEnum;

namespace LibraryDAL.Concrete
{
    public class BookDAL : IBaseDAL<Book>
    {
        private Connection _db = new Connection();
        public void Add(Book t)
        {          
            _db.Books.Add(t);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var books = _db.Books.Find(id);
            books.Status = (int?)Status.Deleted;
            _db.SaveChanges();
        }

        public Book Get(Expression<Func<Book, bool>> filter = null)
        {
            if (filter == null)
            {
                throw new Exception();
            }

            return _db.Books.FirstOrDefault(filter);
        }

        public List<Book> GetAll(Expression<Func<Book, bool>> filter = null)
        {
            if (filter != null)
            {
                return _db.Books.Where(filter).ToList();
            }
            else
            {
                return _db.Books.ToList();
            }
        }

        public IQueryable<Book> GetQueryable()
        {
            return _db.Books.AsQueryable();
        }


        public void Update(Book t)
        {
            var book = _db.Books.Find(t.Identity);
            book.Name = t.Name;
            book.StockQuantity = t.StockQuantity;
            book.PublishYear = t.PublishYear;
            book.Authorldentity = t.Authorldentity;
            book.CategoryIdentity = t.CategoryIdentity;
            _db.SaveChanges();
        }
    }
}
