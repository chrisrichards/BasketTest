using Shouldly;
using Xunit;

namespace BasketTest.UnitTests
{
    public class Basket2Tests
    {
        private readonly Basket _sut;

        public Basket2Tests()
        {
            _sut = new Basket();

            var gloves = new Product("Gloves", 10.50m);
            var jumper = new Product("Jumper", 54.65m);

            _sut.AddProduct(gloves);
            _sut.AddProduct(jumper);

            var giftVoucher = new GiftVoucher("XXX-XXX", 5.00m);
            _sut.AddVoucher(giftVoucher);
        }

        [Fact]
        public void Basket_ProductsCount_ShouldBeCorrect()
        {
            _sut.Products.Count.ShouldBe(2);
        }

        [Fact]
        public void Basket_SubTotal_ShouldBeCorrect()
        {
            _sut.SubTotal.ShouldBe(65.15m);
        }

        [Fact]
        public void Basket_Total_ShouldBeCorrect()
        {
            _sut.Total.ShouldBe(60.15m);
        }
    }
}
