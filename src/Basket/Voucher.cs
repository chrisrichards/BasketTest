namespace BasketTest
{
    public abstract class Voucher
    {
        protected Voucher(string code, decimal value)
        {
            Code = code;
            Value = value;
        }

        public string Code { get; }
        public decimal Value { get; }

        public bool Applied { get; protected set; }
        public string Message { get; protected set; }

        public abstract decimal Apply(Basket basket);
    }
}