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
            var jumper = new Product("Jumper", 54.65m);

            sut.AddProduct(jumper);

            sut.Products.Count.ShouldBe(1);

            var result = sut.Products[0];
            result.Name.ShouldBe(jumper.Name);
            result.Price.ShouldBe(jumper.Price);
            result.Category.ShouldBe(jumper.Category);
        }
    }
}
