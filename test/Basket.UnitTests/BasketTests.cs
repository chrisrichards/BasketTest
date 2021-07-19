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
            var faker = new Faker();

            var sut = new Basket();
            var product = faker.Product();

            sut.AddProduct(product);

            sut.Products.Count.ShouldBe(1);

            var result = sut.Products[0];
            result.Name.ShouldBe(product.Name);
            result.Price.ShouldBe(product.Price);
            result.Category.ShouldBe(product.Category);
        }

        [Fact]
        public void Basket_AddVoucher_ShouldAddGiftVoucher()
        {
            var faker = new Faker();

            var sut = new Basket();
            var voucher = faker.GiftVoucher();

            sut.AddVoucher(voucher);

            sut.Vouchers.Count.ShouldBe(1);

            var result = sut.Vouchers[0];
            result.Code.ShouldBe(voucher.Code);
            result.Value.ShouldBe(voucher.Value);
            result.Category.ShouldBe(voucher.Category);
        }
    }
}
