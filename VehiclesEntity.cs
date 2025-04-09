namespace TransportManagementEntityLibrary
{
    public class VehiclesEntity
    {
        private int vehicleId;
        private string model;
        private decimal capacity;
        private string type;
        private string status;

        public int VehicleId
        {
            set { vehicleId = value; }
            get { return vehicleId; }
        }
        public string Model
        {
            set { model = value; }
            get { return model; }
        }
        public decimal Capacity
        {
            set { capacity = value; }
            get { return capacity; }
        }

        public string Type
        {
            set { type = value; }
            get { return type; }
        }

        public string Status
        {
            set { status = value; }
            get { return status; }   
        }

        public VehiclesEntity() { }
        public VehiclesEntity(int vehicleId,string model,decimal capacity,string type,string status)
        {
            this.vehicleId = vehicleId;
            this.model = model;
            this.capacity = capacity;
            this.type = type;
            this.status = status;

        } 
    }

}
