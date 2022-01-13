using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApi_Common.Models;

namespace WebApi_Client.DataProviders
{
    class BookDataProvider
    {
        private const string _url = "http://localhost:5000/api/book";

        public static IEnumerable<Book> GetBooks()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var books = JsonConvert.DeserializeObject<IEnumerable<Book>>(rawData);
                    return books;
                }

                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }

        public static void CreateBook(Book book)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(book);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PostAsync(_url, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
