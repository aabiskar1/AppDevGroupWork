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
            .Where(x => x.Members.LastName== LastName).Count().ToString());

            Debug.WriteLine("super debugging pilars"+loanedCopiesCount);

            int temp = 0;
            var currentDate = DateTime.Now;
            var issueDateList = dbCon.Loans.Include("DVDDetails").Include("Members")
            .Where(x => x.Members.LastName == LastName).Select(x => x.IssueDate).ToList();
           // var memberId = dbCon.Loans.Include("DVDDetails").Include("Members")
           //.Where(x => x.Members.LastName == LastName).Select(x => x.MemberId).ToList();
            foreach (var val in issueDateList)
            {
               /// var getMemberId=memberId.IndexOf(temp);
                double days = (Convert.ToDateTime(currentDate) - Convert.ToDateTime(val)).TotalDays;
                if (days < 31)
                {
                    var data = dbCon.Loans.Include("DVDDetails").Include("Members")
               .Where(x => x.IssueDate== val);
                    //var data = dbCon.Loans.Include("DVDDetails").Include("Members")
                    //.Where(x => x.Members.MemberId == getMemberId);
                    //temp += 1;

                    return View(data);
                }
                else {
             
                    Debug.WriteLine("out of range date"+days.ToString());
                }
            }

      

            

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