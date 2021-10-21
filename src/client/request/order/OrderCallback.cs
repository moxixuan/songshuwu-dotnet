using System;
using System.Collections.Generic;
using System.Text;

namespace songshuwu.client.request.order
{
    public abstract class OrderCallback
    {
        public string order_id { get; set; }
        public string origin_id { get; set; }
        public string logistic { get; set; }
        public string logistic_no { get; set; }
        public int status { get; set; }
        public string status_desc { get; set; }
        public int distance { get; set; }
        public int rider_id { get; set; }
        public string rider_name { get; set; }
        public string rider_phone { get; set; }
        public string content { get; set; }
        public decimal? delivery_amount { get; set; }
        public decimal? amount { get; set; }
        public decimal? coupon { get; set; }
        public decimal? cancel_amount { get; set; }
        public int ctime { get; set; }
        public int? reject_code { get; set; }
        public string reject_msg { get; set; }
        public int? cancel_reason_code { get; set; }
        public string cancel_reason { get; set; }
        public string sign { get; set; }
    }
}
