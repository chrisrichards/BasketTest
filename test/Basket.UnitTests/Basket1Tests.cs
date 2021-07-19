using Shouldly;
using Xunit;

namespace BasketTest.UnitTests
{
    public class Basket1Tests
    {
        private readonly Basket _sut;

        public Basket1Tests()
        {
            _sut = new Basket();

            var jumper = new Product("Jumper", 54.65m);
            var headLight = new Product("Head Light", 3.50m, ProductCategory.HeadGear);

            _sut.AddProduct(jumper);
            _sut.AddProduct(headLight);
        }

        [Fact]
        public void Basket_ProductsCount_ShouldBeCorrect()
        {
            _sut.Products.Count.ShouldBe(2);
        }

        [Fact]
        public void Basket_SubTotal_ShouldBeCorrectWithTwoProducts()
        {
            _sut.SubTotal.ShouldBe(58.15m);
        }

        [Fact]
        public void Basket_Total_ShouldBeCorrectWithTwoProducts()
        {
            _sut.Total.ShouldBe(58.15m);
        }
    }
}
