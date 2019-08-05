using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Providers
{
    public interface IWeatherProvider
    {
        Weather GetForecast();
    }
}
