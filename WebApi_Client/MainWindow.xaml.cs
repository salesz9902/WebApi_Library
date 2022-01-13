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
