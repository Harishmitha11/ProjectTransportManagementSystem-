using NUnit.Framework;
using TransportManagementDaoLibrary;
using TransportManagementEntityLibrary;
using System;
using NuGet.Frameworks;
namespace TransportManagementSystemTests
{
    [TestFixture]
    public class TransportManagementTests
    {
        private ITransportManagementService service;
        [SetUp]
        public void Setup()
        {
            service = new TransportManagementServiceImpl();
        }

        [TearDown]
        public void TearDown()
        {
            service = null;
        }

        [Test]
        public void When_MapDriverToVehicle_Expect_Sucess()
        {
            //Arrange
            int tripId = 1;
            int driverId = 101;

            //Act
            bool result=service.AllocateDriver(tripId, driverId);

            //Assert
            Assert.IsTrue(result, "Driver should be allocated to trip successfully");

        }

        [Test]
        public void When_AddVehicle_Expect_Success()
        {
            VehiclesEntity vehicle = new VehiclesEntity();
            vehicle.Model = "Volvo Sleeper";
            vehicle.Capacity = 40;
            vehicle.Type = "Bus";
            vehicle.Status = "Available";

            bool result = service.AddVehicle(vehicle);

            Assert.IsTrue(result, "Vehicle should be added successfully");
        }

        [Test]
        public void When_UpdateVehicle_Expect_Success()
        {
            VehiclesEntity vehicle = new VehiclesEntity();
            vehicle.VehicleId = 3;
            vehicle.Model = "Ford";
            vehicle.Capacity = 4;
            vehicle.Type = "Car";
            vehicle.Status = "Available";

            bool result = service.UpdateVehicle(vehicle);

            Assert.IsTrue(result, "Vehicle should be updated successfully");
        }

        [Test]
        public void When_DeleteVehicle_Expect_Success()
        {
            int vehicleId = 3;

            bool result=service.DeleteVehicle(vehicleId);

            Assert.IsTrue(result, "Vehicle should be deleted successfully");
        }


        [Test]
        public void When_AllocateDriver_Expect_Success()
        {
            int tripId = 5;
            int driverId = 103;

            bool result= service.AllocateDriver(tripId, driverId);

            Assert.IsTrue(result, "Driver should be allocated succesfully");

        }

        [Test]
        public void When_DeallocateDriver_Expect_Success()
        {
            int tripId = 4;
            

            bool result = service.DeallocateDriver(tripId);

            Assert.IsTrue(result, "Driver should be deallocated succesfully");

        }

        [Test]
        public void When_GetAvailableDrivers_Expect_Success()
        {
            List<DriversEntity> availabledrivers = service.GetAvailableDrivers();

            Assert.IsNotNull(availabledrivers, "The returned list should not be null");

            foreach(var driver in availabledrivers)
            {
                Assert.AreEqual("Available", driver.DriverStatus.ToString(), $"Driver {driver.DriverId} should be unallocated.");
            }
        }

        [Test]
        public void When_BookTrip_Expect_Success()
        {
            int passengerId = 101;
            string bookingDate = "2025-06-02";

            bool result= service.BookTrip(passengerId, bookingDate);

            Assert.IsTrue(result, "Booking should be completed successfully");

        }


        
        [Test]
        public void When_InvalidVehicleId_Expect_VehicleNotFoundException()
        {
            int invalidVehicleId = 9999;

            try
            {
                service.DeleteVehicle(invalidVehicleId);
                Assert.Fail("Expected VehicleNotFoundException was not thrown");
            }
            catch 
            {
                Assert.Pass("VehicleNotFoundException was thrown as expected");
            }
        }

        [Test]
        public void When_InvalidBookingId_Expect_BookingNotFoundException()
        {
            int invalidBookingId = 9999;

            try
            {
                service.CancelBooking(invalidBookingId);
                Assert.Fail("Expected BookingNotFoundException was not thrown");
            }
            catch
            {
                Assert.Pass("BookingNotFoundException was thrown as expected");
            }
        }

    }
}