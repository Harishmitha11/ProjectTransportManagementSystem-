using System.Collections.Generic;
using TransportManagementDaoLibrary;
using TransportManagementEntityLibrary;

namespace TransportManagementHelperLibrary
{
    public class TransportServiceHelper
    {
        private ITransportManagementService service;

        public TransportServiceHelper()
        {
            service = new TransportManagementServiceImpl();
        }

        public bool AddVehicle(VehiclesEntity vehicle)
        {
            return service.AddVehicle(vehicle);
        }

        public bool UpdateVehicle(VehiclesEntity vehicle)
        {
            return service.UpdateVehicle(vehicle);
        }

        public bool DeleteVehicle(int vehicleId)
        {
            return service.DeleteVehicle(vehicleId);
        }

        public bool ScheduleTrip(int vehicleId, int routeId, string departureDate, string arrivalDate)
        {
            return service.ScheduleTrip(vehicleId, routeId, departureDate, arrivalDate);
        }

        public bool CancelTrip(int tripId)
        {
            return service.CancelTrip(tripId);
        }

        public bool BookTrip(int passengerId, string bookingDate)
        {
            return service.BookTrip(passengerId, bookingDate);
        }

        public bool CancelBooking(int bookingId)
        {
            return service.CancelBooking(bookingId);
        }

        public List<BookingsEntity> GetBookingsByTrip(int tripId)
        {
            return service.GetBookingsByTrip(tripId);
        }

        public List<BookingsEntity> GetBookingsByPassenger(int passengerId)
        {
            return service.GetBookingsByPassenger(passengerId);
        }

        public bool AllocateDriver(int tripId, int driverId)
        {
            return service.AllocateDriver(tripId, driverId);
        }

        public bool DeallocateDriver(int tripId)
        {
            return service.DeallocateDriver(tripId);
        }

        public List<DriversEntity> GetAvailableDrivers()
        {
            return service.GetAvailableDrivers();
        }
    }
}