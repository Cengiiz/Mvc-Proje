using LibraryBLL.Abstract;
using LibraryDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDAL.Concrete;
using LibraryDAL.Abstract;
using System.Linq.Expressions;
using static Core.StatusEnum;

namespace LibraryBLL.Concrete
{
    public class AuthorManager : IAuthorManager<Author>
    {
        IBaseDAL<Author> authorDal = new AuthorDAL();
        IBaseDAL<Book> bookDal = new BookDAL();
        public void Add(Author t)
        {
            List<Author> author = authorDal.GetAll();
            foreach (var item in author)
            {
                if (item.Name == t.Name && item.Surname == t.Surname)
                {
                    item.Status = (int?)Status.Active;
                    authorDal.Update(item);
                    return;
                }

            }
            authorDal.Add(t);
        }

        public void Delete(int t)
        {
            authorDal.Delete(t);
        }

        public List<Author> GetbySearchkey(string search,int statu)
        {
            if (string.IsNullOrEmpty(search))
            {
                return authorDal.GetAll(x => x.Status >= statu);
            }
            else
            {
                search = search.ToLower().Trim();
                return authorDal.GetAll(x => (x.Name.ToLower().Contains(search)||x.Surname.ToLower().Contains(search))&&x.Status>=statu);
            }
        }
        public Author GetbyId(int id)
        {
            return authorDal.Get(x => x.AuthorsId == id);
        }
        public List<Author> GetAll(Expression<Func<Author, bool>> filter = null)
        { 
            return authorDal.GetAll(filter);
        }

        public void Update(Author t)
        {
            authorDal.Update(t);
        }

        public List<Book> GetbyBook(int id)
        {
            return bookDal.GetAll(x => x.Authorldentity == id).ToList(); ;
            
        }
    }
}
