using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementEntityLibrary
{
    public class BookingsEntity
    {
        private int bookingId;
        private int tripId;
        private int passengerId;
        private DateTime bookingDate;
        private string status;

        public int BookingId
        {
            set { bookingId = value; }
            get { return bookingId; }
        }

        public int TripId
        {
            set { tripId = value; }
            get { return tripId; }
        }

        public int PassengerId
        {
            set { passengerId = value; }
            get { return passengerId; }
        }

        public DateTime BookingDate
        {
            set { bookingDate = value; }
            get { return bookingDate; }
        }

        public string Status
        {
            set { status = value; }
            get { return status; }
        }

        public BookingsEntity()
        {

        }

        public BookingsEntity(int bookingId, int tripId, int passengerId, DateTime bookingDate, string status)
        {
            BookingId = bookingId;
            TripId = tripId;
            PassengerId = passengerId;
            BookingDate = bookingDate;
            Status = status;
          
        }
    }
}
