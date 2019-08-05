using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public string Forecast { get; set; }
        public int FiveDayValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string WeatherImageName
        {
            get
            {
                return Forecast.ToLower() + ".png";
            }
        }
        public string Advisory
        {
            get; set;
        }
        public double CelciusLow
        {
            get
            {
                return (5.0 / 9.0 * (Low - 32));
            }
        }
        public double CelciusHigh
        {
            get
            {
                return (5.0 / 9.0 * (High - 32));
            }
        }

        public int temp { get; set; }

        public string WeatherAdvisory
        {
            get
            {
                string advisory = "";
                if (Forecast == "snow")
                {
                    advisory = "Pack snowshoes.";
                }
                if (Forecast == "rain")
                {
                    advisory = "Pack rain gear and wear waterproof shoes.";
                }
                if (Forecast == "thunderstorms")
                {
                    advisory = "Seek shelter and avoid hiking on exposed ridges.";
                }
                if (Forecast == "sun")
                {
                    advisory = "Pack sunblock.";
                }
                if (High > 75)
                {
                    advisory += " Bring an extra gallon of water.";
                }
                if (High - Low > 20)
                {
                    advisory += " Wear breathable layers.";
                }
                if (Low < 20)
                {
                    advisory += " Beware of the dangers of exposure to fridid temperatures.";
                }

                if(advisory.Length == 0)
                {
                    advisory = "No advisory today!";
                }

                return advisory;
            }
        }
    }
}


