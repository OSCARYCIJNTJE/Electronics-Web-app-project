namespace Electronics.Domain.Products
{
    public class Electronics
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string OperatingSystem { get; private set; }
        public double ScreenSizeInInches { get; private set; }
        public string StorageCapacity { get; private set; }
        public int Stock {  get; private set; }
        public byte[] Image {  get; private set; }

        public Electronics() { }

        public Electronics(int id, string name, string oSystem, double screenInch, string capacity, int stock, byte[] image)
        {
            Id = id;
            Name = name;
            OperatingSystem = oSystem;
            ScreenSizeInInches = screenInch;
            StorageCapacity = capacity;
            Stock = stock;
            Image = image;
        }

        public Electronics(string name, string oSystem, double screenInch, string capacity, int stock, byte[] image)
        {
            Name = name;
            OperatingSystem = oSystem;
            ScreenSizeInInches = screenInch;
            StorageCapacity = capacity;
            Stock = stock;
            Image = image;
        }
    }
}
