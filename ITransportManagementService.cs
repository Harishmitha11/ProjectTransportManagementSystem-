using TransportManagementEntityLibrary;

namespace TransportManagementDaoLibrary
{
    public interface ITransportManagementService
    {
        public bool AddVehicle(VehiclesEntity vehicle);
        public bool UpdateVehicle(VehiclesEntity vehicle);
        public bool DeleteVehicle(int vehicleId);
        public bool ScheduleTrip(int vehicleId, int routeId, string departureDate, string arrivalDate);
        public bool CancelTrip(int tripId);
        public bool BookTrip(int passengerId, string bookingDate);
        public bool CancelBooking(int bookingId);
        public bool AllocateDriver(int tripId, int driverId);
        public bool DeallocateDriver(int tripId);
        public List<BookingsEntity> GetBookingsByPassenger(int passengerId);
        public List<BookingsEntity> GetBookingsByTrip(int tripId);
        public List<DriversEntity> GetAvailableDrivers();

    }
}


