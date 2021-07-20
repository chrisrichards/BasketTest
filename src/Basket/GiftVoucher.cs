using System.Linq;

namespace BasketTest
{
    public class GiftVoucher
    {
        public GiftVoucher(string code, decimal value, ProductCategory? category = null)
        {
            Code = code;
            Value = value;
            Category = category;
        }

        public string Code { get; }
        public decimal Value { get; }
        public ProductCategory? Category { get; }

        public decimal Apply(Basket basket)
        {
            if (Category == null)
                return Value;

            var eligibleProducts = basket.Products.Where(p => p.Category == Category).ToList();
            if (!eligibleProducts.Any())
                return 0;

            var totalPrice = eligibleProducts.Sum(p => p.Price);
            if (totalPrice > Value)
                return totalPrice - Value;

            return totalPrice;
        }
    }
}