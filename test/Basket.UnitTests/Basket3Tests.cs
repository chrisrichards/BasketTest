using Shouldly;
using Xunit;

namespace BasketTest.UnitTests
{
    public class Basket3Tests
    {
        private readonly Basket _sut;

        public Basket3Tests()
        {
            _sut = new Basket();

            var gloves = new Product("Gloves", 25.00m);
            var jumper = new Product("Jumper", 26.00m);

            _sut.AddProduct(gloves);
            _sut.AddProduct(jumper);

            var offerVoucher = new OfferVoucher("YYY-YYY", 5.00m, ProductCategory.HeadGear);
            _sut.AddVoucher(offerVoucher);
        }

        [Fact]
        public void Basket_ProductsCount_ShouldBeCorrect()
        {
            _sut.Products.Count.ShouldBe(2);
        }

        [Fact]
        public void Basket_VouchersCount_ShouldBeCorrect()
        {
            _sut.Vouchers.Count.ShouldBe(1);
        }

        [Fact]
        public void Basket_SubTotal_ShouldBeCorrect()
        {
            _sut.SubTotal.ShouldBe(51.00m);
        }

        [Fact]
        public void Basket_Total_ShouldBeCorrect()
        {
            _sut.Total.ShouldBe(51.00m);
        }
    }
}
