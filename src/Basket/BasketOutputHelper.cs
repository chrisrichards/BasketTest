using System.Linq;
using System.Text;

namespace BasketTest
{
    public class BasketOutputHelper
    {
        private readonly Basket _basket;

        public BasketOutputHelper(Basket basket)
        {
            _basket = basket;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            WriteProductLines(stringBuilder);
            WriteSubTotal(stringBuilder);
            WriteVoucherLines(stringBuilder);
            WriteTotal(stringBuilder);
            WriteMessage(stringBuilder);

            return stringBuilder.ToString();
        }

        public void WriteProductLines(StringBuilder stringBuilder)
        {
            foreach (var product in _basket.Products)
            {
                stringBuilder.AppendLine($"1 {product.Name} @ {product.Price:C}");
            }
        }

        public void WriteSubTotal(StringBuilder stringBuilder)
        {
            stringBuilder.AppendLine($"Sub Total: {_basket.SubTotal:C}");
        }

        public void WriteVoucherLines(StringBuilder stringBuilder)
        {
            if (_basket.Vouchers.Any())
            {
                var visitor = new VoucherDescriptionVisitor();
                foreach (var voucher in _basket.Vouchers)
                {
                    voucher.Visit(visitor);
                    stringBuilder.AppendLine(visitor.Description);
                }
            }
            else
            {
                stringBuilder.AppendLine("No vouchers applied");
            }
        }

        public void WriteTotal(StringBuilder stringBuilder)
        {
            stringBuilder.AppendLine($"Total: {_basket.Total:C}");
        }

        public void WriteMessage(StringBuilder stringBuilder)
        {
            if (!string.IsNullOrWhiteSpace(_basket.Message))
            {
                stringBuilder.AppendLine($"Message: {_basket.Message}");
            }
        }
    }
}