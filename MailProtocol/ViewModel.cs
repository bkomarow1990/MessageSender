using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailProtocol
{
    public class ViewModel
    {
        public string Server { get; set; } = "smtp.gmail.com"; // sets the server address
        public int Port { get; set; } = 587;
        //int port = 587;//int.Parse(ConfigurationManager.AppSettings["gmail_port"]); //sets the server port
        public User LoginedUser { get; set; }
        public UsersModel UsersModel { get; set; }
        //User loginedUser;
        //UsersModel userModel = new UsersModel();
        public ViewModel()
        {
            UsersModel = new UsersModel();
        }
    }
}
