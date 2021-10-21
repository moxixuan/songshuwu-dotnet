namespace songshuwu.client
{
    public class OrderCancelInput
    {
        public int? order_id { get; set; }
        public string origin_id { get; set; }
        public string cancel_reason { get; set; }
        public int? cancel_reason_code { get; set; }
    }
}