using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterBookstore
{
    public sealed class BookOrder
    {
        private const int OneBookPrice = 8;

        private readonly List<Book> books = new List<Book>();

        public double getTotalPrice()
        {
            double totalPrice = 0;
            int numberOfBooks = books.Count;

            HashSet<Book> booksWithoutRepeats = new HashSet<Book>(books);
            int numberOfUniqueBooks = booksWithoutRepeats.Count;

            if (numberOfUniqueBooks == 2)
                totalPrice += numberOfUniqueBooks * OneBookPrice * 0.95;

            int numberOfBooksWithoutDiscount = books.Count;

            if (numberOfUniqueBooks > 1)
                numberOfBooksWithoutDiscount -= numberOfUniqueBooks;

            totalPrice += numberOfBooksWithoutDiscount * 8;

            return totalPrice;
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }
    }
}
