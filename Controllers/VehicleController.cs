using LMXRentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMXRentACar.Controllers
{
    public class VehicleController : Controller
    {
        private ApplicationDbContext _context;

        public VehicleController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Vehicle
        public ActionResult Index()
        {
            var vehicles = _context.Vehicles.ToList();

            return View(vehicles);
        }
    }
}