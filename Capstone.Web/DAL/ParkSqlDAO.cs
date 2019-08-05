using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAO : IParkDAO
    {
        private string connectionString = "";

        private string sql_GetParkByCode = "SELECT * FROM [Park]";

        private string sql_GetParkByCodes = "SELECT * FROM [Park] WHERE parkCode = @code";

        public ParkSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Park> GetAllParks()
        {
            IList<Park> parks = new List<Park>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {


                SqlCommand command = connection.CreateCommand();
                command.CommandText = sql_GetParkByCode;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                parks = MapParkReader(reader);
            }
            return parks;
        }




        public Park GetPark(string ParkCode)
        {

            Park result = new Park();
            // Create a new connection object
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Open the connection
                conn.Open();
                
                SqlCommand cmd = new SqlCommand(sql_GetParkByCodes, conn);
                cmd.Parameters.AddWithValue("@code", ParkCode);
                // Execute the command
                SqlDataReader reader = cmd.ExecuteReader();


                // Loop through each row
                while (reader.Read())
                {
                    // Create a product
                    Park park = new Park
                    {
                        ParkCode = Convert.ToString(reader["parkCode"]),
                        Name = Convert.ToString(reader["parkName"]),
                        State = Convert.ToString(reader["state"]),
                        YearFounded = Convert.ToInt32(reader["yearFounded"]),
                        Description = Convert.ToString(reader["parkDescription"]),
                        Acreage = Convert.ToInt32(reader["acreage"]),
                        ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]),
                        MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]),
                        NumberOfCampsites = Convert.ToInt32(reader["numberOfCampSites"]),
                        Climate = Convert.ToString(reader["climate"]),
                        AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                        Quote = Convert.ToString(reader["inspirationalQuote"]),
                        QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                        EntryFee = Convert.ToInt32(reader["entryFee"]),
                        NumberofAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])
                    };


                    result = park;
                }

                return result;
            }
        }
        
        private List<Park> MapParkReader(SqlDataReader reader)
        {
            List<Park> parks = new List<Park>();

            while (reader.Read())
            {
                Park park = new Park
                {
                    Name = Convert.ToString(reader["parkName"]),
                    State = Convert.ToString(reader["state"]),
                    Description = Convert.ToString(reader["parkDescription"]),
                    ParkCode = Convert.ToString(reader["parkCode"]),
                };

                parks.Add(park);
            }
            return parks;
        }
    }
}



              