using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClickApp.Models;
namespace ClickApp.Controllers
{

    public class HomeController : Controller
    {
        private ClickAppDBEntities _entities = new ClickAppDBEntities();


        // GET: Home
        public ActionResult Index()
        {
            var _count = (from c in _entities.ClickApps
                          select c).First();

            return View(_count.Counter);
        }

        [HttpPost]
        public ActionResult Update()
        {
            var _count = (from c in _entities.ClickApps
                          select c).First();

            if (_count.Counter < 10)
            {
                _count.Counter = _count.Counter + 1;
                _entities.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}