using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Data.DataModel;
using WebApplication1.Data.Repository;

namespace WebApplication1.Data
{
    public class DataManager
    {
        public DbRepository<User> userRepo;
        public DbRepository<Client> clientRepo;

        public DataManager()
        {
            userRepo = new DbRepository<User>(new EntityDb<User>());
            clientRepo = new DbRepository<Client>(new EntityDb<Client>());
        }
    }
}
