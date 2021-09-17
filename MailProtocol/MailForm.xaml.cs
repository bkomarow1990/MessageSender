using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MailProtocol
{
    /// <summary>
    /// Interaction logic for MailForm.xaml
    /// </summary>
    public partial class MailForm : Window
    {
        ViewModel viewModel;
        public MailForm(ViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
        }

        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            MailMessage message = new MailMessage(mailTxtBox.Text, recieverMailTxtBox.Text, themeTxtBox.Text, textTxtBox.Text);

            message.IsBodyHtml = false;
            if (isImportantMessageCheckBox.IsChecked != null && (bool)isImportantMessageCheckBox.IsChecked)
            {
                message.Priority = MailPriority.High; // important

            }
            else
            {
                message.Priority = MailPriority.Normal; // important

            }
            //message.Attachments.Add(new Attachment($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\text.txt"));
            //message.Attachments.Add(new Attachment($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\nuts.jpg"));

            // create a send object
            SmtpClient client = new SmtpClient(viewModel.Server, viewModel.Port);
            client.EnableSsl = true;

            // settings for sending mail
            client.Credentials = new NetworkCredential("prodoq@gmail.com", "r4e3w2q1");

            client.SendCompleted += Client_SendCompleted;

            // call asynchronous message sending
            client.SendAsync(message, "blablatoken");
        }

        private void Client_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Mail was sent");
        }
    }
}
