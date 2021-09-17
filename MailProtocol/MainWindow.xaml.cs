using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailProtocol
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel viewModel = new ViewModel();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.UsersModel.Users.Where((el)=>el.Login == loginTxtBox.Text).First() == null)
            {
                MessageBox.Show("Incorrect Login");
                return;
            }
            User tmpUser = viewModel.UsersModel.Users.Where((el) => el.Login == loginTxtBox.Text).First();
            if (tmpUser.Password != passwordPasswdBox.Password)
            {
                MessageBox.Show("Incorrect Password");
                return;
            }
            viewModel.LoginedUser = tmpUser;
            MailForm mailForm = new MailForm(viewModel);
            this.Hide();
            mailForm.Show();

        }
    }
}
