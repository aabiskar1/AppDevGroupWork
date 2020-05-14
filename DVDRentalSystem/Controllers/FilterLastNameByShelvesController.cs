using DataContext.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVDRentalSystem.Controllers
{
    public class FilterLastNameByShelvesController : Controller
    {
        private DVDRentalSystemContext dbCon = new DVDRentalSystemContext();
      
        // GET: FilterLastNameByShelves
        public ActionResult Index()
        {


            return View();


        }
        public ActionResult FilterTitleByCount(string LastName)
        {
            int searchId=0,copiesCount=0; 
            ViewBag.LastName = dbCon.CastDetails.ToList();
            if (String.IsNullOrEmpty(LastName))
            {
                Debug.WriteLine("Last name chaina");
                return View();
            }
            Debug.WriteLine("tesko naam:" + LastName);
            var DVDId = dbCon.CastMembers.Include("DVDDetails").Include("CastDetails").Where(c => c.CastDetails.LastName == LastName)
                .Select(c => c.DVDDetails.DVDDetailsId).ToList();
            foreach (var val in DVDId)
            {
                searchId = val;
               
            }



            var shelvesCount = int.Parse(dbCon.Loans.Include("DVDDetails")
                .Where(x => x.DVDDetails.DVDDetailsId == searchId).Count().ToString());
            var numberofcopies =dbCon.DVDDetails.Include("DVDDetails").Where(x => x.DVDDetailsId == searchId).Select(x => x.NumberOfCopies).ToList();
            foreach (var val in numberofcopies)
            {
                copiesCount = val;

            }
            var count =  copiesCount- shelvesCount;
            Debug.WriteLine("Count heram"+ count);

            var data = dbCon.CastMembers.Include("DVDDetails").Include("CastDetails")
                .Where(x => x.CastDetails.LastName == LastName);
            if (count > 0)
            {
                Debug.WriteLine("no khali");
                return View(data);
                
            }
            else
            {
                Debug.WriteLine("pura khali");
                return View();
            }


        }


    }
}