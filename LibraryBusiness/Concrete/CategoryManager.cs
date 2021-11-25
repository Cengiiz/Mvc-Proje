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
    public class CategoryManager : ICategoryManager<Category>
    {
        IBaseDAL<Category> categoryDAL = new CategoryDAL();
        IBaseDAL<Book> bookDal = new BookDAL();
        public void Add(Category t)
        {
            List<Category> ctgr = categoryDAL.GetAll();
            foreach (var item in ctgr)
            {
                if (item.CategoryName == t.CategoryName)
                {
                    item.Status = (int?)Status.Active;
                    categoryDAL.Update(item);
                    return;
                }

            }
            categoryDAL.Add(t);
        }

        public void Delete(int id)
        {
            categoryDAL.Delete(id);
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {

            return categoryDAL.GetAll(filter);
        }

        public List<Category> GetbySearchkey(string search,int statu)
        {
            if(string.IsNullOrEmpty(search))
            {
                return categoryDAL.GetAll(x => x.Status >= statu);
            }
            else
            {
                return categoryDAL.GetAll(x => x.CategoryName.ToLower().Contains(search)&&x.Status>=statu);
            }
            
        }
        public Category GetbyId(int id)
        {
            return categoryDAL.Get(x => x.CategoryId == id);
        }

        public void Update(Category t)
        {
            categoryDAL.Update(t);
        }

        public List<Book> GetbyBook(int id)
        {
            return bookDal.GetAll(x => x.CategoryIdentity == id).ToList(); ;
        }
    }
}
