using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementEntityLibrary
{
    public class TripsEntity
    {
        private int tripId;
        private int vehicleId;
        private int routeId;
        private DateTime departureDate;
        private DateTime arrivalDate;
        private string status;
        private string tripType;
        private int maxPassengers;

        public int TripId
        {
            set { tripId = value;  }
            get { return tripId; }
        }

        public int VehicleId
        {
            set {  vehicleId = value; }
            get { return vehicleId; }
        }

        public int RouteId
        {
            set { routeId = value; }
            get { return routeId; }
        }

        public DateTime DepartureDate
        {
            set { departureDate = value; }
            get { return departureDate; }
        }

        public DateTime ArrivalDate
        {
            set { arrivalDate = value; }
            get { return arrivalDate; }
        }

        public string Status
        {
            set { status = value; }
            get { return status; }
        }

        public int MaxPassengers
        {
            set { maxPassengers = value; }
            get { return maxPassengers; }
        }

        public TripsEntity()
        {
            tripType = "Freight";
        }

        public TripsEntity(int tripId, int vehicleId, int routeId, DateTime departureDate, DateTime arrivalDate, string status, string tripType, int maxPassengers)

        {
            this.tripId = tripId;
            this.vehicleId = vehicleId;
            this.routeId = routeId;
            this.departureDate = departureDate;
            this.arrivalDate = arrivalDate;
            this.status = status;
            this.tripType = tripType;
            this.maxPassengers=maxPassengers;
        }
    }
}
