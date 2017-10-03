using System.Collections.Generic;
using System.Linq;

namespace PotterBookstore
{
    public sealed class BookOrder
    {
        private const int OneBookPrice = 8;

        private readonly Dictionary<IProduct, int> books = new Dictionary<IProduct, int>();

        public decimal getTotalPrice()
        {
            decimal totalPrice = 0;

            int numberOfUniqueBooks = GetNumberOfUniqueBooks();

            if (numberOfUniqueBooks > 1 && numberOfUniqueBooks < 5)
            {
                decimal discountSize = (decimal) (1 - 0.05 * (numberOfUniqueBooks - 1));
                totalPrice += numberOfUniqueBooks * OneBookPrice * discountSize;
            }
            else if (numberOfUniqueBooks > 1 && numberOfUniqueBooks >= 5)
            {
                decimal discountSize = (decimal) (1 - 0.05 * numberOfUniqueBooks);
                totalPrice += numberOfUniqueBooks * OneBookPrice * discountSize;
            }

            int numberOfBooksWithoutDiscount = GetNumberOfBooks();

            if (numberOfUniqueBooks > 1)
            { 
                numberOfBooksWithoutDiscount -= numberOfUniqueBooks;
            }

            totalPrice += numberOfBooksWithoutDiscount * OneBookPrice;

            return totalPrice;
        }

        public void AddBook(IProduct book, int amount = 1)
        {
            if (books.ContainsKey(book))
            {
                books[book]+= amount;
            }
            else
            {
                books.Add(book, amount);
            }
        }

        private int GetNumberOfBooks()
        {
            return books.Sum(x => x.Value);
        }

        private int GetNumberOfUniqueBooks()
        {
            return books.Count;
        }
    }
}
