﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Common.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Published_Date { get; set; }
        public string BorrowerName { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Book()
        {
            BorrowerName = "";
        }

        public Book(long bookId, string title, string author, DateTime publishedDate)
        {
            Id = bookId;
            Title = title;
            Author = author;
            Published_Date = publishedDate;
            BorrowerName = "";
        }

        public void Borrow(string borrowerName, DateTime borrowDate, DateTime returnDate)
        {
            BorrowerName = borrowerName;
            BorrowDate = borrowDate;
            ReturnDate = returnDate;
        }


        public override string ToString()
        {
            return $"{Title}, {Author}, Published: {Published_Date}";
        }

    }
}
