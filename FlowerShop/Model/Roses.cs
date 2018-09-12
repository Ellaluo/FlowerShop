namespace FlowerShop.Model
{
    public class Roses : Flowers
    {
        public const int BundleOfFiveCount = 5;
        public const int BundleOfTenCount = 10;
        public const double BundleOfFivePrice = 6.99;
        public const double BundleOfTenPrice = 12.99;
        public Bundle BundleOfFive => new Bundle()
        {
            Count = BundleOfFiveCount, Price = BundleOfFivePrice
        };

        public Bundle BundleOfTen => new Bundle()
        {
            Count = BundleOfTenCount, Price = BundleOfTenPrice
        };

        public Roses()
        {
            Name = "Roses";
            Code = "R12";
        }
    }
}
