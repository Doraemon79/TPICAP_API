namespace BookOrder_Test8.Models
{
    public struct SellOrder
    {
        public string Id { get; set; }
        public string Company { get; set; }
        public double Notional { get; set; }
        public string OrderType { get; set; }
        public TimeSpan OrderDateTime { get; set; }
    }
}
