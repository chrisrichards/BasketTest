namespace BasketTest
{
    public static class ProductCategoryExtensions
    {
        public static string ConvertToString(this ProductCategory productCategory)
        {
            return productCategory switch
            {
                ProductCategory.HeadGear => "Head Gear",
                _ => string.Empty
            };
        }
    }
}