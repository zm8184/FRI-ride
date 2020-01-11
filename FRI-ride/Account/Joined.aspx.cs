using FRI_ride;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Account_Rides : System.Web.UI.Page
{
    public int user_id = 0;
    public string query = "";
    private string strId = "37";
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

    protected void Page_Load(object sender, EventArgs e)
    {
        int userId = 1;

        string connectionString = @"Server=tcp:fri-ride.database.windows.net,1433;Initial Catalog=fri-ride;Persist Security Info=False;User ID=friride;Password=Admin123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        string username = User.Identity.GetUserName();

        string queryString = "SELECT voznik.id_voznik FROM voznik JOIN uporabnik ON uporabnik.id_uporabnik = voznik.id_uporabnik WHERE uporabnik.username = '" + username + "';";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(queryString, conn);
            try
            {
                conn.Open();
                userId = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        SqlDataSource1.SelectParameters.Add("userId", userId.ToString());

        SqlDataSource1.SelectCommand = "SELECT DISTINCT o.id_oglas, o.cas_datum AS date, o.lokacija AS location FROM uporabnik AS u LEFT OUTER JOIN prevoz AS p ON p.id_uporabnik = u.id_uporabnik LEFT OUTER JOIN oglas AS o ON o.id_oglas = p.id_oglas LEFT OUTER JOIN voznik AS v ON v.id_voznik = o.id_voznik WHERE v.id_voznik = @userId;";
      
    }


    protected void DataList_SelectedIndexChanged(object sender, EventArgs e)
    {
         
    }


    protected void DataList_projects_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "getID")
        {
            strId = DataList1.DataKeys[e.Item.ItemIndex].ToString();
            String url = "~/Account/Joined2?id=" + strId;
            IdentityHelper.RedirectToReturnUrl(url, response: Response);
        }


    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {  
        /*String url = "~/Account/Joined2?id=" + strId;
        IdentityHelper.RedirectToReturnUrl(url, response: Response);*/
    }
}