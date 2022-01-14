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

                TitleLabel.Content = _book.Title;
                AuthorLabel.Content = _book.Author;
                PublishedDatePicker.SelectedDate = _book.Published_Date;

                if (_book.BorrowerName == "")
                {
                    noLent.IsChecked = true;
                    BorrowerNameTextBox.IsEnabled = false;
                }

                LendButton.Visibility = Visibility.Visible;
            }
            else
            {
                _book = new Book();
                LendButton.Visibility = Visibility.Hidden;
            }
        }

        private bool ValidateBook()
        {
           if (string.IsNullOrEmpty(BorrowerNameTextBox.Text) && !(bool)noLent.IsChecked)
            {
                MessageBox.Show("The Name of the Borrower field should not be empty.");
                return false;
            }


            return true;
        }

        private void LendButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateBook())
            {
                if ((bool)noLent.IsChecked)
                    _book.Borrow("", DateTime.Now);
                else
                    _book.Borrow(BorrowerNameTextBox.Text, DateTime.Now);
                try
                {
                    BookDataProvider.LendBook(_book);
                } catch (InvalidOperationException ex)
                {
                    MessageBox.Show("This book is already lent!");
                } 
                DialogResult = true;
                Close();
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            BorrowerNameTextBox.IsEnabled = false;
        }

        private void noLent_Unchecked(object sender, RoutedEventArgs e)
        {
            BorrowerNameTextBox.IsEnabled = true;
        }
    }
}
