using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace DLL
{
    public class UsersModel : DbContext
    {
        // Your context has been configured to use a 'UsersModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DLL.UsersModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'UsersModel' 
        // connection string in the application configuration file.
        public UsersModel()
            : base("name=UsersModel")
        {
            Database.SetInitializer(new UserModelInitializer());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}