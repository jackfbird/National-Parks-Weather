using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Capstone.Web.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class WeatherController : Controller
    {
        private IWeatherDAO weatherDAO;

        public WeatherController(IWeatherDAO weatherDAO)
        {
            this.weatherDAO = weatherDAO;
        }

        public IActionResult Detail(string id, int temp)
        {
            ViewBag.Forecast = HttpContext.Session.GetInt32("Forecast");

            if (ViewBag.Forecast == null || ViewBag.Forecast == 0)
            {
                HttpContext.Session.SetInt32("Forecast", 1);
            }
            if (temp != 0)
            {
                HttpContext.Session.SetInt32("Forecast", temp);
            }

            ViewBag.Forecast = HttpContext.Session.GetInt32("Forecast");
            IList<Weather> forecast = weatherDAO.GetWeather(id);
            return View(forecast);
        }

    }
}



