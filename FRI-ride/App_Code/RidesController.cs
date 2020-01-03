using FRI_ride.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductsApp.Controllers
{
    public class RidesController : ApiController
    {


        Rides[] rides;
        

        public IEnumerable<Rides> getAllRides()
        {
            string connectionString = @"Server=tcp:fri-ride.database.windows.net,1433;Initial Catalog=FRI-ride;Persist Security Info=False;User ID=zm8184;Password=Lojze4bojze;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            string queryString = "SELECT COUNT(*) FROM oglas;";
            int n = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                try
                {
                    conn.Open();
                    n = (int)cmd.ExecuteScalar();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            rides = new Rides[n];
            int i = 0;

            queryString = "SELECT * FROM oglas;";

            using (SqlConnection connection = new SqlConnection(
               connectionString))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        
                        rides[i] = new Rides { Id_oglas = (int)reader[0],  Id_voznik = (int) reader[1], Cas_datum = (string) reader[3], Lokacija = (string)reader[2]};
                        i++;
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }





            return rides;
        }


    }
}