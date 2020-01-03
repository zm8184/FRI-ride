using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_ReservationComplete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string connectionString = @"Server=tcp:fri-ride.database.windows.net,1433;Initial Catalog=fri-ride;Persist Security Info=False;User ID=friride;Password=Admin123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        string queryString = "SELECT uporabnik.ime, uporabnik.priimek, uporabnik.tel_stevilka, uporabnik.mail, avto.znamka, avto.model, avto.reg_stevilka, oglas.cas_datum, oglas.lokacija FROM uporabnik INNER JOIN voznik ON uporabnik.id_uporabnik = voznik.id_uporabnik INNER JOIN avto ON voznik.id_avto = avto.id_avto INNER JOIN oglas ON voznik.id_voznik = oglas.id_voznik WHERE oglas.id_oglas = " + Request.QueryString["id"] + ";";



        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    driver.Text =  (string)reader["ime"] + " " +(string)reader["priimek"];
                    phone_number.Text = (string)reader["tel_stevilka"];
                    car.Text = (string)reader["znamka"] + " " + (string)reader["model"] + ", Reg. num: " + (string)reader["reg_stevilka"];
                    time.Text = (string)reader["cas_datum"];
                    lokacija.Text = (string)reader["lokacija"];


                }
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }
        }


    }
}