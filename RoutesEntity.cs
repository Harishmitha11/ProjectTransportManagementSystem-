using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementEntityLibrary
{
    public class RoutesEntity
    {
        private int routeId;
        private string startDestination;
        private string endDestination;
        private decimal distance;

        public int RoutId
        {
            set {  routeId = value; }
            get { return routeId; }
        }

        public string StartDestination
        {
            set {  startDestination = value; }
            get { return startDestination; }
        }

        public string EndDestination
        {
            set { endDestination = value; }
            get { return endDestination; }
        }

        public decimal Distance
        {
            set { distance = value; }
            get { return distance; }
        }

        public RoutesEntity() { }

        public RoutesEntity(int routeId,string startDestination,string endDestination,decimal distance)
        {
            this.routeId = routeId;
            this.startDestination = startDestination;
            this.endDestination = endDestination;
            this.distance = distance;
        }
    }
}
