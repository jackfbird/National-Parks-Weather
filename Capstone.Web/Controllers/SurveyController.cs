using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private string connectionString = Startup.ConnectionString;

        private IParkDAO parkDAO;
        private ISurveyDAO surveyDAO;

        public SurveyController(IParkDAO parkDAO, ISurveyDAO surveyDAO)
        {
            this.parkDAO = parkDAO;
            this.surveyDAO = surveyDAO;
        }

        public ActionResult SurveyResult()
        {

            ISurveyDAO surveyDAO = new SurveySqlDAO(connectionString);
            ViewBag.Parks = parkDAO.GetAllParks();
            IList<Survey> posts = surveyDAO.GetAllPosts();
            return View(posts);

        }

        [HttpGet]
        public ActionResult NewSurvey()
        {
            ViewBag.Parks = parkDAO.GetAllParks();
            Survey newSurvey = new Survey();
            return View(newSurvey);
        }

        [HttpPost]
        public ActionResult NewSurvey(Survey newSurvey)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("NewSurvey", newSurvey);
            }
            else
            {
                ISurveyDAO surveyDAO = new SurveySqlDAO(connectionString);
                surveyDAO.SaveNewPost(newSurvey);
                return RedirectToAction("SurveyResult", new { newSurvey.ParkCode, newSurvey.EmailAddress, newSurvey.State, newSurvey.ActivityLevel });
            }
        }
    }
}