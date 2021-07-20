using System.Collections.Generic;
using System.Linq;

namespace BasketTest
{
    public class Basket
    {
        private readonly IList<Product> _products = new List<Product>();
        private readonly IList<Voucher> _vouchers = new List<Voucher>();

        public decimal SubTotal { get; private set; }

        public decimal Total { get; private set; }

        public void AddProduct(Product product)
        {
            _products.Add(product);
            UpdateTotals();
        }

        public IReadOnlyList<Product> Products => _products as IReadOnlyList<Product>;

        public void AddVoucher(Voucher voucher)
        {
            _vouchers.Add(voucher);
            UpdateTotals();
        }

        public IReadOnlyList<Voucher> Vouchers => _vouchers as IReadOnlyList<Voucher>;

        private void UpdateTotals()
        {
            SubTotal = _products.Sum(p => p.Price);

            var discount = ApplyVouchers();

            var total = SubTotal - discount;

            if (total < 0) 
                total = 0;

            Total = total;
        }

        private decimal ApplyVouchers()
        {
            return _vouchers.Sum(v => v.Apply(this));
        }
    }
}
