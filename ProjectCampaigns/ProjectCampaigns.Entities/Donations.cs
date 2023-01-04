using ProjectCampaigns.Dal;
using ProjectCampaigns.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCampaigns.Entities
{
    public class Donations
    {

        string connectionString = "Integrated Security = SSPI; Persist Security Info=False;Initial Catalog = campaign ; Data Source = localhost\\sqlEXPRESS";
        public void CreateDonation(string CompanyName, string CampaignName, string Product ,string Email, string Price)
        {
       
           

            string insert = "insert into Donation values (@CompanyName,@Product,@Email,@Price,@CampaignName)"; 

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(insert, connection))
                    {
                        connection.Open();

                        //Add the user message data as parameters to the command
                        command.Parameters.AddWithValue("@CompanyName", CompanyName);
                        command.Parameters.AddWithValue("@Product", Product);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@Price", Price);
                        command.Parameters.AddWithValue("@CampaignName", CampaignName);

                        //Execute the command
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       



    }






}



    

