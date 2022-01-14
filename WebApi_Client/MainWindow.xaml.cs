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
            UpdateLentBooksListBox();
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

        private void UpdateBooksListBox()
        {
            var books= BookDataProvider.GetBooks().ToList();
            BooksListBox.ItemsSource = books;
        }

        private void UpdateLentBooksListBox()
        {
            BooksListBox2.Items.Clear();
            var books = BookDataProvider.GetBooks().ToList();
            var addedBooks = 0;
            for(int i = 0; i < books.Count; i++)
            {
                if(books[i].BorrowerName == "")
                {
                    BooksListBox2.Items.Add(books[i]);
                    addedBooks++;
                }
            }
            if (addedBooks == 0) BooksListBox2.Items.Add("No books available for lending.");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (BooksListBox.SelectedIndex == -1)
                return;

            var books = BookDataProvider.GetBooks().ToList();
            var book = books[BooksListBox.SelectedIndex];

            BookWindow window = new BookWindow(book);
            if (window.ShowDialog() ?? false)
            {
                UpdateBooksListBox();
                UpdateLentBooksListBox();
            }
        }

        private void BooksLentBy_Click(object sender, RoutedEventArgs e)
        {
            LentBooksList window = new LentBooksList();
            window.ShowDialog();
        }
    }
}
