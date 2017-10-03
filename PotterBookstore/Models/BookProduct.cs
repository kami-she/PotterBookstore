namespace PotterBookstore.Models
{
    public class BookProduct : IProduct
    {
        private readonly string _name;

        private readonly decimal _price;

        public BookProduct(string name, int price)
        {
            _name = name;
            _price = price;
        }
 
        public decimal Price => _price;

        public string Name => _name;

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var book = obj as BookProduct;

            if (book == null)
                return false;

            return Name == book.Name && Price == book.Price;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Price.GetHashCode();
        }
    }
}
