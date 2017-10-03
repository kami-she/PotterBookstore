using System.Collections.Generic;
using PotterBookstore.Models;

namespace PotterBookstore.Tests
{
    public static class PotterBookProductGenerator
    {
        public static List<BookProduct> BookList;

        static PotterBookProductGenerator()
        {
            BookList = new List<BookProduct>()
            {
                new BookProduct("FirstBook", 8),
                new BookProduct("SecondBook", 8),
                new BookProduct("ThirdBook", 8),
                new BookProduct("FourthBook", 8),
                new BookProduct("FifthBook", 8),
                new BookProduct("SixthBook", 8),
                new BookProduct("SeventhBook", 8),
            };
        }
    }
}
