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
using System.Windows.Shapes;

namespace WPF_BookManager
{
    /// <summary>
    /// Interaction logic for AccountDetail.xaml
    /// </summary>
    public partial class AccountDetail : Window
    {
        private Account _account;
        private readonly IAccountService _accountService;
        public AccountDetail(Account account)
        {
            _account = account;
            _accountService = new AccountService();
            InitializeComponent();
            lb_name.Content = _account.Name;

            txt_Name.Text = account.Name;
            txt_UserName.Text = account.Username;
            pwb_Password.Password = account.Password;
            txt_Phone.Text = account.Phone;
            date_DateOfBirth.Text = account.DateOfBirth.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindow = new ManagerWindow(_account);
            managerWindow.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            var account = new Account()
            {
                Id = _account.Id,
                Name = txt_Name.Text,
                Username = txt_UserName.Text,
                Password = pwb_Password.Password,
                Phone = txt_Phone.Text,
                DateOfBirth = date_DateOfBirth.SelectedDate,
                Role = _account.Role,
                IsActive = _account.IsActive,
            };
            _accountService.UpdateAccount(account);
            _account = account;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
