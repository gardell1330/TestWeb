using System.Data.Entity;

namespace WebApplication1.Data.Repository
{
    public class EntityDb<T> : DbContext where T: class
    {
        DbSet<T> entity { get; set; }
    }
}