using ManageEmplyees.Models;
using ManageEmplyees.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AuthenticationContext _context;

        public HomeController(AuthenticationContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {

            return View();
        }
    }
}