using ApplicationDevGroupWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicationDevGroupWork.Controllers
{
    public class ReportController : Controller
    {
        private DataContext dbCon = new Data.DataContext();
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FilterTitleByLastName(string LastName)
        {
            var data = dbCon.CastMembers.Include("DVDDetails").Include("CastDetails")
                .Where(x => x.CastDetails.LastName == LastName);
            return View(data);

        }
    }
}