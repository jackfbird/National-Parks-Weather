using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Providers
{
    public class CurrentWeather 
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IWeatherDAO weatherDAO;
        public static string SessionKey = "F";

        public CurrentWeather(IHttpContextAccessor contextAccessor, IWeatherDAO weatherDAO)
        {
            this.contextAccessor = contextAccessor;
            this.weatherDAO = weatherDAO;
        }

        /// <summary>
        /// Gets at the session attached to the http request.
        /// </summary>
        ISession Session => contextAccessor.HttpContext.Session;

        
    }
}
