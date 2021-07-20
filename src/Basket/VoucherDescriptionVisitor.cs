using System.Text;

namespace BasketTest
{
    public interface IVoucherVisitor
    {
        void Visit(GiftVoucher giftVoucher);
        void Visit(OfferVoucher offerVoucher);
    }

    public class VoucherDescriptionVisitor : IVoucherVisitor
    {
        public string Description { get; private set; }

        public void Visit(GiftVoucher giftVoucher)
        {
            Description = $"1 x {giftVoucher.Value:C} Gift Voucher {giftVoucher.Code} applied";
        }

        public void Visit(OfferVoucher offerVoucher)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"1 x {offerVoucher.Value:C} off ");

            if (offerVoucher.Category != null)
            {
                stringBuilder.Append($"{offerVoucher.Category?.ConvertToString()} in ");
            }

            stringBuilder.Append($"baskets over {offerVoucher.Threshold:C} Offer Voucher {offerVoucher.Code} applied");

            Description = stringBuilder.ToString();
        }
    }
}