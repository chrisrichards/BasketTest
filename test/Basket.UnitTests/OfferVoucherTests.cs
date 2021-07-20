using Bogus;
using Shouldly;
using Xunit;

namespace BasketTest.UnitTests
{
    public class OfferVoucherTests
    {
        [Fact]
        public void Apply_WithNullCategory_ReturnsValue()
        {
            var faker = new Faker();

            var basket = new Basket();
            var product = new Product(faker.Commerce.ProductName(), faker.Random.Decimal());
            basket.AddProduct(product);

            var sut = new OfferVoucher(faker.Commerce.Ean13(), faker.Random.Decimal(), faker.Random.Decimal(0, product.Price));

            var result = sut.Apply(basket);
            
            result.ShouldBe(sut.Value);
        }

        [Fact]
        public void Apply_WithoutEligibleProduct_ReturnsZero()
        {
            var faker = new Faker();

            var basket = new Basket();
            var product = new Product(faker.Commerce.ProductName(), faker.Random.Decimal());
            basket.AddProduct(product);

            var sut = new OfferVoucher(faker.Commerce.Ean13(), faker.Random.Decimal(), faker.Random.Decimal(0, product.Price), ProductCategory.HeadGear);

            var result = sut.Apply(basket);
            
            result.ShouldBe(0);
        }

        [Fact]
        public void Apply_WithoutEligibleProduct_ShouldSetMessage()
        {
            var faker = new Faker();

            var basket = new Basket();
            var product = new Product(faker.Commerce.ProductName(), faker.Random.Decimal());
            basket.AddProduct(product);

            var sut = new OfferVoucher(faker.Commerce.Ean13(), faker.Random.Decimal(), faker.Random.Decimal(0, product.Price), ProductCategory.HeadGear);

            sut.Apply(basket);
            
            sut.Message.ShouldBe($"There are no products in your basket applicable to Offer Voucher {sut.Code}");
        }

        [Fact]
        public void Apply_WithEligibleProductWithPriceGreaterThanVoucherValue_ReturnsVoucherValue()
        {
            var faker = new Faker();

            var basket = new Basket();
            var product = new Product(faker.Commerce.ProductName(), faker.Random.Decimal(), ProductCategory.HeadGear);
            basket.AddProduct(product);

            var sut = new OfferVoucher(faker.Commerce.Ean13(), faker.Random.Decimal(0, product.Price), faker.Random.Decimal(0, product.Price), ProductCategory.HeadGear);

            var result = sut.Apply(basket);
            
            result.ShouldBe(sut.Value);
        }


        [Fact]
        public void Apply_WithEligibleProductWithPriceLessThanVoucherValue_ReturnsProductPrice()
        {
            var faker = new Faker();

            var basket = new Basket();
            var product = new Product(faker.Commerce.ProductName(), faker.Random.Decimal(), ProductCategory.HeadGear);
            basket.AddProduct(product);

            var sut = new OfferVoucher(faker.Commerce.Ean13(), faker.Random.Decimal(product.Price), faker.Random.Decimal(0, product.Price), ProductCategory.HeadGear);

            var result = sut.Apply(basket);
            
            result.ShouldBe(product.Price);
        }


        [Fact]
        public void Apply_DoesNotApplyVoucherWhenBasketSubTotalIsLessThanThreshold()
        {
            var faker = new Faker();

            var basket = new Basket();
            var product = new Product(faker.Commerce.ProductName(), faker.Random.Decimal(), ProductCategory.HeadGear);
            basket.AddProduct(product);

            var sut = new OfferVoucher(faker.Commerce.Ean13(), faker.Random.Decimal(), faker.Random.Decimal(product.Price), ProductCategory.HeadGear);

            var result = sut.Apply(basket);
            
            result.ShouldBe(0);
        }
    }
}