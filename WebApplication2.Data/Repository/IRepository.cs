using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public interface IRepository<T>
    {
        bool Add(T entity);
        bool AddAll(IEnumerable<T> listEntity);

        T Fetch(int id);
        IQueryable<T> FetchAll();

        bool Delete(int id);
        bool DeleteAll(IEnumerable<T> listEntity);
        
        int Commit();
    }
}
