using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCampaigns.Dal;
namespace ProjectCampaigns.Entities
{
    public class users
    {
        string connectionString = "Integrated Security = SSPI; Persist Security Info=False;Initial Catalog = campaign ; Data Source = localhost\\sqlEXPRESS";
        public void CreateUsers(string userName, string cellphoneNumber, string email, string UserType)
        {



            string insert = "insert into Users values (@userName,@cellphoneNumber,@email,@UserType)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(insert, connection))
                    {
                        connection.Open();

                        //Add the user message data as parameters to the command
                        command.Parameters.AddWithValue("@userName", userName);
                        command.Parameters.AddWithValue("@cellphoneNumber",cellphoneNumber);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@UserType", UserType);
                   

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
