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
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        private readonly Account _account;
        private readonly IStorageService _storageService;
        private readonly IBookService _bookService;
        public AddBook(Account account)
        {
            InitializeComponent();
            _account = account;
            _storageService = new StorageService();
            _bookService = new BookService();

            cb_Storage.ItemsSource = _storageService.GetStorages();
            lb_name.Content = _account.Name.ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindow = new ManagerWindow(_account);
            managerWindow.Show();
            this.Close();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            
            var book = new Book()
            {
                Name = txt_Name.Text,
                Author = txt_Author.Text,
                ReleaseYear = txt_ReleaseYear.Text,
                Price = Decimal.Parse(txt_Price.Text)
               
            };
            
            var bookInStorage = new BookInStorage()
            {
                BookId = _bookService.GetBooksWithQuantity().ToList().Last().Id,
                StoreId = Int32.Parse(cb_Storage.SelectedIndex.ToString()) + 1,
                Quantity = Int32.Parse(txt_Quantity.Text)
            };
            _bookService.AddBook(book);
            _storageService.AddBookInStorage(bookInStorage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindow = new ManagerWindow(_account);
            managerWindow.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AccountDetail accountdetail = new AccountDetail(_account);
            accountdetail.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
