using BookManager_Model;
using BookManager_Model.Models;
using BookManager_Service;
using BookManager_Service.IService;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
namespace WPF_BookManager
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        private readonly IBookService _service;
        private readonly Account _account;
        public ManagerWindow(Account account)
        {
            _service = new BookService();
            InitializeComponent();
            _account = account;
            lb_name.Content = _account.Name.ToString();

            IList<BookDTO> books = _service.GetBooksWithQuantity();

            dtg_books.ItemsSource = books;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private bool Ismaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2) {
                if(Ismaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    Ismaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    Ismaximized= true;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddBook addBook = new AddBook(_account);
            addBook.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AccountDetail accountdetail = new AccountDetail(_account);
            accountdetail.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
