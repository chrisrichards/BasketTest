using System;
using System.Text;
using Bogus;
using Shouldly;
using Xunit;

namespace BasketTest.UnitTests
{
    public class BasketOutputHelperTests
    {
        [Fact]
        public void BasketOutputHelper_WriteProductLines_WritesProductLine()
        {
            var basket = new Basket();
            var product = Fakes.Product().Generate();
            basket.AddProduct(product);

            var sut = new BasketOutputHelper(basket);
            var stringBuilder = new StringBuilder();
            sut.WriteProductLines(stringBuilder);

            var result = stringBuilder.ToString();
            result.ShouldBe($"1 {product.Name} @ {product.Price:C}{Environment.NewLine}");
        }

        [Fact]
        public void BasketOutputHelper_WriteVoucherLines_WithoutAnyVouchers_WritesNoVouchersApplied()
        {
            var basket = new Basket();

            var sut = new BasketOutputHelper(basket);
            var stringBuilder = new StringBuilder();
            sut.WriteVoucherLines(stringBuilder);

            var result = stringBuilder.ToString();
            result.ShouldNotBeNullOrEmpty();
            result.ShouldBe($"No vouchers applied{Environment.NewLine}");
        }

        [Fact]
        public void BasketOutputHelper_WriteVoucherLines_WritesGiftVoucherLine()
        {
            var basket = new Basket();

            var giftVoucher = Fakes.GiftVoucher().Generate();
            basket.AddVoucher(giftVoucher);

            var sut = new BasketOutputHelper(basket);
            var stringBuilder = new StringBuilder();
            sut.WriteVoucherLines(stringBuilder);

            var result = stringBuilder.ToString();
            result.ShouldNotBeNullOrEmpty();
            result.ShouldBe($"1 x {giftVoucher.Value:C} Gift Voucher {giftVoucher.Code} applied{Environment.NewLine}");
        }

        [Fact]
        public void BasketOutputHelper_WriteVoucherLines_WritesOfferVoucherLineWithoutProductCategory()
        {
            var basket = new Basket();

            var faker = new Faker();
            var offerVoucher = new OfferVoucher(faker.Commerce.Ean13(), faker.Random.Decimal(), faker.Random.Decimal());
            basket.AddVoucher(offerVoucher);

            var sut = new BasketOutputHelper(basket);
            var stringBuilder = new StringBuilder();
            sut.WriteVoucherLines(stringBuilder);

            var result = stringBuilder.ToString();
            result.ShouldNotBeNullOrEmpty();
            result.ShouldBe($"1 x {offerVoucher.Value:C} off baskets over {offerVoucher.Threshold:C} Offer Voucher {offerVoucher.Code} applied{Environment.NewLine}");
        }

        [Fact]
        public void BasketOutputHelper_WriteVoucherLines_WritesOfferVoucherLineWithProductCategory()
        {
            var basket = new Basket();

            var offerVoucher = Fakes.OfferVoucher().Generate();
            basket.AddVoucher(offerVoucher);

            var sut = new BasketOutputHelper(basket);
            var stringBuilder = new StringBuilder();
            sut.WriteVoucherLines(stringBuilder);

            var result = stringBuilder.ToString();
            result.ShouldNotBeNullOrEmpty();
            result.ShouldBe($"1 x {offerVoucher.Value:C} off {offerVoucher.Category} in baskets over {offerVoucher.Threshold:C} Offer Voucher {offerVoucher.Code} applied{Environment.NewLine}");
        }
    }
}