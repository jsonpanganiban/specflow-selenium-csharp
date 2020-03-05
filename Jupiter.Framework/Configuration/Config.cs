namespace Jupiter.Framework.Configuration
{
    public class Config
    {
        public static Config Instance;

        public string Url { get; set; }
        public int Timeout { get; set; }
        public string Browser { get; set; }
        public string Language { get; set; }

    }
}
