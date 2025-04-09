using TransportManagementEntityLibrary;
using TransportManagementUtilLibrary;
using TransportManagementHelperLibrary;


namespace TransportManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = DBPropertyUtil.AppConnection();
            Console.WriteLine("Connection created successfully.");
            TransportServiceHelper helper = new TransportServiceHelper();
            while (true){
                Console.WriteLine("\n==== Transport Management System ====");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. Update Vehicle");
                Console.WriteLine("3. Delete Vehicle");
                Console.WriteLine("4. Schedule Trip");
                Console.WriteLine("5. Cancel Trip");
                Console.WriteLine("6. Book Trip");
                Console.WriteLine("7. Cancel Booking");
                Console.WriteLine("8. Allocate Driver to Trip");
                Console.WriteLine("9. Deallocate Driver from Trip");
                Console.WriteLine("10. View Bookings by Passenger");
                Console.WriteLine("11. View Bookings by Trip");
                Console.WriteLine("12. View Available Drivers");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
               
                    switch (choice)
                    {
                        case 1:

                            VehiclesEntity vehicle = new VehiclesEntity();
                            Console.WriteLine("Enter Model : ");
                            vehicle.Model = Console.ReadLine();
                            Console.WriteLine("Enter Capacity : ");
                            vehicle.Capacity = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Type : ");
                            vehicle.Type = Console.ReadLine();
                            Console.WriteLine("Enter Status : ");
                            vehicle.Status = Console.ReadLine();
                            if (helper.AddVehicle(vehicle))
                            {
                                Console.WriteLine("Vehicle added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to add vehicle.");
                            }

                        
                        break;

                        case 2:

                            VehiclesEntity vehicleToUpdate = new VehiclesEntity();
                            Console.WriteLine("Enter Vehicle Id to update: ");
                            vehicleToUpdate.VehicleId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Updated Model: ");
                            vehicleToUpdate.Model = Console.ReadLine();
                            Console.WriteLine("Enter Updated Capacity: ");
                            vehicleToUpdate.Capacity = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Updated Type: ");
                            vehicleToUpdate.Type = Console.ReadLine();
                            Console.WriteLine("Enter Updated Status: ");
                            vehicleToUpdate.Status = Console.ReadLine();
                            if (helper.UpdateVehicle(vehicleToUpdate))
                            {
                                Console.WriteLine("Vehicle updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to update vehicle.");
                            }


                            break;


                        case 3:

                            Console.WriteLine("Enter Vehicle Id to delete: ");
                            int deleteVehicleId = Convert.ToInt32(Console.ReadLine());


                            if (helper.DeleteVehicle(deleteVehicleId))
                            {
                                Console.WriteLine("Vehicle deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to delete vehicle.");
                            }


                            break;


                        case 4:
                            Console.WriteLine("Enter Vehicle ID: ");
                            int vehicleId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Route ID: ");
                            int routeId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Departure Date (yyyy-MM-dd): ");
                            string departureDate = Console.ReadLine();
                            Console.WriteLine("Enter Arrival Date (yyyy-MM-dd): ");
                            string arrivalDate = Console.ReadLine();
                            if (helper.ScheduleTrip(vehicleId, routeId, departureDate, arrivalDate))
                            {
                                Console.WriteLine("Trip scheduled successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to schedule trip.");
                            }


                            break;



                        case 5:
                            Console.WriteLine("Enter Trip ID to cancel: ");
                            int cancelTripId = Convert.ToInt32(Console.ReadLine());

                            if (helper.CancelTrip(cancelTripId))
                            {
                                Console.WriteLine("Trip canceled successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to cancel trip.");
                            }


                            break;

                        case 6:
                            
                            Console.WriteLine("Enter Passenger ID: ");
                            int passengerId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Booking Date (yyyy-MM-dd): ");
                            string bookingDate = Console.ReadLine();
                            if (helper.BookTrip( passengerId, bookingDate))
                            {
                                Console.WriteLine("Trip booked successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to book trip.");
                            }

                             break;

                        case 7:
                            Console.WriteLine("Enter Booking ID to cancel: ");
                            int bookingId = Convert.ToInt32(Console.ReadLine());
                            if (helper.CancelBooking(bookingId))
                            {
                                Console.WriteLine("Booking canceled successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to cancel booking.");
                            }

                             break;

                    case 8:
                        Console.WriteLine("Enter Trip ID: ");
                        int tripIdToAllocate = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Driver ID to allocate: ");
                        int driverIdToAllocate = Convert.ToInt32(Console.ReadLine());

                        if (helper.AllocateDriver(tripIdToAllocate, driverIdToAllocate))
                        {
                            Console.WriteLine("Driver allocated successfully to the trip.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to allocate driver.");
                        }
                        break;


                    case 9:
                        Console.WriteLine("Enter Trip ID to deallocate driver: ");
                        int tripIdToDeallocate = Convert.ToInt32(Console.ReadLine());

                        if (helper.DeallocateDriver(tripIdToDeallocate))
                        {
                            Console.WriteLine("Driver deallocated successfully from the trip.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to deallocate driver.");
                        }
                        break;



                    case 10:
                            Console.WriteLine("Enter Passenger ID to view bookings: ");
                            int pid = Convert.ToInt32(Console.ReadLine());
                            List<BookingsEntity> bookingsByPassenger = helper.GetBookingsByPassenger(pid);
                            if (bookingsByPassenger.Count == 0)
                            {
                                Console.WriteLine("No bookings found for the passenger.");
                            }
                            else
                            {
                                Console.WriteLine("\n{0,-15} {1,-10} {2,-15} {3,-20}", "Booking ID", "Trip ID", "Passenger ID", "Booking Date");
                                Console.WriteLine(new string('-', 65));

                                foreach (var b in bookingsByPassenger)
                                {
                                    Console.WriteLine("{0,-15} {1,-10} {2,-15} {3,-20}",
                                        b.BookingId, b.TripId, b.PassengerId, b.BookingDate.ToString("yyyy-MM-dd"));
                                }
                            }
                                break;

                        case 11:
                                Console.WriteLine("Enter Trip ID to view bookings: ");
                                int tid = Convert.ToInt32(Console.ReadLine());
                                List<BookingsEntity> bookingsByTrip = helper.GetBookingsByTrip(tid);
                                if (bookingsByTrip.Count == 0)
                                {
                                    Console.WriteLine("No bookings found for the trip.");
                                }
                                else
                                {
                                    Console.WriteLine("{0,-15} {1,-10} {2,-15} {3,-20}", "Booking ID", "Trip ID", "Passenger ID", "Booking Date");
                                    Console.WriteLine(new string('-', 65));
                                    foreach (var b in bookingsByTrip)
                                    {
                                        Console.WriteLine("{0,-15} {1,-10} {2,-15} {3,-20}", b.BookingId, b.TripId, b.PassengerId, b.BookingDate.ToString("yyyy-MM-dd"));
                                    }
                                }
                                break;

                    case 12:
                        List<DriversEntity> availableDrivers = helper.GetAvailableDrivers();

                        if (availableDrivers.Count == 0)
                        {
                            Console.WriteLine("No available drivers.");
                        }
                        else
                        {
                            Console.WriteLine("{0,-10} {1,-20} {2,-15}", "Driver ID", "Name", "Status");
                            Console.WriteLine(new string('-', 50));

                            foreach (var driver in availableDrivers)
                            {
                                Console.WriteLine("{0,-10} {1,-20} {2,-15}",
                                    driver.DriverId, driver.DriverName, driver.DriverStatus);
                            }
                        }
                        break;

                    case 0:
                                Console.WriteLine("Exiting application...");
                                return;

                        default:
                            Console.WriteLine("Invalid choice...Please try again.");
                            break;

                    }
               


            }
            
        }
    }
}
