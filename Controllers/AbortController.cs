using LMXRentACar.Models;
using LMXRentACar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMXRentACar.Controllers
{
    [Authorize]
    public class AbortController : Controller
    {
        private ApplicationDbContext _context;

        public AbortController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            
            List<Request> allRequests = _context.Requests.ToList();
            List<Request> pendingValidRequests = new List<Request>();
            foreach(var request in allRequests)
            {
                if (request.IsValid == true && request.StartDate >= DateTime.Today) pendingValidRequests.Add(request);
            }

            List<AdminPanelRequestModel> model = new List<AdminPanelRequestModel>();

            foreach (var req in pendingValidRequests)
            {
                Vehicle curr_vehicle = _context.Vehicles.Single(v => v.Id == req.VehicleId);
                model.Add(new AdminPanelRequestModel {
                    request = req,
                    vehicle = curr_vehicle
                });
            }

            return View(model);
        }
    }
}