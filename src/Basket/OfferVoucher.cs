using System.Linq;

namespace BasketTest
{
    public class OfferVoucher : Voucher
    {
        public OfferVoucher(string code, decimal value, decimal threshold, ProductCategory? category = null)
            : base(code, value)
        {
            Threshold = threshold;
            Category = category;
        }

        public decimal Threshold { get; }
        public ProductCategory? Category { get; }

        public override decimal Apply(Basket basket)
        {
            if (Category == null)
            {
                return Value;
            }

            if (basket.SubTotal < Threshold)
            {
                var difference = Threshold - basket.SubTotal;
                Message = $"You have not reached the spend threshold for Offer Voucher {Code}. Spend another {difference:C} to receive {Value:C} discount from your basket total";
                return 0;
            }

            var eligibleProducts = basket.Products.Where(p => p.Category == Category).ToList();
            if (!eligibleProducts.Any())
            {
                Message = $"There are no products in your basket applicable to Offer Voucher {Code}";
                return 0;
            }

            var totalPrice = eligibleProducts.Sum(p => p.Price);
            return totalPrice > Value ? Value : totalPrice;
        }

        public override void Visit(IVoucherVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}