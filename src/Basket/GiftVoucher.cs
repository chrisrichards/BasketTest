namespace BasketTest
{
    public class GiftVoucher
    {
        public GiftVoucher(string code, decimal value)
        {
            Code = code;
            Value = value;
        }

        public string Code { get; private set; }
        public decimal Value { get; private set; }
    }
}