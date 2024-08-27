using System;
using System.Collections.Generic;
using WarnerTransitLibrary;
using Xunit;

namespace WarnerTransitTests
{
    public class DeliveryRepositoryTests
    {
        [Fact]
        public void AddDelivery_ShouldAddDelivery()
        {
            // Arrange
            var repo = new DeliveryRepository();
            var delivery = new Delivery
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(1),
                Status = DeliveryStatus.Scheduled,
                ItemNumber = 1,
                ItemQuantity = 10,
                CustomerID = 123
            };

            
            repo.AddDelivery(delivery);
            var deliveries = repo.GetAllDeliveries();

            // Asserting the dilvi
            Assert.Contains(delivery, deliveries);
        }

        [Fact]
        public void UpdateDeliveryStatus_ShouldUpdateStatus()
        {
            
            var repo = new DeliveryRepository();
            var delivery = new Delivery
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(1),
                Status = DeliveryStatus.Scheduled,
                ItemNumber = 1,
                ItemQuantity = 10,
                CustomerID = 123
            };
            repo.AddDelivery(delivery);

            
            var result = repo.UpdateDeliveryStatus(1, DeliveryStatus.Complete);

            // Assert
            Assert.True(result);
            Assert.Equal(DeliveryStatus.Complete, delivery.Status);
        }

        [Fact]
        public void CancelDelivery_ShouldCancelDelivery()
        {
           
            var repo = new DeliveryRepository();
            var delivery = new Delivery
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(1),
                Status = DeliveryStatus.Scheduled,
                ItemNumber = 1,
                ItemQuantity = 10,
                CustomerID = 123
            };
            repo.AddDelivery(delivery);

            
            var result = repo.CancelDelivery(1);

            
            Assert.True(result);
            Assert.Equal(DeliveryStatus.Canceled, delivery.Status);
        }
    }
}
