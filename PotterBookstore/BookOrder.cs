﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterBookstore
{
    public sealed class BookOrder
    {
        private readonly List<Book> books = new List<Book>();
        private const int OneBookPrice = 8;

        public int getTotalPrice()
        {
            return books.Count * 8;
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }
    }
}
