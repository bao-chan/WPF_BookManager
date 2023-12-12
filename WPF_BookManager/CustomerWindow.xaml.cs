using BookManager_Model;
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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private readonly Account _account;
        private readonly IBookService _service;
        public CustomerWindow(Account account)
        {
            _service = new BookService();
            _account = account;
            InitializeComponent();

            lb_name.Content = _account.Name;

            IList<BookDTO> books = _service.GetBooksWithQuantity();
            dtg_books.ItemsSource = books;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AccountDetail accountdetail = new AccountDetail(_account);
            accountdetail.Show();
            this.Close();
        }
    }
}
