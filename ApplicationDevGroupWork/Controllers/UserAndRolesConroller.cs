using ApplicationDevGroupWork.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;

using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ApplicationDevGroupWork.Controllers
{


    public class UserAndRolesConroller : Controller
    {
        // GET: UserAndRolesConroller
        public async Task<ActionResult> AddUserToRole()
        {

            var dbCon = new ApplicationDbContext();
            ApplicationUserRoleViewModel vm = new ApplicationUserRoleViewModel();
            var Users = await dbCon.Users.ToListAsync();
            var roles = await dbCon.Roles.ToListAsync();
            ViewBag.UserId = new SelectList(Users, "Id", "UserName");
            ViewBag.RoleId = new SelectList(roles, "Id", "Name");
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> AddUserToRole(ApplicationUserRoleViewModel model)
        {

            var dbCon = new ApplicationDbContext();
            var role = dbCon.Roles.Find(model.RoleId);
            if (role != null)
            {
                //await UserManager.AddToRoleAsync(model.UserId, role.Name);
            }
            return RedirectToAction("AddUserToRole");

        }
    }
}