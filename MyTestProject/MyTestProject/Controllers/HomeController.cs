using MyTestProject.Data.Context;
using MyTestProject.Data.Models;
using MyTestProject.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MyTestProject.Common;

namespace MyTestProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginDTO userLoginDTO)
        {
            var db = new TableContext();
            var user = db.Users.FirstOrDefault(c => c.Username == userLoginDTO.Username && c.Password == userLoginDTO.Password);
            if (user != null)
            {
                if (user.RoleId == 2)
                {
                    TempData["userId"] = user.Id;
                    return RedirectToAction("Index", "User");
                }
                else
                    return RedirectToAction("Index", "Admin");
            }
            else
            {
                TempData["incorrectData"] = "incorrect";
                return View();
            }
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserDTO userDTO)
        {
            var db = new TableContext();
            var user = UserCommon.ConvertDTOtoBO(userDTO);

            if (ModelState.IsValid)
            {
                TempData["submitMessage"] = "success";
                db.Users.Add(user);
                db.SaveChanges();
            }
            return View();
        }
    }
}