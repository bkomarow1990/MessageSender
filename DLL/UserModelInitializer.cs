using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class UserModelInitializer : CreateDatabaseIfNotExists<UsersModel>
    {
        protected override void Seed(UsersModel context)
        {
            context.Users.Add(new User { Login= "Admin", Password="admin"});
            context.SaveChanges();
            base.Seed(context); 
        }
    }
}
