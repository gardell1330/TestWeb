using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Data.Repository
{
    public class DbRepository<T> : IRepository<T> where T : class
    {
        DbContext db;
        DbSet<T> entity;

        public DbRepository(DbContext _context)
        {
            db = _context;
            entity = db.Set<T>();
        }

        public bool Add(T _entity)
        {
            var addEntity = entity.Add(_entity);
            return Validate(addEntity);
        }

        public bool AddAll(IEnumerable<T> listEntity)
        {
            var addEntity = entity.AddRange(listEntity);
            return Validate(addEntity);
        }

        public int Commit()
        {
           return db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var deleteEntity = entity.Remove(entity.Find(id));
            return !Validate(deleteEntity);
        }

        public bool DeleteAll(IEnumerable<T> listEntity)
        {
            var deleteEntity = entity.RemoveRange(listEntity);
            return !Validate(deleteEntity);
        }

        public T Fetch(int id)
        {
            return entity.Find(id);
        }

        public IQueryable<T> FetchAll()
        {
            return entity;
        }        

        private bool Validate(T addEntity)
        {            
            if (Commit() == 0) return false;
            return entity.Any(r => r == addEntity);
        }

        private bool Validate(IEnumerable<T> addEntity)
        {            
            if (Commit() == 0) return false;
            return entity.Any(r => r == addEntity);
        }
    }
}
