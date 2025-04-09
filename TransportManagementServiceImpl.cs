using Microsoft.Data.SqlClient;
using TransportManagementEntityLibrary;
using TransportManagementExceptionLibrary;
using TransportManagementUtilLibrary;

namespace TransportManagementDaoLibrary
{
    public class TransportManagementServiceImpl : ITransportManagementService
    {
        public bool AddVehicle(VehiclesEntity vehicle)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = DBPropertyUtil.AppConnection();
                cmd = new SqlCommand("dbo.sp_AddVehicle", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.AddWithValue("@model", vehicle.Model);
                cmd.Parameters.AddWithValue("@capacity", vehicle.Capacity);
                cmd.Parameters.AddWithValue("@type", vehicle.Type);
                cmd.Parameters.AddWithValue("@status", vehicle.Status);

                cmd.ExecuteNonQuery();
                

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }

        }

        public bool UpdateVehicle(VehiclesEntity vehicle)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;

            try
            {

                cn = DBPropertyUtil.AppConnection();
                cmd = new SqlCommand("dbo.sp_UpdateVehicle", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.AddWithValue("@VehicleId", vehicle.VehicleId);
                cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                cmd.Parameters.AddWithValue("@Capacity", vehicle.Capacity);
                cmd.Parameters.AddWithValue("@Type", vehicle.Type);
                cmd.Parameters.AddWithValue("@Status", vehicle.Status);

                cmd.ExecuteNonQuery();
                
                return true;
            }
            catch (SqlException)
            {
                throw new VehicleNotFoundException("Vehicle ID not found for update.");
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
           

        }

        public bool DeleteVehicle(int vehicleId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = DBPropertyUtil.AppConnection();
                cmd = new SqlCommand("dbo.sp_DeleteVehicle", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cn.Close();
                cn.Dispose();

                return true;
            }
            catch (SqlException)
            {
                throw new VehicleNotFoundException("Vehicle ID not found for delete");
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();

            }


        }
        
        public bool ScheduleTrip(int vehicleId,int routeId,string departureDate,string arrivalDate)
        {

            SqlConnection cn = null;
            SqlCommand cmd = null;

            try
            {
                cn = DBPropertyUtil.AppConnection();
                cmd = new SqlCommand("dbo.sp_ScheduleTrip", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();

                DateTime depDate = DateTime.Parse(departureDate);
                DateTime arrDate = DateTime.Parse(arrivalDate);

                cmd.Parameters.AddWithValue("@vehicleId", vehicleId);
                cmd.Parameters.AddWithValue("@routeId", routeId);
                cmd.Parameters.AddWithValue("@departureDate", depDate);
                cmd.Parameters.AddWithValue("@arrivalDate", arrDate);

                cmd.ExecuteNonQuery();
                


                return true;
            }
            catch (SqlException)
            {
                throw new VehicleNotFoundException("Vehicle ID not found for delete");
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();

            }


        }

        public bool CancelTrip(int tripId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;

            try
            {

                cn = DBPropertyUtil.AppConnection();
                cmd = new SqlCommand("dbo.sp_CancelTrip", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.AddWithValue("@tripId", tripId);

                cmd.ExecuteNonQuery();
                

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();

            }

        }

        public bool BookTrip( int passengerId,string bookingDate)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;

            try
            {
                cn = DBPropertyUtil.AppConnection();
                cmd = new SqlCommand("dbo.sp_BookTrip", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();

                DateTime bookDate = DateTime.Parse(bookingDate);

                
                cmd.Parameters.AddWithValue("@passengerId", passengerId);
                cmd.Parameters.AddWithValue("@bookingDate", bookDate);

                cmd.ExecuteNonQuery();
                

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();

            }


        }

        public bool CancelBooking(int bookingId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {


                cn = DBPropertyUtil.AppConnection();
                cmd = new SqlCommand("dbo.sp_CancelBooking", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.AddWithValue("@bookingId", bookingId);

                int rowsAffected = cmd.ExecuteNonQuery();
               

                return true;
            }
            catch (SqlException)
            {
                throw new BookingNotFoundException("Booking ID not found for cancel");
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();

            }



        }

        public bool AllocateDriver(int tripId, int driverId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = DBPropertyUtil.AppConnection();
                cmd = new SqlCommand("dbo.sp_AllocateDriver", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.AddWithValue("@tripId", tripId);
                cmd.Parameters.AddWithValue("@driverId", driverId);

                cmd.ExecuteNonQuery();
               

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();

            }
        }


        public bool DeallocateDriver(int tripId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = DBPropertyUtil.AppConnection();
                cmd = new SqlCommand("dbo.sp_DeallocateDriver", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.AddWithValue("@tripId", tripId);

                cmd.ExecuteNonQuery();
               

                return true;
            }
            
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();

            }
        }

        public List<BookingsEntity> GetBookingsByPassenger(int passengerId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                List<BookingsEntity> list = new List<BookingsEntity>();
                cn = DBPropertyUtil.AppConnection();
                cmd = new SqlCommand("dbo.sp_GetBookingByPassenger", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.AddWithValue("@passengerId", passengerId);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    BookingsEntity booking = new BookingsEntity();
                    booking.PassengerId = Convert.ToInt32(dr["passengerId"]);
                    list.Add(booking);
                }
                dr.Close();
              
                return list;
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();

            }



        }

        public List<BookingsEntity>  GetBookingsByTrip(int tripId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                List<BookingsEntity> list = new List<BookingsEntity>();
                cn = DBPropertyUtil.AppConnection();
                cmd = new SqlCommand("dbo.sp_GetBookingsByTrip", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.AddWithValue("@tripId", tripId);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    BookingsEntity booking = new BookingsEntity();
                    booking.TripId = Convert.ToInt32(dr["tripId"]);
                    list.Add(booking);
                }
                dr.Close();
               
                return list;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();

            }

        }

        public List<DriversEntity> GetAvailableDrivers()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                List<DriversEntity> drivers = new List<DriversEntity>();

                cn = DBPropertyUtil.AppConnection();
                cmd = new SqlCommand("dbo.sp_GetAvailableDrivers", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DriversEntity driver = new DriversEntity
                    {
                        DriverId = Convert.ToInt32(dr["DriverId"]),
                        DriverName = dr["DriverName"].ToString(),
                        DriverStatus = Enum.Parse<DriverStatusEnum>(dr["DriverStatus"].ToString(), ignoreCase: true)
                    };

                    drivers.Add(driver);
                }

                dr.Close();
                cmd.Dispose();
                cn.Close();
                cn.Dispose();

                return drivers;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();

            }
        }

    }


}


