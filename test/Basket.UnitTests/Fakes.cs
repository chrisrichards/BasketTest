using Bogus;

namespace BasketTest.UnitTests
{
    public static class Fakes
    {
        public static Faker<Product> Product()
        {
            return new Faker<Product>()
                .CustomInstantiator(f =>
                    new Product(f.Commerce.ProductName(),
                        f.Random.Decimal(),
                        f.PickRandom<ProductCategory>()));
        }

        public static Faker<GiftVoucher> GiftVoucher()
        {
            return new Faker<GiftVoucher>()
                .CustomInstantiator(f =>
                    new GiftVoucher(f.Commerce.Ean13(), 
                        f.Random.Decimal()));
        }

        public static Faker<OfferVoucher> OfferVoucher()
        {
            return new Faker<OfferVoucher>()
                .CustomInstantiator(f =>
                    new OfferVoucher(f.Commerce.Ean13(),
                        f.Random.Decimal(),
                        f.Random.Decimal(100),
                        f.PickRandom<ProductCategory>()));
        }
    }
}