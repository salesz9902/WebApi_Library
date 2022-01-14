using Microsoft.AspNetCore.Mvc;
using WebApi_Common.Models;
using WebApi_Server.Repositories;

namespace WebApi_Server.Controllers
{
    [ApiController]
    [Route("api/book")]
    [Route("api/book/[action]")]
    public class BookController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var books = BookRepository.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var books = BookRepository.GetBooks();

            var book = books.FirstOrDefault(x => x.Id == id);
            if(book != null)
            {
                return Ok(book);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult AddBook([FromBody]Book book)
        {
            var books = BookRepository.GetBooks().ToList();

            book.Id = GetNewId(books);
            books.Add(book);

            BookRepository.StoreBooks(books);
            return Ok();
        }


        [HttpPost, ActionName("lend")]
        public ActionResult LendBook([FromBody] Book lentBook)
        {
            var books = BookRepository.GetBooks();

            var book = books.FirstOrDefault(x => x.Id == lentBook.Id);
            if (book != null)
            {
                if (book.BorrowerName != "" && lentBook.BorrowerName != "")
                    return Problem("The book is already lent.");

                book.BorrowDate = lentBook.BorrowDate;
                book.BorrowerName = lentBook.BorrowerName;
                book.ReturnDate = lentBook.ReturnDate;

                BookRepository.StoreBooks(books);
                return Ok(book);
            }

            return NotFound();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Book book)
        {
            var books = BookRepository.GetBooks().ToList();

            var bookToUpdate = books.FirstOrDefault(p => p.Id == book.Id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.Author = book.Author;
                bookToUpdate.Published_Date = book.Published_Date;

                BookRepository.StoreBooks(books);
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var books = BookRepository.GetBooks().ToList();

            var bookToDelete = books.FirstOrDefault(p => p.Id == id);
            if (bookToDelete != null)
            {
                books.Remove(bookToDelete);

                BookRepository.StoreBooks(books);
                return Ok();
            }

            return NotFound();
        }

        private long GetNewId(IEnumerable<Book> books)
        {
            long newId = 0;
            foreach(var book in books)
            {
                if(newId < book.Id)
                {
                    newId = book.Id;
                }
            }
            return newId + 1;
        }
    }
}
