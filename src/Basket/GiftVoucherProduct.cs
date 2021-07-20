namespace BasketTest
{
    public class GiftVoucherProduct : Product
    {
        public GiftVoucherProduct(string name, decimal price, ProductCategory? category = null)
            : base(name, price, category)
        {
        }

        public override bool IsGiftVoucher => true;
    }
}