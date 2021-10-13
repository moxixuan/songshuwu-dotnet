using System;
using System.Collections.Generic;
using System.Text;

namespace songshuwu.client
{
    public class OrderAddWithoutShopOutput
    {
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
        public decimal? distance { get; set; }
        public decimal? coupon { get; set; }
        public decimal? amount { get; set; }
    }
}
