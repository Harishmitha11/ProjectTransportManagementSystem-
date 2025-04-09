using System;
namespace TransportManagementExceptionLibrary
{
    public class VehicleNotFoundException : Exception
    {
        public VehicleNotFoundException() : base() { }

        public VehicleNotFoundException(string message) : base(message) { }

        public VehicleNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
