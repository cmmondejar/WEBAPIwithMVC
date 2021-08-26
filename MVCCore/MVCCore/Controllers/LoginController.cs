using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVCCore.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserInfo userInfo)
        {
            if (userInfo.userLogin == "charlie" && userInfo.password == "cmmondejar")
            {
                return RedirectToAction("Index", "Employee", userInfo);
            }
            else {
                ViewBag.Message = "Please check the readme file for correct creadential, thank you!";
                return View();
            }
        }

    }
}