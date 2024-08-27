using System.Collections.Generic;
using System.Linq;

namespace WarnerTransitLibrary
{
    public class DeliveryRepository
    {
        private List<Delivery> _deliveries = new List<Delivery>();

        public void AddDelivery(Delivery delivery)
        {
            _deliveries.Add(delivery);
        }

        public List<Delivery> GetAllDeliveries()
        {
            return _deliveries;
        }

        public List<Delivery> GetDeliveriesByStatus(DeliveryStatus status)
        {
            return _deliveries.Where(d => d.Status == status).ToList();
        }

        public bool UpdateDeliveryStatus(int itemNumber, DeliveryStatus newStatus)
        {
            var delivery = _deliveries.FirstOrDefault(d => d.ItemNumber == itemNumber);
            if (delivery != null)
            {
                delivery.Status = newStatus;
                return true;
            }
            return false;
        }

        public bool CancelDelivery(int itemNumber)
        {
            var delivery = _deliveries.FirstOrDefault(d => d.ItemNumber == itemNumber);
            if (delivery != null)
            {
                delivery.Status = DeliveryStatus.Canceled;
                return true;
            }
            return false;
        }
    }
}
