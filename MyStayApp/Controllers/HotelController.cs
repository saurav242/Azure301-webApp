using MyStayApp.Handler;
using MyStayApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace MyStayApp.Controllers
{
    public class HotelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly APIInvoker invoker = new APIInvoker();

        // GET: Hotel
        public ActionResult Index()
        {
            var result = invoker.GetAllHotels();
            var hotels = JsonConvert.DeserializeObject<IEnumerable<Hotel>>(result);

            return View(hotels);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = invoker.GetHotelById(id);
            var hotel = JsonConvert.DeserializeObject<Hotel>(result);

            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
