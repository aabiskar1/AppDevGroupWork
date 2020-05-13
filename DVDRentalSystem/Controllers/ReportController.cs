using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataContext.Data;
namespace DVDRentalSystem.Controllers
{
    public class ReportController : Controller
    {
        private DVDRentalSystemContext dbCon = new DVDRentalSystemContext();
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FilterTitleByLastName(string LastName)
        {
            ViewBag.LastName = dbCon.CastDetails.ToList();
            if (String.IsNullOrEmpty(LastName))
            {
                return View();
            }
            var data = dbCon.CastMembers.Include("DVDDetails").Include("CastDetails")
                .Where(x => x.CastDetails.LastName == LastName);
            return View(data);

        }
    }
}