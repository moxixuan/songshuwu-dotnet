using System.Collections.Generic;

namespace songshuwu.client
{
    public class OrderPriceOutput
    {
        public string min_logistic { get; set; }
        public decimal min_price { get; set; }
        public decimal max_price { get; set; }
        public decimal coupon { get; set; }

        public List<OrderPriceDetail> detail { get; set; }
    }
}