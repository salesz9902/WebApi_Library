using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WebApi_Client.DataProviders;
using WebApi_Common.Models;

namespace WebApi_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateBooksListBox();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            var selectedPerson = BooksListBox.SelectedItem as Book;

            if (selectedPerson != null)
            {
                var window = new BookWindow(selectedPerson);
                if (window.ShowDialog() ?? false)
                {
                    UpdateBooksListBox();
                }

                BooksListBox.UnselectAll();
            }
        }

        /*private void LendBooks_Click(object sender, RoutedEventArgs arguments)
        {
            List<Book> selectedBooks = BooksListBox.SelectedItems.Cast<Book>().ToList();
            if (!selectedBooks.Any())
            {
                MessageBox.Show("No books selected!");
                return;
            }

            var window = new BorrowingDetailsWindow(selectedBooks);
            if (window.ShowDialog() ?? false)
            {
                SetAvailableBookList();
                SetBorrowedBookList();
            }
        }*/

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            var window = new BookWindow(null);
            if (window.ShowDialog() ?? false)
            {
                UpdateBooksListBox();
            }
        }
        private void UpdateBooksListBox()
        {
            var books= BookDataProvider.GetBooks().ToList();
            BooksListBox.ItemsSource = books;
        }
    }
}
