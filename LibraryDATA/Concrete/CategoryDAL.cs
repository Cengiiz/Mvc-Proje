using LibraryDAL.Abstract;
using LibraryDAL.Entities;
using LibraryDAL.Entities.Repository.EF.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Core.StatusEnum;

namespace LibraryDAL.Concrete
{
    public class CategoryDAL : IBaseDAL<Category>
    {
        private Connection _db = new Connection();
        public void Add(Category t)
        {
            _db.Categories.Add(t);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _db.Categories.Find(id);
            category.Status = (int?)Status.Deleted;
            _db.SaveChanges();
        }

        public Category Get(Expression<Func<Category, bool>> filter = null)
        {
            if (filter == null)
            {
                throw new Exception();
            }

            return _db.Categories.FirstOrDefault(filter);
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            if (filter != null)
            {
                return _db.Categories.Where(filter).ToList();
            }
            else
            {
                return _db.Categories.ToList();
            }
        }

        public IQueryable<Category> GetQueryable()
        {
            return _db.Categories.AsQueryable();
        }

        public void Update(Category t)
        {
            var category = _db.Categories.Find(t.CategoryId);
            category.CategoryName = t.CategoryName;
            category.Status = t.Status;
            _db.SaveChanges();
        }
    }
}
