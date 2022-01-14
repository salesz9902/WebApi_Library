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

namespace WebApi_Client
{
    /// <summary>
    /// Interaction logic for LentBooksList.xaml
    /// </summary>
    public partial class LentBooksList : Window
    {
        public LentBooksList()
        {
            InitializeComponent();
        }

        private void ListLentBooks_Click(object sender, RoutedEventArgs e)
        {
            ListLentBooksBy.Items.Clear();
            var books = BookDataProvider.GetBooks().ToList();
            var addedBooks = 0;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].BorrowerName == NameTextBox.Text)
                {
                    ListLentBooksBy.Items.Add(books[i]);
                    addedBooks++;
                }
            }
            if (addedBooks == 0) ListLentBooksBy.Items.Add("No lent books");
        }
    }
}
