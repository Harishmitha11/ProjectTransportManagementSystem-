
using Microsoft.Data.SqlClient;


namespace TransportManagementUtilLibrary
{
    public class DBPropertyUtil

    {
        public static SqlConnection AppConnection()
        {
            string cnstring = GetConnectionString();
            SqlConnection cn = new SqlConnection(cnstring);
            return cn;

        }


        public static string GetConnectionString()
        {
            return "server=.\\SQLEXPRESS;database=TransportManagementApplication;integrated security=true;trust server certificate=true";


        }

    }


}
