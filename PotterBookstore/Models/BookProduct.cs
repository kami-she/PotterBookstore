using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterBookstore
{
    public class BookProduct : IProduct
    {
        private string name;

        private int price;

        public BookProduct(string name, int price)
        {
            this.name = name;
            this.price = price;
        }
 
        public int GetProductPrice
        {
            get { return price; }
        }

        public string GetProductName
        {
            get { return name; }
        }
    }
}
