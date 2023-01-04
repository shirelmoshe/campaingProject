using ProjectCampaigns.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCampaigns.Model;
using System.Data.SqlClient;
using System.Security.Policy;
using ProjectCampaigns.data.sql;

namespace ProjectCampaigns.Entities
{
	public class Campaigns

	{
        Dictionary<int, Campaign> dictionsryCampaing = new Dictionary<int, Campaign>();
        string connectionString = "Integrated Security = SSPI; Persist Security Info=False;Initial Catalog = campaign ; Data Source = localhost\\sqlEXPRESS";
        public void InsertUserMessageToDb(string associationName, string email, string uri, string hashtag)
		{
           

            string insert = "insert into  Campaigns values (@associationName,@email,@uri,@hashtag)";

            try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					using (SqlCommand command = new SqlCommand(insert, connection))
					{
						connection.Open();

                        //Add the user message data as parameters to the command
                     
                        command.Parameters.AddWithValue("@associationName", associationName);
						command.Parameters.AddWithValue("@email", email);
						command.Parameters.AddWithValue("@uri", uri);
						command.Parameters.AddWithValue("@hashtag", hashtag);

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

        public void ReadCampingFromDb(SqlDataReader reader)
        {

            //Clear Dictionary Before Inserting Information From Sql Server
            dictionsryCampaing.Clear();


            while (reader.Read())
            {
                Campaign readCampaing = new Campaign();

                readCampaing.usreId = reader.GetInt32(0);
                readCampaing.associationName = reader.GetString(1);
                readCampaing.email = reader.GetString(2);
                readCampaing.uri = reader.GetString(3);
                readCampaing.hashtag = reader.GetString(4);


                //Cheking If Hashtable contains the key
                if (dictionsryCampaing.ContainsKey(readCampaing.usreId))
                {
                    //key already exists
                }
                else
                {
                    //Filling a hashtable
                    dictionsryCampaing.Add(readCampaing.usreId, readCampaing);
                }

            }


        }
        public Dictionary<int, Campaign> CampaignDetailsfromSQL()
        {
            try
            {
                Dictionary<int, Campaign> ret;
                campaingSql.LoadingCampingsDetails("select * from Campaigns", ReadCampingFromDb);

                return dictionsryCampaing;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }



        }


        
    }

}

		