namespace songshuwu.client
{
    public class OrderAddInput
    {
        public int dispatch_mode { get; set; }
        public string logistic { get; set; }
        public string shop_id { get; set; }
        public string shop_name { get; set; }
        public string origin_id { get; set; }
        public string order_source { get; set; }
        public string source_order_no { get; set; }
        public string order_sn { get; set; }
        public int is_subscribe { get; set; }
        public int subscribe_time { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string sender_longitude { get; set; }
        public string sender_latitude { get; set; }
        public string sender_address { get; set; }
        public string sender_phone { get; set; }
        public string receiver_longitude { get; set; }
        public string receiver_latitude { get; set; }
        public string receiver_address { get; set; }
        public string receiver_address_detail { get; set; }
        public string receiver_name { get; set; }
        public string receiver_phone { get; set; }
        public Goods goods { get; set; }
        public int? goods_value { get; set; }
        public int? goods_weight { get; set; }
        public int goods_category { get; set; }
        public string map_type { get; set; }
        public string callback_url { get; set; }
        public string order_remark { get; set; }
        public string return_price { get; set; }
        public string dispatch_other { get; set; }
        public int? delay_delivery { get; set; }
        public int? auto_tips { get; set; }
        public int? auto_resend { get; set; }
        public int? auto_resend_interval { get; set; }
    }
}