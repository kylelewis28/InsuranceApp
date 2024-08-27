using WarnerTransitLibrary;

namespace WarnerTransitApp
{
    public class ProgramUI
    {
        private DeliveryRepository _repo = new DeliveryRepository();

        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Hello, what would you like to do?");
                Console.WriteLine("1. Add a new delivery");
                Console.WriteLine("2. List all deliveries");
                Console.WriteLine("3. Update delivery status");
                Console.WriteLine("4. Cancel a delivery");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddDelivery();
                        break;
                    case "2":
                        ListAllDeliveries();
                        break;
                    case "3":
                        UpdateDeliveryStatus();
                        break;
                    case "4":
                        CancelDelivery();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void AddDelivery()
        {
            Console.WriteLine("Enter the order date (yyyy-mm-dd):");
            DateTime orderDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the delivery date (yyyy-mm-dd):");
            DateTime deliveryDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the item number:");
            int itemNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the item quantity:");
            int itemQuantity = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the customer ID:");
            int customerID = int.Parse(Console.ReadLine());

            Delivery delivery = new Delivery
            {
                OrderDate = orderDate,
                DeliveryDate = deliveryDate,
                Status = DeliveryStatus.Scheduled,
                ItemNumber = itemNumber,
                ItemQuantity = itemQuantity,
                CustomerID = customerID
            };

            _repo.AddDelivery(delivery);
        }

        private void ListAllDeliveries()
        {
            var deliveries = _repo.GetAllDeliveries();
            foreach (var delivery in deliveries)
            {
                Console.WriteLine($"Order Date: {delivery.OrderDate}, Delivery Date: {delivery.DeliveryDate}, Status: {delivery.Status}, Item Number: {delivery.ItemNumber}, Item Quantity: {delivery.ItemQuantity}, Customer ID: {delivery.CustomerID}");
            }
        }

        private void UpdateDeliveryStatus()
        {
            Console.WriteLine("Enter the item number of the delivery to update:");
            int itemNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the new status (Scheduled, EnRoute, Complete, Canceled):");
            DeliveryStatus newStatus = (DeliveryStatus)Enum.Parse(typeof(DeliveryStatus), Console.ReadLine(), true);

            if (_repo.UpdateDeliveryStatus(itemNumber, newStatus))
            {
                Console.WriteLine("Delivery status updated.");
            }
            else
            {
                Console.WriteLine("Delivery not found.");
            }
        }

        private void CancelDelivery()
        {
            Console.WriteLine("Enter the item number of the delivery to cancel:");
            int itemNumber = int.Parse(Console.ReadLine());

            if (_repo.CancelDelivery(itemNumber))
            {
                Console.WriteLine("Delivery canceled.");
            }
            else
            {
                Console.WriteLine("Delivery not found.");
            }
        }
    }
}
