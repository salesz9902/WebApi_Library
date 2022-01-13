using System.Text.Json;
using WebApi_Common.Models;

namespace WebApi_Server.Repositories
{
    public class BookRepository
    {
        private const string filename = "Books.json";

        public static IEnumerable<Book> GetBooks()
        {
            if (File.Exists(filename))
            {
                var rawData = File.ReadAllText(filename);
                var books = JsonSerializer.Deserialize<IEnumerable<Book>>(rawData);
                return books;
            }

            return new List<Book>();
        }

        public static void StoreBooks(IEnumerable<Book> books)
        {
            var rawData = JsonSerializer.Serialize(books);
            File.WriteAllText(filename, rawData);
        }
    }
}
