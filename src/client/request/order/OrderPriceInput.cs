namespace songshuwu.client
{
    public class OrderPriceInput
    {
        public int dispatch_mode { get; set; }
        public string logistic { get; set; }
        public string shop_id { get; set; }
        public string origin_id { get; set; }
        public string receiver_longitude { get; set; }
        public string receiver_latitude { get; set; }
        public string receiver_address { get; set; }
        public string receiver_name { get; set; }
        public string receiver_phone { get; set; }
        public int? goods_vaule { get; set; }
        public int? goods_weight { get; set; }
        public int? goods_category { get; set; }
        public int? delivery_time { get; set; }
        public string map_type { get; set; }
    }
}