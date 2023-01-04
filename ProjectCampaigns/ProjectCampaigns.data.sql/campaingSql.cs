using ProjectCampaigns.Dal;
using ProjectCampaigns.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjectCampaigns.Dal.SqlQuery;

namespace ProjectCampaigns.data.sql
{
    public class campaingSql
    {
       public static string  connectionString = "Integrated Security = SSPI; Persist Security Info=False;Initial Catalog = campaign ; Data Source = localhost\\sqlEXPRESS";

        public Dictionary<int, Campaign> AddCampaingToDictionary(SqlDataReader reader)
        {
            //Create a dictionary that will contain the products data. The key of the dictionary is the product's ID and the value is the Product object
            Dictionary<int, Campaign> dictionsryCampaing = new Dictionary<int, Campaign>();

            //Clear the dictionary before adding new products.
            dictionsryCampaing.Clear();

            while (reader.Read())
            {
                Campaign readCampaign = new Campaign();

                readCampaign.usreId = reader.GetInt32(reader.GetOrdinal("ProductID"));
                readCampaign.associationName = reader.GetString(reader.GetOrdinal("associationName"));
                readCampaign.email = reader.GetString(reader.GetOrdinal("email"));
                readCampaign.uri = reader.GetString(reader.GetOrdinal("uri"));
                readCampaign.hashtag = reader.GetString(reader.GetOrdinal("hashtag"));




                //Add the new Product object to the dictionary
                dictionsryCampaing.Add(readCampaign.usreId, readCampaign);
            }

            return dictionsryCampaing;
        }

        public static void LoadingCampingsDetails(string SqlQuery, SetDataReader_delegate Ptrfunc)
        {
        


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = SqlQuery;

                // Adapter
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    //Reader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Ptrfunc(reader);

                    }
                }
            }
        }

       /* public Dictionary<int, Campaign> LoadingCampingsDetails()
        {
            Dictionary<int, Campaign> retDictionary = null;

            try
            {
                string sqlQuery = "select * from Campaigns"; ;
                retDictionary = (Dictionary<int, Campaign>)SqlQuery.RunCommandResult(sqlQuery, AddCampaingToDictionary);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return (Dictionary<int, Campaign>)retDictionary;
        }
       */
    }
}

