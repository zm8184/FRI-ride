using FRI_ride;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_AddRide : System.Web.UI.Page
{
    int driver_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Driver_User_Name.Text = User.Identity.GetUserName();
        SqlConnection connection = null;
        string connectionString = @"Server=tcp:fri-ride.database.windows.net,1433;Initial Catalog=fri-ride;Persist Security Info=False;User ID=friride;Password=Admin123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        string queryString = "SELECT voznik.id_voznik FROM voznik JOIN uporabnik ON uporabnik.id_uporabnik = voznik.id_uporabnik WHERE uporabnik.username = '" + User.Identity.GetUserName() + "';";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(queryString, conn);
            try
            {
                conn.Open();
                driver_id = (int) cmd.ExecuteScalar();
                Driver_User_Name.Text = User.Identity.GetUserName();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        if (Driver_User_Name.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "alert", "alert('You have to be logged in.')", true);
            String url = "~/Account/Login";
            IdentityHelper.RedirectToReturnUrl(url, response: Response);
        }
    }

    private static void CreateCommand(string queryString, string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
        }
    }

    protected void AddRide_Click(object sender, EventArgs e)
    {
        DateTime date = DateTime.Parse(DateRide.Value,
                          System.Globalization.CultureInfo.InvariantCulture);
        string queryString = "INSERT INTO oglas(id_voznik, lokacija, cas_datum) values('" + driver_id + "','" + Start_location.Text + "','" + date + "');";
        string connectionString = @"Server=tcp:fri-ride.database.windows.net,1433;Initial Catalog=FRI-ride;Persist Security Info=False;User ID=zm8184;Password=Lojze4bojze;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        CreateCommand(queryString, connectionString);
        
        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        
    }
}
