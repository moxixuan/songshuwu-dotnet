using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace songshuwu.client
{
    public class OrderAddWithoutShopOutput
    {
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public long order_id { get; set; }
        public string origin_id { get; set; }
        public prices prices { get; set; }
    }

    public class prices
    {
        public string min_logistic { get; set; }
        public decimal? min_price { get; set; }
        public decimal? max_price { get; set; }
        public decimal? coupon { get; set; }
        public int? send_time { get; set; }
        public List<detail> detail { get; set; }
    }

    public class detail
    {
        public string logistic { get; set; }
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? distance { get; set; }
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? coupon { get; set; }
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? amount { get; set; }
    }
}
