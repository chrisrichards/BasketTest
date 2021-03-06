using System.Threading;
using Shouldly;
using Xunit;

namespace BasketTest.UnitTests
{
    public class AcceptanceTests
    {
        public AcceptanceTests()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-gb");
        }

        [Fact]
        public void Basket1()
        {
            var basket = new Basket();

            var jumper = new Product("Jumper", 54.65m);
            var headLight = new Product("Head Light", 3.50m, ProductCategory.HeadGear);

            basket.AddProduct(jumper);
            basket.AddProduct(headLight);

            var outputHelper = new BasketOutputHelper(basket);
            var result = outputHelper.ToString();

            result.ShouldBe(@"1 Jumper @ £54.65
1 Head Light (Head Gear Category of Product) @ £3.50
Sub Total: £58.15
No vouchers applied
Total: £58.15
");
        }

        [Fact]
        public void Basket2()
        {
            var basket = new Basket();

            var gloves = new Product("Gloves", 10.50m);
            var jumper = new Product("Jumper", 54.65m);

            basket.AddProduct(gloves);
            basket.AddProduct(jumper);

            var giftVoucher = new GiftVoucher("XXX-XXX", 5.00m);
            basket.AddVoucher(giftVoucher);

            var outputHelper = new BasketOutputHelper(basket);
            var result = outputHelper.ToString();

            result.ShouldBe(@"1 Gloves @ £10.50
1 Jumper @ £54.65
Sub Total: £65.15
1 x £5.00 Gift Voucher XXX-XXX applied
Total: £60.15
");
        }

        [Fact]
        public void Basket3()
        {
            var basket = new Basket();

            var gloves = new Product("Gloves", 25.00m);
            var jumper = new Product("Jumper", 26.00m);

            basket.AddProduct(gloves);
            basket.AddProduct(jumper);

            var offerVoucher = new OfferVoucher("YYY-YYY", 5.00m, 50.00m, ProductCategory.HeadGear);
            basket.AddVoucher(offerVoucher);

            var outputHelper = new BasketOutputHelper(basket);
            var result = outputHelper.ToString();

            result.ShouldBe(@"1 Gloves @ £25.00
1 Jumper @ £26.00
Sub Total: £51.00
1 x £5.00 off Head Gear in baskets over £50.00 Offer Voucher YYY-YYY applied
Total: £51.00
Message: There are no products in your basket applicable to Offer Voucher YYY-YYY
");
        }

        [Fact]
        public void Basket4()
        {
            var basket = new Basket();

            var gloves = new Product("Gloves", 25.00m);
            var jumper = new Product("Jumper", 26.00m);
            var headLight = new Product("Head Light", 3.50m, ProductCategory.HeadGear);

            basket.AddProduct(gloves);
            basket.AddProduct(jumper);
            basket.AddProduct(headLight);

            var offerVoucher = new OfferVoucher("YYY-YYY", 5.00m, 50.00m, ProductCategory.HeadGear);
            basket.AddVoucher(offerVoucher);

            var outputHelper = new BasketOutputHelper(basket);
            var result = outputHelper.ToString();

            result.ShouldBe(@"1 Gloves @ £25.00
1 Jumper @ £26.00
1 Head Light (Head Gear Category of Product) @ £3.50
Sub Total: £54.50
1 x £5.00 off Head Gear in baskets over £50.00 Offer Voucher YYY-YYY applied
Total: £51.00
");
        }

        [Fact]
        public void Basket5()
        {
            var basket = new Basket();

            var gloves = new Product("Gloves", 25.00m);
            var jumper = new Product("Jumper", 26.00m);

            basket.AddProduct(gloves);
            basket.AddProduct(jumper);

            var giftVoucher = new GiftVoucher("XXX-XXX", 5.00m);
            basket.AddVoucher(giftVoucher);

            var offerVoucher = new OfferVoucher("YYY-YYY", 5.00m, 50.00m);
            basket.AddVoucher(offerVoucher);

            var outputHelper = new BasketOutputHelper(basket);
            var result = outputHelper.ToString();

            result.ShouldBe(@"1 Gloves @ £25.00
1 Jumper @ £26.00
Sub Total: £51.00
1 x £5.00 Gift Voucher XXX-XXX applied
1 x £5.00 off baskets over £50.00 Offer Voucher YYY-YYY applied
Total: £41.00
");
        }

        [Fact]
        public void Basket6()
        {
            var basket = new Basket();

            var gloves = new Product("Gloves", 25.00m);
            var giftVoucher = new GiftVoucherProduct("£30 Gift Voucher", 30.00m);

            basket.AddProduct(gloves);
            basket.AddProduct(giftVoucher);
            
            var offerVoucher = new OfferVoucher("YYY-YYY", 5.00m, 50.00m);
            basket.AddVoucher(offerVoucher);

            var outputHelper = new BasketOutputHelper(basket);
            var result = outputHelper.ToString();

            result.ShouldBe(@"1 Gloves @ £25.00
1 £30 Gift Voucher @ £30.00
Sub Total: £55.00
1 x £5.00 off baskets over £50.00 Offer Voucher YYY-YYY applied
Total: £55.00
Message: You have not reached the spend threshold for Offer Voucher YYY-YYY. Spend another £25.01 to receive £5.00 discount from your basket total
");
        }

        [Fact]
        public void Basket7()
        {
            var basket = new Basket();

            var gloves = new Product("Gloves", 25.00m);
            basket.AddProduct(gloves);
            
            var giftVoucher = new GiftVoucher("XXX-XXX", 30.00m);
            basket.AddVoucher(giftVoucher);

            var outputHelper = new BasketOutputHelper(basket);
            var result = outputHelper.ToString();

            result.ShouldBe(@"1 Gloves @ £25.00
Sub Total: £25.00
1 x £30.00 Gift Voucher XXX-XXX applied
Total: £0.00
");
        }
    }
}