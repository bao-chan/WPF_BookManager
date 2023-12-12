using BookManager_Model.Models;
using BookManager_Service;
using BookManager_Service.IService;
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

namespace WPF_BookManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IAccountService _accountService;
        public MainWindow()
        {
            InitializeComponent();
            _accountService = new AccountService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = txt_username.Text.ToString();
            string password = pwb_password.Password.ToString();
            if(username != null && password != null )
            {
                Account account = _accountService.GetAccountByUsernameAndPassword(username, password);
                if(account != null )
                {
                    if (account.Role.Equals("manager"))
                    {
                        ManagerWindow managerWindow = new ManagerWindow(account);
                        managerWindow.Show();
                        Close();
                    }
                    if (account.Role.Equals("customer"))
                    {
                        CustomerWindow customerWindow = new CustomerWindow(account);
                        customerWindow.Show();
                        Close();
                    }
                }
            }
        }
    }
}
