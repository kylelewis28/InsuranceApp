namespace WarnerTransitLibrary
{
    public enum DeliveryStatus
    {
        Scheduled,
        EnRoute,
        Complete,
        Canceled
    }

    public class Delivery
    {
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DeliveryStatus Status { get; set; }
        public int ItemNumber { get; set; }
        public int ItemQuantity { get; set; }
        public int CustomerID { get; set; }
    }
}
