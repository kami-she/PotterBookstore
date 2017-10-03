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

        private readonly Dictionary<Book, int> books = new Dictionary<Book, int>();

        public double getTotalPrice()
        {
            double totalPrice = 0;

            int numberOfUniqueBooks = GetNumberOfUniqueBooks();

            if (numberOfUniqueBooks > 1)
            {
                double discountSize = 1 - 0.05 * (numberOfUniqueBooks - 1);
                totalPrice += numberOfUniqueBooks * OneBookPrice * discountSize;
            }

            int numberOfBooksWithoutDiscount = GetNumberOfBooks();

            if (numberOfUniqueBooks > 1)
                numberOfBooksWithoutDiscount -= numberOfUniqueBooks;

            totalPrice += numberOfBooksWithoutDiscount * 8;

            return totalPrice;
        }

        public void AddBook(Book book)
        {
            if (books.ContainsKey(book))
            {
                books[book]++;
            }
            else
            {
                books.Add(book, 1);
            }
        }

        private int GetNumberOfBooks()
        {
            return books.Sum(x => x.Value);
        }

        public int GetNumberOfUniqueBooks()
        {
            return books.Count;
        }
    }
}
