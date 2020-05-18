using DataContext.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVDRentalSystem.Controllers
{
    public class FilterMembersByDVDDateController : Controller
    {


        private DVDRentalSystemContext dbCon = new DVDRentalSystemContext();
        // GET: FilterMembersByDVDDate
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult FilterMembersByDVDDate(string LastName)
        {

            DateTime issueDates;

            ViewBag.LastName = dbCon.Members.ToList();
            if (String.IsNullOrEmpty(LastName))
            {
                Debug.WriteLine("super debugging ID" + LastName);
                return View();
            }

            var loanedCopiesCount = int.Parse(dbCon.Loans.Include("DVDDetails").Include("Members")
            .Where(x => x.Members.LastName == LastName).Count().ToString());

            Debug.WriteLine("super debugging pilars" + loanedCopiesCount);

            int temp = 0;
            var currentDate = DateTime.Now;


            var data = dbCon.Loans.Include("DVDDetails").Include("Members")
                        .Where(x => x.Members.LastName == LastName);
            return View(data);
            // var memberId = dbCon.Loans.Include("DVDDetails").Include("Members")
            //.Where(x => x.Members.LastName == LastName).Select(x => x.MemberId).ToList();






            //var DVDId = dbCon.CastMembers.Include("DVDDetails").Include("CastDetails").Where(c => c.CastDetails.LastName == LastName)
            //    .Select(c => c.DVDDetails.DVDDetailsId).ToList();
            //foreach (var val in DVDId)
            //{
            //    searchId = val;

            //}



            //var shelvesCount = int.Parse(dbCon.Loans.Include("DVDDetails")
            //    .Where(x => x.DVDDetails.DVDDetailsId == searchId).Count().ToString());
            //var numberofcopies = dbCon.DVDDetails.Include("DVDDetails").Where(x => x.DVDDetailsId == searchId).Select(x => x.NumberOfCopies).ToList();
            //foreach (var val in numberofcopies)
            //{
            //    copiesCount = val;

            //}
            //var count = copiesCount - shelvesCount;

            //var data = dbCon.CastMembers.Include("DVDDetails").Include("CastDetails")
            //    .Where(x => x.CastDetails.LastName == LastName);
            //if (count > 0)
            //{

            //    return View(data);

            //}
            //else
            //{
            return View();
            //}


        }
    }
}