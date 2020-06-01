using MyTestProject.Data.Context;
using MyTestProject.DTOs;
using System.Linq;
using System.Web.Mvc;

namespace MyTestProject.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            var db = new TableContext();
            var query = db.Users.AsQueryable();
            query = db.Users.Where(u => u.RoleId == 2);

            var users = query.Select(u => new UserDTO
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Username = u.Username

            }).ToList();
            return View(users);
        }
    }
}