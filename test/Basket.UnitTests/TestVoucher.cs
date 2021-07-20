namespace BasketTest.UnitTests
{
    public class TestVoucher : Voucher
    {
        public TestVoucher(string code, decimal value)
            : base(code, value)
        {
        }

        public bool Applied { get; private set; }

        public override decimal Apply(Basket basket)
        {
            Applied = true;
            return Value;
        }

        public override void Visit(IVoucherVisitor visitor)
        {
            throw new System.NotImplementedException();
        }
    }
}