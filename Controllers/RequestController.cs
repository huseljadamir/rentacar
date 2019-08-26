using LMXRentACar.Models;
using LMXRentACar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMXRentACar.Controllers
{
    public class RequestController : Controller
    {
        private ApplicationDbContext _context;

        public RequestController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Request
        public ActionResult Index()
        {
            Request request = new Request()
            {
                Name = "rx"
            };
            
            return View(request);
        }

        public ActionResult New(int id)
        {
            Vehicle myVehicle = new Vehicle()
            {
                Id = -1
            };
            var vehicles = _context.Vehicles.ToList();

            foreach (var vehicle in vehicles)
            {
                if (vehicle.Id == id) myVehicle = vehicle;
            }

            if (myVehicle.Id==-1) return HttpNotFound();

            FormRequestModel model = new FormRequestModel()
            {
                vehicle = myVehicle,
                request = new Request()
                {
                    VehicleId = id
                }
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Request request)
        {

            if(!ModelState.IsValid)
            {
                var myVehicle = _context.Vehicles.Single(c => c.Id == request.VehicleId);
                FormRequestModel model = new FormRequestModel()
                {
                    vehicle = myVehicle,
                    request = new Request()
                    {
                        VehicleId = myVehicle.Id,
                        IsValid = false
                    }

                };
                return View("New", model);
            }

            _context.Requests.Add(request);
            _context.SaveChanges();
            return RedirectToAction("Index", "Vehicle");
        }
    }
}