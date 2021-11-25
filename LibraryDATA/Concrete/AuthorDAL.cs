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
    public class AuthorDAL : IBaseDAL<Author>
    {
        private Connection _db = new Connection();
        public void Add(Author t)
        {         
            _db.Authors.Add(t);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var authr = _db.Authors.Find(id);
            authr.Status = (int?)Status.Deleted;
            _db.SaveChanges();
        }

        public Author Get(Expression<Func<Author, bool>> filter = null)
        {
            if (filter == null)
            {
                throw new Exception();
            }

            return _db.Authors.FirstOrDefault(filter);
        }

        public List<Author> GetAll(Expression<Func<Author, bool>> filter = null)
        {
            if (filter != null)
            {
                return _db.Authors.Where(filter).ToList();
            }
            else
            {
                return _db.Authors.ToList();
            }
        }

        public IQueryable<Author> GetQueryable()
        {
            return _db.Authors.AsQueryable();
        }

        public void Update(Author t)
        {
            var autr = _db.Authors.Find(t.AuthorsId);
            autr.Name = t.Name;
            autr.Surname = t.Surname;
            _db.SaveChanges();

        }

        
    }
}
