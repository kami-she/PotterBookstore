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

        private decimal price;

        public BookProduct(string name, int price)
        {
            this.name = name;
            this.price = price;
        }
 
        public decimal Price
        {
            get { return price; }
        }

        public string Name
        {
            get { return name; }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(BookProduct)) return false;
            var book = (BookProduct)obj;
            return this.Name == book.Name && this.Price == book.Price;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Price.GetHashCode();
        }
    }
}
