using MyTestProject.Common;
using MyTestProject.Data.Context;
using MyTestProject.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTestProject.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            var db = new TableContext();
            int userId = int.Parse(TempData["userId"].ToString());
            var user = db.Users.Where(u => u.Id == userId).FirstOrDefault();

            var userDTO = UserCommon.ConvertBOtoDTO(user);

            return View(userDTO);
        }
    }
}