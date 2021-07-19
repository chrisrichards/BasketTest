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

        public string Code { get; private set; }
        public decimal Value { get; private set; }
        public ProductCategory? Category { get; }
    }
}