using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyStayApp.Models;

namespace MyStayApp.Controllers
{
    public class BookingsController : Controller
    {

        public ActionResult Book(int? id)
        {

            return View();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}
