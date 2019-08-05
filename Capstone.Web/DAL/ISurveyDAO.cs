using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.DAL
{
    public interface ISurveyDAO
    {
        IList<Survey> GetAllPosts();
        bool SaveNewPost(Survey posts);
    }
}