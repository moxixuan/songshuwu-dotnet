namespace songshuwu.client
{
    public class ShopAddInput
    {
        public string origin_id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public decimal longitude { get; set; }
        public decimal latitude { get; set; }
        public Category category { get; set; }
        public MapType map_type { get; set; }
        public ShopConfig config { get; set; }
    }
}