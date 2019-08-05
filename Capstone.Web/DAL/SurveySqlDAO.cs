using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;


namespace Capstone.Web.DAL
{
    public class SurveySqlDAO : ISurveyDAO
    {
        private const string PostSelectQuery = @"SELECT Count(survey_result.parkCode) AS 'Total', parkName, survey_result.parkCode
                                                FROM survey_result
                                                INNER JOIN  park
                                                ON survey_result.parkCode = park.parkCode
                                                GROUP BY parkName, survey_result.parkCode
                                                ORDER BY Total DESC, parkName";

        private readonly string connectionString;

        public SurveySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Survey> GetAllPosts()
        {
            IList<Survey> surveys = new List<Survey>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = PostSelectQuery;
                SqlDataReader reader = command.ExecuteReader();

                
                surveys = MapResultsToReader(reader);
            }

           
            return surveys;
        }



        private List<Survey> MapResultsToReader(SqlDataReader reader)
        {
            List<Survey> surveys = new List<Survey>();

            while (reader.Read())
            {
                Survey survey = new Survey
                {
                    Votes = Convert.ToString(reader["Total"]),
                    ParkName = Convert.ToString(reader["parkName"]),
                    ParkCode = Convert.ToString(reader["parkCode"]),
                };

                surveys.Add(survey);
            }
            return surveys;
        }

        private List<Survey> MapSurveyToReader(SqlDataReader reader)
        {
            List<Survey> surveys = new List<Survey>();

            while (reader.Read())
            {
                Survey survey = new Survey
                {
                    Votes = Convert.ToString(reader["Total"]),
                    ParkName = Convert.ToString(reader["parkName"]),
                    ParkCode = Convert.ToString(reader["parkCode"]),
                    EmailAddress = Convert.ToString(reader["emailAddress"]),
                    State = Convert.ToString(reader["state"]),
                    ActivityLevel = Convert.ToString(reader["activityLevel"]),
                };

                surveys.Add(survey);
            }
            return surveys;
        }

        public bool SaveNewPost(Survey post)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(@"INSERT INTO survey_result (parkcode, emailaddress, state, activitylevel) VALUES(@parkCode, @emailaddress, @state, @activitylevel);", connection);


                    command.Parameters.AddWithValue("@parkCode", post.ParkCode);
                    command.Parameters.AddWithValue("@emailaddress", post.EmailAddress);
                    command.Parameters.AddWithValue("@state", post.State);
                    command.Parameters.AddWithValue("@activitylevel", post.ActivityLevel);

                    command.ExecuteNonQuery();

                    if (post.ParkCode == null || post.EmailAddress == null || post.ActivityLevel == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (SqlException E)
            {
                throw;
            }

        }
    }
}