using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterBookstore.Tests
{
    public static class PotterBookProductGenerator
    {
        public static List<BookProduct> bookList;

        static PotterBookProductGenerator()
        {
            bookList = new List<BookProduct>()
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
