namespace BasketTest
{
    public class GiftVoucher : Voucher
    {
        public GiftVoucher(string code, decimal value)
            : base(code, value)
        {
        }

        public override decimal Apply(Basket basket)
        {
            return Value;
        }

        public override void Visit(IVoucherVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}