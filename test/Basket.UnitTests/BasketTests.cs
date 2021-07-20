using System.Linq;
using Bogus;
using Shouldly;
using Xunit;

namespace BasketTest.UnitTests
{
    public class BasketTests
    {
        [Fact]
        public void Basket_AddProduct_ShouldAddProduct()
        {
            var sut = new Basket();
            var product = Fakes.Product().Generate();

            sut.AddProduct(product);

            sut.Products.Count.ShouldBe(1);

            var result = sut.Products[0];
            result.Name.ShouldBe(product.Name);
            result.Price.ShouldBe(product.Price);
            result.Category.ShouldBe(product.Category);
        }

        [Fact]
        public void Basket_AddProduct_ShouldUpdateSubTotal()
        {
            var sut = new Basket();
            var products = Fakes.Product().Generate(5);

            foreach (var product in products)
            {
                sut.AddProduct(product);
            }

            var expectedResult = products.Sum(p => p.Price);
            sut.SubTotal.ShouldBe(expectedResult);
        }

        [Fact]
        public void Basket_AddProduct_ShouldUpdateTotal()
        {
            var sut = new Basket();
            var products = Fakes.Product().Generate(5);

            foreach (var product in products)
            {
                sut.AddProduct(product);
            }

            var expectedResult = products.Sum(p => p.Price);
            sut.SubTotal.ShouldBe(expectedResult);
        }

        [Fact]
        public void Basket_AddVoucher_ShouldAddGiftVoucher()
        {
            var sut = new Basket();
            var voucher = Fakes.GiftVoucher().Generate();

            sut.AddVoucher(voucher);

            sut.Vouchers.Count.ShouldBe(1);

            var result = sut.Vouchers[0];
            result.ShouldBeOfType<GiftVoucher>();
            result.Code.ShouldBe(voucher.Code);
            result.Value.ShouldBe(voucher.Value);
        }

        [Fact]
        public void Basket_AddVoucher_ShouldAddOfferVoucher()
        {
            var sut = new Basket();
            var voucher = Fakes.OfferVoucher().Generate();

            sut.AddVoucher(voucher);

            sut.Vouchers.Count.ShouldBe(1);

            var result = sut.Vouchers[0];
            result.Code.ShouldBe(voucher.Code);
            result.Value.ShouldBe(voucher.Value);

            result.ShouldBeOfType<OfferVoucher>();
            var voucherResult = (OfferVoucher)result;
            voucherResult.Category.ShouldBe(voucher.Category);
        }

        [Fact]
        public void Basket_AddVoucher_ShouldApplyVoucher()
        {
            var sut = new Basket();

            var product = Fakes.Product().Generate();
            sut.AddProduct(product);

            var faker = new Faker();
            var voucher = new TestVoucher(faker.Commerce.Ean13(), faker.Random.Decimal(0, product.Price));
            sut.AddVoucher(voucher);

            voucher.Applied.ShouldBeTrue();
        }

        [Fact]
        public void Basket_AddVoucher_ShouldNotUpdateSubTotal()
        {
            var sut = new Basket();

            var product = Fakes.Product().Generate();
            sut.AddProduct(product);

            var faker = new Faker();
            var voucher = new TestVoucher(faker.Commerce.Ean13(), faker.Random.Decimal(0, product.Price));
            sut.AddVoucher(voucher);

            sut.SubTotal.ShouldBe(product.Price);
        }

        [Fact]
        public void Basket_AddVoucher_ShouldUpdateTotal()
        {
            var sut = new Basket();

            var product = Fakes.Product().Generate();
            sut.AddProduct(product);

            var faker = new Faker();
            var voucher = new TestVoucher(faker.Commerce.Ean13(), faker.Random.Decimal(0, product.Price));
            sut.AddVoucher(voucher);

            sut.Total.ShouldBe(product.Price - voucher.Value);
        }
    }
}
