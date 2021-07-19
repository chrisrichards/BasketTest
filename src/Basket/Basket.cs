using System.Collections.Generic;
using System.Linq;

namespace BasketTest
{
    public class Basket
    {
        private readonly IList<Product> _products = new List<Product>();

        public decimal SubTotal { get; private set; }

        public decimal Total { get; private set; }

        public void AddProduct(Product product)
        {
            _products.Add(product);

            UpdateSubTotal();
            UpdateTotal();
        }

        public IReadOnlyList<Product> Products => _products as IReadOnlyList<Product>;

        private void UpdateSubTotal()
        {
            SubTotal = _products.Sum(p => p.Price);
        }

        private void UpdateTotal()
        {
            Total = _products.Sum(p => p.Price);
        }
    }
}
