namespace TelecomProviderApi.Models
{
    public static class NumberType
    {
        public const string MOBILE = "MOB";
        public const string HOME = "HOM";
        public const string WORK = "WOR";
        public const string OTHER = "OTH";
    }

// test comments

    public class ContactNumberModel
    {
        public string Number { get; set; }

        public bool NumberActive { get; set; }

        public string Type { get; set; }
    }
}
