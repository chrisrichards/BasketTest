using System.Linq;

namespace BasketTest
{
    public class OfferVoucher : Voucher
    {
        public OfferVoucher(string code, decimal value, ProductCategory? category = null)
            : base(code, value)
        {
            Category = category;
        }

        public ProductCategory? Category { get; }

        public override decimal Apply(Basket basket)
        {
            if (Category == null)
            {
                Applied = true;
                return Value;
            }

            var eligibleProducts = basket.Products.Where(p => p.Category == Category).ToList();
            if (!eligibleProducts.Any())
            {
                Applied = false;
                Message = $"There are no products in your basket applicable to Offer Voucher {Code}";
                return 0;
            }

            var totalPrice = eligibleProducts.Sum(p => p.Price);
            if (totalPrice > Value)
                totalPrice -= Value;

            Applied = true;
            return totalPrice;
        }
    }
}