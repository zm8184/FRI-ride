using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using FRI_ride;
using System.Data.SqlClient;

public partial class Account_Register : Page
{
    private static void CreateCommand(string queryString,
    string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(
                   connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
        }
    }

    protected void CreateUser_Click(object sender, EventArgs e)
    {
        string queryString = "insert into uporabnik(ime, priimek, tel_stevilka, mail, username, passwd) values('"  + Name.Text  + "','" + Surname.Text + "','" + Phone.Text  + "','" + Mail.Text + "','" + UserName.Text + "','" + Password.Text + "');" ;
        string connectionString1 = @"Server=tcp:fri-ride.database.windows.net,1433;Initial Catalog=fri-ride;Persist Security Info=False;User ID=friride;Password=Admin123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        CreateCommand(queryString, connectionString1);
        var manager = new UserManager();
        var user = new ApplicationUser() { UserName = UserName.Text };
        IdentityResult result = manager.Create(user, Password.Text);
        if (result.Succeeded)
        {
            IdentityHelper.SignIn(manager, user, isPersistent: false);
            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        }
        else
        {
            ErrorMessage.Text = result.Errors.FirstOrDefault();
        }
    }
}