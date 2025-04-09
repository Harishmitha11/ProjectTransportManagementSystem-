using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementEntityLibrary
{
    public enum DriverStatusEnum
    {
        Available,
        Allocated
    }
    public class DriversEntity
    {
      
            private int driverId;
            private string driverName;
            private DriverStatusEnum driverStatus;

            public int DriverId
            {
                set { driverId = value; }
                get { return driverId; }
            }

            public string DriverName
            {
                set { driverName = value; }
                get { return driverName; }
            }

            public DriverStatusEnum DriverStatus
            {
                set { driverStatus = value; }
                get { return driverStatus; }
            }

            public DriversEntity()
            {

            }

            public DriversEntity(int driverId, string driverName, DriverStatusEnum driverStatus)
            {
                DriverId = driverId;
                DriverName = driverName;
                DriverStatus = driverStatus;
            }
        }
}
