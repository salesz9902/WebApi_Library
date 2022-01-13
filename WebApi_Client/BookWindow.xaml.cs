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
using WebApi_Client.DataProviders;
using WebApi_Common.Models;

namespace WebApi_Client
{
    /// <summary>
    /// Interaction logic for BookWindow.xaml
    /// </summary>
    public partial class BookWindow : Window
    {
        private readonly Book _book;
        public BookWindow(Book book)
        {
            InitializeComponent();

            if(book != null)
            {
                _book = book;

                TitleTextBox.Text = _book.Title;
                AuthorTextBox.Text = _book.Author;
                PublishedDatePicker.SelectedDate = _book.Published_Date;

                CreateButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                _book = new Book();
                CreateButton.Visibility = Visibility.Visible;
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {   
            if (ValidateBook())
            {
                _book.Title = TitleTextBox.Text;
                _book.Author = AuthorTextBox.Text;
                _book.Published_Date = PublishedDatePicker.SelectedDate.Value;

                BookDataProvider.CreateBook(_book);

                DialogResult = true;
                Close();
            }
        }

        private bool ValidateBook()
        {
            if (string.IsNullOrEmpty(TitleTextBox.Text))
            {
                MessageBox.Show("Title should not be empty.");
                return false;
            }

            if (string.IsNullOrEmpty(AuthorTextBox.Text))
            {
                MessageBox.Show("Author should not be empty.");
                return false;
            }

            if (!PublishedDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select a date of published date.");
                return false;
            }

            return true;
        }
    }
}
