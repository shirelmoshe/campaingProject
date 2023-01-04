using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ProjectCampaigns.Model;
using System.Data.SqlClient;

namespace ProjectCampaigns.Dal
{
    public class SqlQuery

    {
        string connectionString = "Integrated Security = SSPI; Persist Security Info=False;Initial Catalog = campaign ; Data Source = localhost\\sqlEXPRESS";

		public delegate void pustDataReader_delegate(Campaign userComment, SqlCommand command);
		public delegate void pustDataReader_delegate1(Donation donorDetails, SqlCommand command);
		public delegate void SetDataReader_delegate(SqlDataReader reader);
        public delegate object SetResulrDataReader_delegate(SqlDataReader reader);

     
        
            // ...

         
       

        SqlConnection connection;
		public SqlQuery()
		{
			connection = new SqlConnection(connectionString);
		}
		public bool Connect()
		{
			try
			{
				connection.Open();
				return true;
			}
			catch (SqlException ex)
			{

				return false;
			}
		}
		public static void RunCommand(string sqlQuery, SetDataReader_delegate func)
        {
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string queryString = sqlQuery;

                // Adapter
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    //Reader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        func(reader);
                    }
                }

            }

        }

        public static object RunCommandResult(string sqlQuery, SetResulrDataReader_delegate func)
        {
            object ret = null;
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string queryString = sqlQuery;

                // Adapter
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    //Reader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ret = func(reader);
                    }
                }

            }

            return ret;
        }

		public void RunAddUserComment(string sqlQuerey, pustDataReader_delegate func, Campaign userComment)
		{
			if (!Connect()) return;
			string insert = sqlQuerey;
			;
			using (SqlCommand command = new SqlCommand(insert, connection))
			{
				func(userComment, command);

			}

		}

		public void RunAddUserDonation(string sqlQuerey, pustDataReader_delegate1 func, Donation donorDetails)
		{
			if (!Connect()) return;
			string insert = sqlQuerey;
			;
			using (SqlCommand command = new SqlCommand(insert, connection))
			{
				func(donorDetails, command);

			}

		}

        public void runCommand1(string sqlQuery, SetDataReader_delegate func)
        {
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Adapter
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    //Reader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        func(reader);
                    }
                }
            }
        }




    }
}