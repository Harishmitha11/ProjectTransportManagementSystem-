using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementExceptionLibrary
{
    public class BookingNotFoundException : Exception

    {
        public BookingNotFoundException() : base() { }

        public BookingNotFoundException(string message) : base(message) { }

        public BookingNotFoundException(string message,Exception innerException) : base(message, innerException) { }

    }
}


