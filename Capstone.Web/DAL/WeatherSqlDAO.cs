using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAO : IWeatherDAO
    {
        private string connectionString = "";

        private string sql_GetForecastByCode = "SELECT * FROM [Weather] WHERE parkCode = @code";

        public WeatherSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Weather> GetWeather(string ParkCode)
        {
            IList<Weather> forecasts = new List<Weather>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {


                SqlCommand command = conn.CreateCommand();
                command.CommandText = sql_GetForecastByCode;
                command.Parameters.AddWithValue("@code", ParkCode);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                forecasts = MapWeatherReader(reader);
            }
            return forecasts;
        }

        
        private List<Weather> MapWeatherReader(SqlDataReader reader)
        {
            List<Weather> forecasts = new List<Weather>();

            while (reader.Read())
            {
                Weather forecast = new Weather
                {
                    ParkCode = Convert.ToString(reader["parkCode"]),
                    FiveDayValue = Convert.ToInt32(reader["fiveDayForecastValue"]),
                    Low = Convert.ToInt32(reader["low"]),
                    High = Convert.ToInt32(reader["high"]),
                    Forecast = Convert.ToString(reader["forecast"])
                };

                forecasts.Add(forecast);
            }
            return forecasts;
        }

    }
}
