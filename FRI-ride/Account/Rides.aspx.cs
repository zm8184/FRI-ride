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

    }


    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {
         
    }


    protected void DataList_projects_ItemCommand(object source, DataListCommandEventArgs e)
    {

        if (e.CommandName == "getID")
        {
            if (User.Identity.GetUserName() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alert", "alert('You have to be logged in.')", true);
                String url = "~/Account/Login";
                IdentityHelper.RedirectToReturnUrl(url, response: Response);
            }
            else
            {
                string strId = DataList1.DataKeys[e.Item.ItemIndex].ToString();

                string connectionString = @"Server=tcp:fri-ride.database.windows.net,1433;Initial Catalog=FRI-ride;Persist Security Info=False;User ID=zm8184;Password=Lojze4bojze;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                string username = User.Identity.GetUserName();

                string queryString = "select id_uporabnik from uporabnik where username='" + username + "';";

                int user_id = 0;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    try
                    {
                        conn.Open();
                        user_id = (int)cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                queryString = "insert into prevoz(id_oglas, id_uporabnik) values ('" + strId + "','" + user_id + "'); ";

                CreateCommand(queryString, connectionString);


                String url = "~/Account/ReservationComplete?id=" + strId;
                IdentityHelper.RedirectToReturnUrl(url, response: Response);
            }

        }

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
}