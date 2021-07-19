using Bogus;

namespace BasketTest.UnitTests
{
    public static class Fakes
    {
        public static Product Product(this Faker faker)
        {
            return new(
                faker.Commerce.ProductName(), 
                faker.Random.Decimal(),
                faker.PickRandom<ProductCategory>());
        }

        public static GiftVoucher GiftVoucher(this Faker faker)
        {
            return new(faker.Commerce.Ean13(), 
                faker.Random.Decimal(),
                faker.PickRandom<ProductCategory>());
        }
    }
}